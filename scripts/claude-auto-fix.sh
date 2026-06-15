#!/usr/bin/env bash
#
# claude-auto-fix.sh — the validation-gate pattern WITHOUT GitHub.
#
# Same safety model as the CI workflow ("Claude proposes, the test suite disposes"),
# but driven by the headless Claude CLI (`claude -p`). Works locally or in any CI
# (GitLab, Jenkins, CircleCI, a cron box) — anywhere a shell and `claude` exist.
#
# The three guardrails:
#   - Validation gate : $TEST_CMD is the success oracle. We only stop on green.
#   - Rollback net    : a git checkpoint is taken up front; if we exhaust the budget
#                       still red, we `git reset --hard` back to it — no half-fix left.
#   - Iteration limit : $MAX_ITERATIONS bounds the loop; --max-turns bounds each call.
#   - Least privilege : --allowedTools restricts Claude to running tests, reading, editing.
#
# Usage:
#   ./scripts/claude-auto-fix.sh
#   TEST_CMD="cd fluke-client && CI=true npm test" MAX_ITERATIONS=5 ./scripts/claude-auto-fix.sh
#
set -euo pipefail

TEST_CMD="${TEST_CMD:-dotnet test}"
MAX_ITERATIONS="${MAX_ITERATIONS:-3}"

# --- Rollback anchor: refuse to run on a dirty tree so the checkpoint is meaningful.
if ! git diff --quiet || ! git diff --cached --quiet; then
  echo "✋ Working tree is dirty. Commit or stash first so rollback is safe." >&2
  exit 1
fi
CHECKPOINT="$(git rev-parse HEAD)"
echo "📌 Checkpoint: $CHECKPOINT"
echo "🧪 Gate command: $TEST_CMD"

run_tests() { bash -c "$TEST_CMD"; }

for i in $(seq 1 "$MAX_ITERATIONS"); do
  echo ""
  echo "=== Iteration $i / $MAX_ITERATIONS ==="

  if run_tests; then
    echo "✅ Tests pass — done."
    exit 0
  fi

  echo "❌ Tests failing — asking Claude for a minimal fix…"
  claude -p "The test suite (\`$TEST_CMD\`) is failing. Reproduce it, read the failure
output, trace the root cause, and make the MINIMAL change required to make the tests
pass. Fix the production code, not the tests — do NOT weaken, skip, or delete
assertions to force a green run. Do not refactor unrelated code." \
    --max-turns 15 \
    --allowedTools "Bash(dotnet:*),Bash(npm:*),Read,Edit"
done

# --- Final validation gate after the iteration budget is spent.
echo ""
echo "=== Final verification ==="
if run_tests; then
  echo "✅ Tests pass after $MAX_ITERATIONS iteration(s)."
  exit 0
fi

echo "🚨 Still red after $MAX_ITERATIONS iteration(s) — rolling back to $CHECKPOINT." >&2
git reset --hard "$CHECKPOINT"
exit 1
