using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Console = Colorful.Console;
using System.Drawing;

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
        public void WriteInAscii(string text)
        {

            Console.WriteAscii(text, Color.Red);

        }

        public void Danger(string text)
        {
            Console.WriteLine(text, Color.Red);
        }

        public void info(string text)
        {
            Console.WriteLine(text, Color.Green);
            
            
        }
    }
}