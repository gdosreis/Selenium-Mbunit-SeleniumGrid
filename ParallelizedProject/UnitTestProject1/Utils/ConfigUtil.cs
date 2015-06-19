using System;
using System.Configuration;
using System.Reflection;

namespace Utils.Util
{
    /// <summary>
    /// This class manages the App.config file.
    /// </summary>
    public sealed class ConfigUtil
    {
        static Configuration cfg = ConfigurationManager.OpenExeConfiguration(new Uri(Assembly.GetExecutingAssembly().CodeBase).AbsolutePath);// Set the App.config path

        /// <summary>
        /// This method take the App.config value.
        /// </summary>
        public static string GetString(string arg0)
        {
            return cfg.AppSettings.Settings[arg0].Value;
        }

        /// <summary>
        /// This method take the App.config value and parse it to int.
        /// </summary>
        public static int GetInt(string arg0)
        {
            return int.Parse(cfg.AppSettings.Settings[arg0].Value);
        }

        /// <summary>
        /// This method take the App.config value and parse it to decimal.
        /// </summary>
        public static decimal GetDecimal(string arg0)
        {
            return decimal.Parse(cfg.AppSettings.Settings[arg0].Value);
        }

    }
}
