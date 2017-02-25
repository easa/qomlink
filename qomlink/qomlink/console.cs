using System;
using System.Collections.Generic;
using System.Text;

namespace qomlink.Models
{
    class console
    {
        public static void log(string str)
        {
            Console.WriteLine(str);
        }
        public static void upline()
        {
            var origRow = Console.CursorTop;
            var origCol = Console.CursorLeft;
            var conCol = Console.WindowWidth;
            //clear last line, then set position on it
            string spaces = "                                                                                                    "; //100
            WriteAt(spaces.Substring(0, conCol > spaces.Length? spaces.Length: conCol), 0, origRow - 1);
            setAt(0, origRow - 1);
        }
        protected static void setAt(int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
            }
            catch (Exception e) {
					 console.log(e.Message);
				}
        }
        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(x, y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                //Console.Clear();
                console.log(e.Message);
            }
        }
    }
}
