using Fluke.Domain.Models;

namespace Fluke.API.Helpers
{
    public static class QueryHelper
    {
        public static string BuildQueryString(OptionsModel options)
        {
            var queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            if (options != null)
            {
                foreach (var parameter in options.GetType().GetProperties())
                {
                    var value = parameter.GetValue(options, null);
                    if (value != null)
                    {
                        queryString.Add(parameter.Name.ToLower(), value.ToString());
                    }
                }
            }
            return queryString.ToString();
        }
    }
}
