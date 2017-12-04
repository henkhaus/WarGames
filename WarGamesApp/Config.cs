using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WarGamesApp
{
    public static class Config
    {
        public static void WaitandClear()
        {
            Thread.Sleep(2 * 1000);
            Console.Clear();
        }
    }
}
