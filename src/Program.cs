using System.Windows.Forms;
using System.Drawing;
using System;
using ScreenshotReader;
using System.Text;
using System.IO;
class Program
{
    [STAThread]
    static void Main()
    {
        Console.InputEncoding = Encoding.UTF8;
        Console.OutputEncoding = Encoding.UTF8;

        var config = AppConfig.Load();

        OcrHelper.SetTessDataPath(config.TessDataPath);
        if (!Directory.Exists(config.TessDataPath))
        {
            Console.WriteLine("Path not found (preferably the folder should be located with the executable file)");
            Console.ReadLine();
            return;
        }

        while (true)
        {
            Console.WriteLine("Press to Start");
            Console.ReadLine();
            using (SelectorForm selector = new SelectorForm())
            {
                if (selector.ShowDialog() == DialogResult.OK)
                {
                    Rectangle area = selector.SelectedArea;
                    string filename = OcrHelper.CaptureScreen(area);
                    string text = OcrHelper.RecognizeText(filename);
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        Clipboard.SetText(text);
                        Console.WriteLine($"\nText copied:\n{text}");
                    }
                    else
                    {
                        Console.WriteLine("Text not found");
                    }
                }
            }
        }
    }
}