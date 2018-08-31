using ImageProcessor;
using ImageProcessor.Imaging.Formats;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageResizer
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                Console.WriteLine("Image Resize Start" +
                  "" +
                  "" +
                  "ed On " + DateTime.Now.ToString("dd/MM/yyy HH:mm"));

                string sourcePath = ConfigurationManager.AppSettings["input_source"].ToString();
                string targetPath = ConfigurationManager.AppSettings["output_source"].ToString();

                int resizeWidth = Convert.ToInt32(ConfigurationManager.AppSettings["resize_width"]);
                int resizeHeight = Convert.ToInt32(ConfigurationManager.AppSettings["resize_height"]);


                if (!System.IO.Directory.Exists(targetPath))
                {
                    System.IO.Directory.CreateDirectory(targetPath);
                }

                string sourceFile = System.IO.Path.Combine(sourcePath);
                string destFile = System.IO.Path.Combine(targetPath);

                if (!Directory.Exists(destFile))
                    Directory.CreateDirectory(destFile);

                if (System.IO.Directory.Exists(sourcePath))
                {
                     string[] localImages = Directory.GetFiles(sourcePath, "*", SearchOption.AllDirectories);
                    foreach (string image in localImages)
                    {

                        string getFullpath = image;
                        string getfile = getFullpath.Replace(sourceFile, "");

                        var fileName = System.IO.Path.GetFileNameWithoutExtension(image); // 60-1235a.jpg
                        if (fileName.IndexOf(".") > 0)
                        {
                            fileName = fileName.Split('.')[0]; //fileName.Substring(0, fileName.Length - 4);
                        }
                        var fileExt = System.IO.Path.GetExtension(image);

                        getfile = getfile.Replace(fileName + "" + fileExt, "");
                        String destFileWithQltyName = destFile+""+ getfile;

                        if (!Directory.Exists(destFileWithQltyName))
                        Directory.CreateDirectory(destFileWithQltyName);


                        String outFile = Path.Combine(destFileWithQltyName, fileName + fileExt);

                        //String outFile = Path.Combine(destFileWithQltyName, fileName + fileExt);

                        //String outFile = Path.Combine(destFileWithQltyName, fileName + fileExt);

                        byte[] photoBytes = File.ReadAllBytes(image);
                        // Format is automatically detected though can be changed.
                        ISupportedImageFormat format = new JpegFormat { Quality = 100 };
                        Size size = new Size(resizeWidth, resizeHeight);
                        using (MemoryStream inStream = new MemoryStream(photoBytes))
                        {
                            using (MemoryStream outStream = new MemoryStream())
                            {
                                // Initialize the ImageFactory using the overload to preserve EXIF metadata.
                                using (ImageFactory imageFactory = new ImageFactory(preserveExifData: true))
                                {
                                    // Load, resize, set the format and quality and save an image.
                                    imageFactory.Load(inStream)
                                    .Resize(size)
                                    .Format(format)
                                    .Save(outFile);
                                }
                                // Do something with the stream.
                            }
                        }

                    }

                 }

             }
            catch(Exception ex)
            {
                
                Console.WriteLine(ex.Message + "-" + ex.StackTrace.ToString());
            }
            Console.WriteLine("Image Resize Completed On " + DateTime.Now.ToString("dd/MM/yyy HH:mm"));
            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();

        }
    }
}
