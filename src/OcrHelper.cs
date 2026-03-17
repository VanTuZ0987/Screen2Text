using System.Drawing;
using System;
using Tesseract;
using System.IO;

namespace ScreenshotReader
{
    public class OcrHelper
    {
        private const string DEFAULT_LANGUAGES = "rus+eng";
        private static string _tessDataPath;

        public static void SetTessDataPath(string path)
        {
            _tessDataPath = path;
        }


        public static string CaptureScreen(Rectangle area)
        {
            using (Bitmap screenshot = new Bitmap(area.Width, area.Height))
            {
                using (Graphics g = Graphics.FromImage(screenshot))
                {
                    g.CopyFromScreen(area.X, area.Y, 0, 0, area.Size);
                }
                string screenshotsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Screenshots_Log");
                if (!Directory.Exists(screenshotsPath))
                    Directory.CreateDirectory(screenshotsPath);
                    
                string filename = Path.Combine(screenshotsPath, $"screenshot_{DateTime.Now:yyyy-MM-dd_HH-mm-ss}.png");
                screenshot.Save(filename, System.Drawing.Imaging.ImageFormat.Png);
                Console.WriteLine($"Screenshot: {filename}");
                return filename;
            }
        }

        
        public static string RecognizeText(string imagePath)
        {
            try
            {
                using (var engine = new TesseractEngine(_tessDataPath, DEFAULT_LANGUAGES, EngineMode.Default))
                {
                    using (var img = Pix.LoadFromFile(imagePath))
                    {
                        using (var page = engine.Process(img))
                        {
                            return page.GetText().Trim();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error OCR: {ex.Message}");
                return "";
            }
        }
    }
}