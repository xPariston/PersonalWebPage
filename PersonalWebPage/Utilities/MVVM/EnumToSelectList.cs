using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Utilities.Blazor.MVVM
{
    public static class EnumToSelectList
    {
        public static List<SelectListItem> Create<TEnum>
        (bool includeEmptyOption = false)
        {
            var type = typeof(TEnum);
            if (!type.IsEnum)
            {
                throw new ArgumentException(
                    "type must be an enum",
                    nameof(type)
                );
            }

            var result =
                Enum
                    .GetValues(type)
                    .Cast<TEnum>()
                    .Select(v =>
                        new SelectListItem()
                        {
                            Text = v.ToString(),
                            Value = v.ToString()
                        }

                    )
                    .ToList();

            if (includeEmptyOption)
            {
                // Insert the empty option
                // at the beginning
                result.Insert(
                    0,
                    new SelectListItem()
                    {
                        Text = "Choose...",
                        Value = ""
                    }
                );
            }

            return result;
        }
    }
}
