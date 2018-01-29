using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;

namespace WarGames.Art
{
    
    public static class Animation
    {

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        public static void Animate()
        {

            Image image = Properties.Resources.ship as Image;
            image = resizeImage(image, new Size(55, 30));


            StringBuilder sb;

            // Remember cursor position
            int left = Console.WindowLeft, top = 5;


            char[] chars = { ' ', ' ', '-', ':', '*', '+',
                             '=', '%', '@', '#', '#' };


            sb = new StringBuilder();
            

            for (int h = 0; h < image.Height; h++)
            {
                for (int w = 0; w < image.Width; w++)
                {
                    Color cl = ((Bitmap)image).GetPixel(w, h);
                    int gray = (cl.R + cl.G + cl.B) / 3;
                    int index = (gray * (chars.Length - 1)) / 255;

                    sb.Append(chars[index]);
                }
                sb.Append('\n');
            }

            Console.SetCursorPosition(left, top);
            Console.WriteLine(sb.ToString(), Color.OrangeRed);

            System.Threading.Thread.Sleep(100);

        }
    }
}
