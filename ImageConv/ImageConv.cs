using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ImageConv
{
    internal static class ImageConv
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            Convert_class main_class = new Convert_class();
            main_class.Convert(args);
        }
    }
}

class Convert_class
{
    Bitmap imageIn;
    PixelFormat depth_bpp = PixelFormat.Format32bppPArgb;
    /*string input_fil;
    string input_ext;
    string input_filename;*/
    string output_fil;
    int width;
    int height;
    bool bmp = false;
    bool gif = false;
    bool ico = false;
    bool jpeg = false;
    bool memorybmp = false;
    bool exif = false;
    bool wmf = false;
    bool emf = false;
    bool jpg = false;
    bool png = false;
    bool tif = false;
    bool tiff = false;
    bool warn = false;
    bool stfu = false;
    string end;
    byte last_value_index = 0;
    void Check_extension(string ext)
    {
        switch (ext.ToUpper())
        {
            case "BMP":
                bmp = true;
                break;
            case "GIF":
                gif = true;
                break;
            case "ICO":
                ico = true;
                break;
            case "JPEG":
                jpeg = true;
                break;
            case "JPG":
                jpg = true;
                break;
            case "PNG":
                png = true;
                break;
            case "TIF":
                tif = true;
                break;
            case "TIFF":
                tiff = true;
                break;
            case "MEMORYBMP":
                memorybmp = true;
                break;
            case "EXIF":
                exif = true;
                break;
            case "WMF":
                wmf = true;
                break;
            case "EMF":
                emf = true;
                break;
        }
    }
    void Check_input_file(string input_file)
    {
        if (System.IO.File.Exists(input_file) && imageIn == null)
        {
            imageIn = (Bitmap)Bitmap.FromFile(input_file);
            width = imageIn.Width;
            height = imageIn.Height;
        }
    }
    void Check_depth(string depth)
    {
        switch (depth.ToLower())
        {
            case "1":
                depth_bpp = PixelFormat.Format1bppIndexed;
                break;
            case "4":
                depth_bpp = PixelFormat.Format4bppIndexed;
                break;
            case "8":
                depth_bpp = PixelFormat.Format8bppIndexed;
                break;
            case "16argb1555":
            case "argb1555":
            case "16argb":
            case "16a":
                depth_bpp = PixelFormat.Format16bppArgb1555;
                break;
            case "16gray":
            case "16grey":
            case "16g":
                depth_bpp = PixelFormat.Format16bppGrayScale;
                break;
            case "16555":
            case "16rgb555":
                depth_bpp = PixelFormat.Format16bppRgb555;
                break;
            case "16":
            case "16rgb565":
            case "rgb565":
                depth_bpp = PixelFormat.Format16bppRgb565;
                break;
            case "rgb":
            case "24":
                depth_bpp = PixelFormat.Format24bppRgb;
                break;
            case "32":
            case "rgba":
                depth_bpp = PixelFormat.Format32bppArgb;
                break;
            case "32pargb":
            case "pargb":
            case "32p":
                depth_bpp = PixelFormat.Format32bppPArgb;
                break;
            case "32rgb":
            case "32r":
                depth_bpp = PixelFormat.Format32bppRgb;
                break;
            case "48":
                depth_bpp = PixelFormat.Format48bppRgb;
                break;
            case "64":
                depth_bpp = PixelFormat.Format64bppArgb;
                break;
            case "64p":
            case "64pargb":
                depth_bpp = PixelFormat.Format64bppPArgb;
                break;
        }
    }
    public void Convert(string[] args)
    {
        if (args.Length == 1) // of course args[0] is the executable name
            return;
        for (ushort i = 1; i < args.Length; i++)
        {
            for (int j = 0; j < args[i].Length;)
            {
                if (args[i][j] == '-')
                {
                    args[i] = args[i].Substring(1, args[i].Length - 1);
                }
                else
                {
                    break;
                }
            }  // who had the stupid idea to add -- before each argument. I'm removing them all lol
            Check_extension(args[i]);
            switch (args[i].ToUpper())
            {
                case "W":
                case "WARN":
                    warn = true;
                    break;
                case "STFU":
                    stfu = true;
                    break;
                default:
                    if (imageIn != null && args[i].Contains(".") && args[i].Length > 1)
                    {
                        output_fil = System.IO.Path.GetFileNameWithoutExtension(args[i]);  // removes the text after the extension dot (also removes the last dot).
                        Check_extension(System.IO.Path.GetExtension(args[i]).Substring(1));  // keeps only the text after the extension dot.;
                    }
                    else if (imageIn != null)
                    {
                        output_fil = args[i];
                    }
                    Check_depth(args[i]);
                    Check_input_file(args[i]);
                    break;
            }
        }
        Bitmap imageOut = new Bitmap(width, height, depth_bpp);
        using (var gr = Graphics.FromImage(imageOut))
            gr.DrawImage(imageIn, new Rectangle(0, 0, width, height));
        using (var ms = new MemoryStream())
        {
            try
            {
                while (true)
                {
                    if (png && last_value_index < 1)
                    {
                        imageOut.Save(ms, ImageFormat.Png);
                        end = ".png";
                        last_value_index = 1;
                    }
                    else if (tif && last_value_index < 2)
                    {
                        imageOut.Save(ms, ImageFormat.Tiff);
                        end = ".tif";
                        last_value_index = 2;
                    }
                    else if (tiff && last_value_index < 3)
                    {
                        imageOut.Save(ms, ImageFormat.Tiff);
                        end = ".tiff";
                        last_value_index = 3;
                    }
                    else if (jpg && last_value_index < 4)
                    {
                        imageOut.Save(ms, ImageFormat.Jpeg);
                        end = ".jpg";
                        last_value_index = 4;
                    }
                    else if (jpeg && last_value_index < 5)
                    {
                        imageOut.Save(ms, ImageFormat.Jpeg);
                        end = ".jpeg";
                        last_value_index = 5;
                    }
                    else if (gif && last_value_index < 6)
                    {
                        imageOut.Save(ms, ImageFormat.Gif);
                        end = ".gif";
                        last_value_index = 6;
                    }
                    else if (exif && last_value_index < 7)
                    {
                        imageOut.Save(ms, ImageFormat.Exif);
                        end = ".exif";
                        last_value_index = 7;
                    }
                    else if (bmp && last_value_index < 8)
                    {
                        imageOut.Save(ms, ImageFormat.Bmp);
                        end = ".bmp";
                        last_value_index = 8;
                    }
                    else if (ico && last_value_index < 9)
                    {
                        imageOut.Save(ms, ImageFormat.Icon);
                        end = ".ico";
                        last_value_index = 9;
                    }
                    else if (emf && last_value_index < 10)
                    {
                        imageOut.Save(ms, ImageFormat.Emf);
                        end = ".emf";
                        last_value_index = 10;
                    }
                    else if (wmf && last_value_index < 11)
                    {
                        imageOut.Save(ms, ImageFormat.Wmf);
                        end = ".wmf";
                        last_value_index = 11;
                    }
                    else if (memorybmp && last_value_index < 12)
                    {
                        imageOut.Save(ms, ImageFormat.MemoryBmp);
                        end = ".bmp";
                        last_value_index = 12;
                    }
                    else
                    {
                        break;  // prevents the function from being called infinitely :P
                    }
                    FileMode mode = System.IO.FileMode.CreateNew;
                    if (System.IO.File.Exists(output_fil + end))
                    {
                        mode = System.IO.FileMode.Truncate;
                        if (warn)
                        {
                            Console.WriteLine("Press enter to overwrite " + output_fil + end);
                            Console.ReadLine();
                        }
                    }
                    using (System.IO.FileStream file = System.IO.File.Open(output_fil + end, mode, System.IO.FileAccess.Write))
                    {
                        file.Write(ms.ToArray(), 0, (int)ms.Length);
                        file.Close();
                        if (!stfu)
                            Console.WriteLine(output_fil + end);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
                if (!stfu)
                    Console.WriteLine("Invalid output parameters. File was not written");
                if (warn)
                    throw e;
            }
        }
    }
}