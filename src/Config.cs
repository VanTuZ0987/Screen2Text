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
            return new AppConfig 
            { 
                TessDataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata")
            };
        }
    }
}