using Fluke.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using System;

namespace Fluke.API.Binders
{
    public class FilterModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (context.Metadata.ModelType == typeof(FilterModel))
            {
                return new BinderTypeModelBinder(typeof(FilterModelBinder));
            }

            return null;
        }
    }
}
