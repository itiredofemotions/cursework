using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq.Expressions;
using CourseWork.HospitalWindows;
using CourseWork.WindowParts;

namespace CourseWork
{
    internal abstract class Program
    {
        enum Pages
        {
            Authorization = 0,
            Registration = 1,
            Welcome = 2,
            WeeklySchedule = 3,
            DailySchedule = 4,
            Patients = 5
        }
        
        public static string name = "auth";
        public static void DrawActivateWindow(ref string name)
        {
            switch (name)
            {
                case "auth":
                    Manager.numActiveWindow = 0;
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                case "regi":
                    Manager.numActiveWindow = 1;
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                case "welc":
                    Manager.numActiveWindow = 2;
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                case "week":
                    Manager.numActiveWindow = 3;
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                case "pati":
                    Manager.numActiveWindow = 4;
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                case "dail":
                    Manager.numActiveWindow = 5;
                    DailySchedule.CreateWindow();
                    Manager.windowsList[5] = Manager.windowsList[6];
                    Manager.windowsList.RemoveAt(6);
                    Console.Clear();
                    Manager.windowsList[Manager.numActiveWindow].Draw(true);
                    Manager.ButtonSelection();
                    break;
                default:
                    for(int i = 0; i< 4; i++)
                        Console.WriteLine("NEVERN0");
                    Console.ReadLine();
                    break;
            }
        }
        
        public static void Main(string[] args)
        {
            Console.CursorVisible = false;
            
            Authorization.CreateWindow();
            Registration.CreateWindow();
            Welcome.CreateWindow();
            WeeklySchedule.CreateWindow();
            Patients.CreateWindow();
            DailySchedule.CreateWindow();
            
            while (true)
            {
                DrawActivateWindow(ref name);;
            }
        }
    }
}
