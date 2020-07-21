# FlukeTestTask
## Examples of use
Retrieve all events:
> /api/events

Order by title (ascending):
> /api/events?orderBy=title

Filter by category:
> /api/events?category=Wildfires

Filter by date:
> /api/events?date=2020-07-20

Filter by status:
> /api/events?status=closed

Get with limit of 10 events:
> /api/events?limit=10

Get with limit of 200 days
> /api/events?days=200

Get 20 events from 'Wildfires' category for the last 30 days ordered by 'Title':
> /api/events?orderBy=title&category=Wildfires&limit=20&days=30

## Notes
**Configurable values:**

Maximum number of days: **365**

Maximum limit: **50**
