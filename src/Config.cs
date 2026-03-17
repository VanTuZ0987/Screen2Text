using System;
using System.IO;
using System.Text.Json;

namespace ScreenshotReader
{
    public class AppConfig
    {
        public string TessDataPath { get; set; }
        
        public static AppConfig Load()
        {
            string configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
            
            if (File.Exists(configPath))
            {
                string json = File.ReadAllText(configPath);
                return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
            }
            
            return new AppConfig 
            { 
                TessDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata")
            };
        }
    }
}