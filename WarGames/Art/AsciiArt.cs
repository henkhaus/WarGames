using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;
using System.Threading;

// http://colorfulconsole.com/
namespace WarGames.Art
{
    public class AsciiGenerator
    {
        /// <summary>
        /// Pass in Text to be written as ascii Art. 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="color"></param>
        public void WriteInAscii(string text, Color color)
        {
            Console.WriteAscii(text, color);
        }


        public void ColorTest()
        {
            WriteInAscii("Color Test", Color.White);
            Info("Info");
            Warn("Warn");
            Danger("Danger");
            Help("Help");

            Info("Press Enter to End Color Test.");
            Console.ReadLine();
            Console.Clear();
        }


        public void Danger(string text)
        {
            Console.WriteLine(text, Color.Red);
        }

        public void Warn(string text)
        {
            Console.WriteLine(text, Color.Yellow);
        }

        public void Info(string text)
        {
            Console.WriteLine(text, Color.Green);
        }

        public void Muted(string text)
        {
            Console.WriteLine(text, Color.DarkGray);
        }

        public void Help(string text)
        {
            Console.WriteLine(text, Color.LightSkyBlue);
        }
    }
}