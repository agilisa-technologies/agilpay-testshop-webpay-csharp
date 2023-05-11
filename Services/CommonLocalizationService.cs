using Microsoft.Extensions.Localization;
using System.Reflection;
using Test_Shop1.Resources;

namespace Test_Shop1.Services
{
    public class CommonLocalizationService
    {
        private readonly IStringLocalizer localizer;
        public CommonLocalizationService(IStringLocalizerFactory factory)
        {
            var assemblyName = new AssemblyName(typeof(CommonResources).GetTypeInfo().Assembly.FullName);
            localizer = factory.Create(nameof(CommonResources), assemblyName.Name);
        }

        public string Get(string key)
        {
            return localizer[key];
        }
    }
}
