using System.ComponentModel;
using System.Reflection;

namespace Antheap_1_task_net_react.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name == null)
                return null;

            FieldInfo field = type.GetField(name);
            if (field == null)
                return null;

            DescriptionAttribute attribute = field.GetCustomAttribute<DescriptionAttribute>();
            return attribute?.Description;
        }
    }
}
