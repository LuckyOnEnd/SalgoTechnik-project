using Microsoft.Extensions.Localization;
using SalgoTechnik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SalgoTechnik.Application.Services
{
    public class LanguageService
    {
        private readonly IStringLocalizer _localizer;

        public LanguageService(IStringLocalizerFactory factory)
        {
            var type = typeof(SharedResource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("SharedResource", assemblyName.Name);
        }

        public LocalizedString this[string key] => _localizer[key];

        public LocalizedString GetLocalizedString(string key)
        {
            return _localizer[key];
        }
    }
}
