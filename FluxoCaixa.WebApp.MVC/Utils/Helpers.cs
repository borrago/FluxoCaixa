using System.ComponentModel.DataAnnotations;

namespace FluxoCaixa.WebApp.MVC.Utils
{
    public static class Helpers
    {
        public static string GetDisplay<T>(this T source) where T : Enum
        {
            var fi = source.GetType().GetField(source.ToString());

            if (fi == null)
                return string.Empty;

            var attributes = fi.GetCustomAttributes(typeof(DisplayAttribute), false);
            if (attributes == null || attributes.Length == 0)
                return string.Empty;

            if (!(attributes.First() is DisplayAttribute attribute))
                return string.Empty;

            return attribute.Name;
        }
    }
}
