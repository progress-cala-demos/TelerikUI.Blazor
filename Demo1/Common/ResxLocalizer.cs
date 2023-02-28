using Telerik.Blazor.Services;
using Demo1.Resources;

namespace Demo1.Common
{
    public class ResxLocalizer : ITelerikStringLocalizer
    {
        public string this[string name]
        {
            get
            {
                return GetStringFromResource(name);
            }
        }

        public string GetStringFromResource(string key)
        {
            return TelerikMessages.ResourceManager.GetString(key, TelerikMessages.Culture);
        }
    }
}
