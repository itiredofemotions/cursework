using System;
using System.Collections.Generic;

namespace CourseWork.WindowParts
{
    public abstract class Manager
    {
        public static List<Window> windowsList = new List<Window>();
        public static int numActiveWindow;
        public static void ChangeWindow()
        {
            numActiveWindow = (numActiveWindow + 1) % windowsList.Count;
        }
        
        public static void DrawWins()
        {
            foreach (var win in windowsList)
            {
                if (win != windowsList[numActiveWindow])
                {
                    win.Draw(false);
                }
                else
                {
                    continue;
                }
            }
            windowsList[numActiveWindow].Draw(true);
            
            
        }

        public static void ButtonSelection()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.J:
                    Manager.ChangeWindow();
                    break;
                case ConsoleKey.UpArrow:
                    Manager.windowsList[Manager.numActiveWindow].MoveWindow(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    Manager.windowsList[Manager.numActiveWindow].MoveWindow(0, 1);
                    break;
                case ConsoleKey.RightArrow:
                    Manager.windowsList[Manager.numActiveWindow].MoveWindow(3, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    Manager.windowsList[Manager.numActiveWindow].MoveWindow(-3, 0);
                    break;
                case ConsoleKey.Q:
                    Manager.windowsList[Manager.numActiveWindow].ButtonSelection();
                    break;
            }
        }
    }
}
