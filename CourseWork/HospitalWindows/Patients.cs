using System;
using System.IO;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class Patients
    {
        public static void CreateWindow()
        {
            int l = 60;
            int h = 20;

            var main = new Window(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                    "Patient", true));
            Manager.windowsList.Add(main);
            
            TextInput fullName = new TextInput(13, 0, 3, 39);
            main.Pack(fullName);
            Label lfio = new Label(2, 1, 1, 3, "ФИО");
            main.Pack(lfio);

            TextInput startTime = new TextInput(13, 3, 3, 9);
            Label lmail = new Label(2, 4, 2, 6, "Время начала");
            main.Pack(startTime);
            main.Pack(lmail);

            TextInput endTime = new TextInput(13, 6, 3, 9);
            Label lpass = new Label(2, 7, 2, 9, "Время    окончания");
            main.Pack(endTime);
            main.Pack(lpass);

            var back = new Button(10, 14, 3, 5, "Назад");
            back.OnClick((() =>
            {
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            }));
            main.Pack(back);
            
            var accept = new Button(50-2-2, 14, 3, 10, "Ок");
            accept.OnClick(() =>
            {
                StreamWriter writeInFile = new StreamWriter("PatientsData.txt", true);
                writeInFile.WriteLine(Authorization.fullName);
                writeInFile.WriteLine(WeeklySchedule.dayName);
                writeInFile.Close();
                
                fullName.SaveText("PatientsData.txt");
                startTime.SaveText("PatientsData.txt");
                endTime.SaveText("PatientsData.txt");
                
                
                WeeklySchedule.dayName = "Пн";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            main.Pack(accept);
        }
    }
}