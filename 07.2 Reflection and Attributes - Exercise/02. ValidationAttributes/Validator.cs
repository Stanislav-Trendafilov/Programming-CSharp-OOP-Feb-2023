using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            Type type = obj.GetType();

            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                MyValidationAttribute myValidationAttribute = property
                    .GetCustomAttribute(typeof(MyValidationAttribute)) as MyValidationAttribute;

                if (!myValidationAttribute.IsValid(property.GetValue(obj)))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
