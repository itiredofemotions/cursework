using System;

namespace CourseWork.WindowParts
{
    abstract class Drawer
    {
        public static void DrawConers(int x, int y, int lenght, int hight)
        {
            Console.SetCursorPosition(x,y);
            Console.Write('+');
            Console.SetCursorPosition(x + lenght, y);
            Console.Write('+');
            Console.SetCursorPosition(x + lenght, y + hight);
            Console.Write('+');
            Console.SetCursorPosition(x, y + hight);
            Console.Write('+');
            
        }
        public static void DrawHorizontalLines(int x, int y, int l, int h)
        {
            Console.SetCursorPosition(x, y);
            
            for (int i = 0; i < l; i++)
                Console.Write('-');

            Console.SetCursorPosition(x, y + h);
            
            for (int i = 0; i < l; i++)
                Console.Write('-');
        }
        public static void DrawVerticalLines(int x, int y, int l, int h)
        {
            for (int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write('|');
            }
            for (int i = 0; i < h; i++)
            {
                Console.SetCursorPosition(x + l, y + i);
                Console.Write('|');
            }
            
        }

        public static void ClearInside(int x, int y, int l, int h)
        {
            for (int i = y; i < h + y; i++)
            {
                for (int j = x; j < l + x; j++)
                {
                    Console.SetCursorPosition(j,i);
                    Console.WriteLine(' ');
                }
            }
        }

        public static void DrawAll(int x, int y, int l, int h)
        {
            ClearInside(x, y, l - 1, h - 1);
            DrawHorizontalLines(x, y, l - 1, h - 1);
            DrawVerticalLines(x, y, l - 1, h - 1);
            DrawConers(x, y, l - 1, h - 1);
        }
    }
}