using System;
using ValidationAttributes.Attributes;
using System.Linq;
using System.Reflection;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            var properties = obj.GetType().GetProperties();

            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes()
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                var value = property.GetValue(obj);
                foreach (var atribute in attributes)
                {
                    bool isValid = atribute.IsValid(value);
                    if (!isValid)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
