using System.ComponentModel.DataAnnotations;

namespace StaticClasses
{
    public static class DataAnnotation
    {
        public static int GetMaxLengthFromStringLengthAttribute(Type modelClass, string propertyName)
        {
            int maxLength = 0;
            var attribute = modelClass.GetProperties()
                            .Where(p => p.Name == propertyName)
                            .Single()
                            .GetCustomAttributes(typeof(StringLengthAttribute), true)
                            .Single() as StringLengthAttribute;
            if (attribute != null)
                maxLength = attribute.MaximumLength;
            return maxLength;
        }
    } 
}