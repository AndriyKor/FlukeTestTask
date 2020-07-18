using Fluke.API.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Fluke.API.Binders
{
    public class FilterModelBinder : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }

            if (bindingContext.ModelType != typeof(FilterModel))
            {
                return Task.CompletedTask;
            }

            var parameters = new Dictionary<string, string>();
            foreach (var parameter in bindingContext.ModelType.GetProperties())
            {
                var valueProviderResult = bindingContext.ValueProvider.GetValue(parameter.Name);
                if (valueProviderResult.FirstValue != null)
                {
                    parameters.Add(parameter.Name, valueProviderResult.FirstValue);
                }
            }

            var result = new FilterModel();

            PropertyInfo[] properties = result.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (!parameters.Any(p => p.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase)))
                    continue;

                KeyValuePair<string, string> parameter = parameters.First(p => p.Key.Equals(property.Name, StringComparison.InvariantCultureIgnoreCase));

                Type propertyType = result.GetType().GetProperty(property.Name).PropertyType;
                Type newType = Nullable.GetUnderlyingType(propertyType) ?? propertyType;

                object newObject = Convert.ChangeType(parameter.Value, newType);
                result.GetType().GetProperty(property.Name).SetValue(result, newObject, null);
            }

            bindingContext.Result = ModelBindingResult.Success(result);
            return Task.CompletedTask;
        }
    }
}
