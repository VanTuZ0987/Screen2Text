# Screen2Text
## Usage
```cmd
dotnet build
```
After building, move the tessdata folder to the executable directory
## Language support

The program uses Tesseract OCR. You can add any language by downloading `.traineddata` files from:
[Tesseract tessdata repository](https://github.com/tesseract-ocr/tessdata)

Just place the files in the `tessdata` folder next to the executable.