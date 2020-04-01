using System;
using System.Configuration;
using Cir.CloudConvert.Wrapper.ConfigElements;
using Cir.CloudConvert.Wrapper.Interfaces;

namespace Cir.CloudConvert.Wrapper
{
    /// <summary>
    /// This represents the <c>ConfigurationSection</c> element entity for <c>ConverterSettings</c>.
    /// </summary>
    public class ConverterSettings : ConfigurationSection, IConverterSettings
    {
        private bool _disposed;

        /// <summary>
        /// Gets or sets the basic element.
        /// </summary>
        [ConfigurationProperty("basic", IsRequired = true)]
        public BasicElement Basic
        {
            get { return (BasicElement)this["basic"]; }
            set { this["basic"] = value; }
        }

        /// <summary>
        /// Creates a new instance of the <c>ConverterSettings</c> class.
        /// </summary>
        /// <returns>Returns the new instance of the <c>ConverterSettings</c> class.</returns>
        public static IConverterSettings CreateInstance()
        {
            var settings = GetFromConverterSettings();
            if (settings != null)
            {
                return settings;
            }

            settings = GetFromAppSettings();
            return settings;
        }

        /// <summary>
        /// Gets the <c>ConverterSettings</c> object from the converterSettings element.
        /// </summary>
        /// <returns>Returns the <c>ConverterSettings</c> object.</returns>
        private static IConverterSettings GetFromConverterSettings()
        {
            //var settings = ConfigurationManager.GetSection("converterSettings") as IConverterSettings;
            var processUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            bool result;
            var useHeader = Boolean.TryParse(ConfigurationManager.AppSettings["UseHeader"], out result) && result;
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            if (String.IsNullOrWhiteSpace(processUrl) || String.IsNullOrWhiteSpace(apiKey))
            {
                processUrl = "https://api.cloudconvert.com/process";
                useHeader = Boolean.TryParse("true", out result) && result;
                apiKey = "gRZNr6HeVKIW8gZILkNE0aYJqxmhuJw0eyTrpOHwGUvlQVBwwbb7WKCzM6z6DqOP";
                //return null;
            }

            var settings = new ConverterSettings
            {
                Basic = new BasicElement
                {
                    ProcessUrl = processUrl,
                    UseHeader = useHeader,
                    ApiKey = new ApiKeyElement
                    {
                        Value = apiKey,
                    },
                }
            };
            return settings;
        }

        /// <summary>
        /// Gets the <c>ConverterSettings</c> object from the appSettings element.
        /// </summary>
        /// <returns>Returns the <c>ConverterSettings</c> object.</returns>
        private static IConverterSettings GetFromAppSettings()
        {
            var processUrl = ConfigurationManager.AppSettings["ProcessUrl"];
            bool result;
            var useHeader = Boolean.TryParse(ConfigurationManager.AppSettings["UseHeader"], out result) && result;
            var apiKey = ConfigurationManager.AppSettings["ApiKey"];
            if (String.IsNullOrWhiteSpace(processUrl) || String.IsNullOrWhiteSpace(apiKey))
            {
                return null;
            }

            var settings = new ConverterSettings
                           {
                               Basic = new BasicElement
                                       {
                                           ProcessUrl = processUrl,
                                           UseHeader = useHeader,
                                           ApiKey = new ApiKeyElement
                                                    {
                                                        Value = apiKey,
                                                    },
                                       }
                           };
            return settings;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this._disposed)
            {
                return;
            }

            this._disposed = true;
        }
    }
}