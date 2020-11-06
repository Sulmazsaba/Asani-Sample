using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AsaniSample.Core.Helpers
{
  public static class EnumExtensions
    {
        public static string GetDescription(this Enum enumVar)
        {
            var attribute =
                enumVar.GetType()
                        .GetTypeInfo()
                        .GetMember(enumVar.ToString())
                        .FirstOrDefault(member => member.MemberType == MemberTypes.Field)
                        ?.GetCustomAttributes(typeof(DescriptionAttribute), false)
                        .SingleOrDefault()
                    as DescriptionAttribute;

            return attribute?.Description ?? enumVar.ToString();

        }
    }
}
