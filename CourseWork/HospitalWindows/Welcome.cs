using System;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class Welcome
    {
        public static void CreateWindow()
        {
            int l = 60;
            int h = 20;

            Window main = new Window(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l, "Welcome", true));
            
            var schedule = new Button(23, 10, 0, 0, "Расписание");
            Label welcome = new Label(15, 4, 1, 50, $"Добрый день {Authorization.fullName}");
            var exit = new Button(0, 15, 0, 0, "Выйти");
            
            exit.OnClick(() =>
            {
                Authorization.CreateWindow();
                Manager.windowsList[0] = Manager.windowsList[6];
                Manager.windowsList.RemoveAt(6);

                Program.name = "auth";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            schedule.OnClick(() =>
            {
                WeeklySchedule.CreateWindow();
                Manager.windowsList[3] = Manager.windowsList[6];
                Manager.windowsList.RemoveAt(6);
                
                Program.name = "week";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            Manager.windowsList.Add(main);
            main.Pack(welcome);
            main.Pack(schedule);
            main.Pack(exit);
        }
    }
}