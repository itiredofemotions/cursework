using System;
using System.Collections.Generic;
using System.IO;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class WeeklySchedule
    {
        public static List<string> dataPatients = new List<string>();
        public static string dayName;
        private static int[] numberPatient = new int[7];

        public static void CreateWindow()
        {
            CountPatients();
            int l = 60;
            int h = 19;
            
            var main = new Window(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1 , h, l,
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l, "WeeklySchedule", true));
            Manager.windowsList.Add(main);

            Label header = new Label(35, 0, 2, 20, "Расписание на неделю");
            main.Pack(header);
            
            Label monday = new Label(1, 1, 1, 40, "Понедельник");
            main.Pack(monday);
            Button buttonMonday = new Button(24, 1, 0, 0, "Показать");
            main.Pack(buttonMonday);
            Label countMonday = new Label(17, 1, 1, 30, $"{numberPatient[0]}");
            main.Pack(countMonday);
            
            Label tuesday = new Label(1, 3, 1, 40, "Вторник");
            main.Pack(tuesday);
            Button buttonTuesday = new Button(24, 3, 0, 0, "Показать");
            main.Pack(buttonTuesday);
            Label countTuesday = new Label(17, 3, 1, 30, $"{numberPatient[1]}");
            main.Pack(countTuesday);

            Label wednesday = new Label(1, 5, 1, 40, "Среда");
            main.Pack(wednesday);
            Button buttonWednesday = new Button(24, 5, 0, 0, "Показать");
            main.Pack(buttonWednesday);
            Label countWednesday = new Label(17, 5, 1, 30, $"{numberPatient[2]}");
            main.Pack(countWednesday);
            
            
            Label thursday = new Label(1, 7, 1, 40, "Четверг");
            main.Pack(thursday);
            Button buttonThursday = new Button(24, 7, 0, 0, "Показать");
            main.Pack(buttonThursday);
            Label countThursday = new Label(17, 7, 1, 30, $"{numberPatient[3]}");
            main.Pack(countThursday);
            
            Label friday = new Label(1, 9, 1, 40, "Пятница");
            main.Pack(friday);
            Button buttonFriday = new Button(24, 9, 0, 0, "Показать");
            main.Pack(buttonFriday);
            Label countFriday = new Label(17, 9, 1, 30, $"{numberPatient[4]}");
            main.Pack(countFriday);
            
            Label suturday = new Label(1, 11, 1, 40, "Суббота");
            main.Pack(suturday);
            Button buttonSuturday = new Button(24, 11, 0, 0, "Показать");
            Label countSuturday = new Label(17, 11, 1, 30, $"{numberPatient[5]}");
            main.Pack(countSuturday);
            main.Pack(buttonSuturday);
            
            Label sunday = new Label(1, 13, 1, 40, "Восресенье");
            main.Pack(sunday);
            Button buttonSunday = new Button(24, 13, 0, 0, "Показать");
            main.Pack(buttonSunday);
            Label countSunday = new Label(17, 13, 1, 30, $"{numberPatient[6]}");
            main.Pack(countSunday);
            
            buttonMonday.OnClick(() =>
            {
                dayName = "Пн";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonTuesday.OnClick(() =>
            {
                dayName = "Вт";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonWednesday.OnClick(() =>
            {
                dayName = "Ср";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonThursday.OnClick(() =>
            {
                dayName = "Чт";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonFriday.OnClick(() =>
            {
                dayName = "Пт";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonSuturday.OnClick(() =>
            {
                dayName = "Сб";
                Program.name = "dail";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            buttonSunday.OnClick(() =>
            {
                dayName = "Вс";
                Program.name = "dail";
                
                Program.DrawActivateWindow(ref Program.name);
            });


            Button back = new Button(42, 14, 0, 0, "Назад");
            main.Pack(back);
            
            back.OnClick(() =>
            {
                Program.name = "welc";
                Program.DrawActivateWindow(ref Program.name);
            });
        }

        public static void CountPatients()
        {
            dataPatients.Clear();
            for (int i = 0; i < 7; i++)
            {
                numberPatient[i] = 0;
            }
            using (StreamReader read = new StreamReader("PatientsData.txt"))
            {
                string line;
                while ((line = read.ReadLine()) != null) dataPatients.Add(line);
            }

            for(int i = 0; i < dataPatients.Count; i += 4)
            {
                switch (dataPatients[i])
                {
                    case "Пн":
                        numberPatient[0]++;
                        break;
                    case "Вт":
                        numberPatient[1]++;
                        break;
                    case "Ср":
                        numberPatient[2]++;
                        break;
                    case "Чт":
                        numberPatient[3]++;
                        break;
                    case "Пт":
                        numberPatient[4]++;
                        break;
                    case "Сб":
                        numberPatient[5]++;
                        break;
                    case "Вс":
                        numberPatient[6]++;
                        break;
                    case " ":
                        break;
                    default:
                        Console.WriteLine("Weekly.CountDays neverno");
                        Console.WriteLine( dataPatients[i]);
                        Console.ReadKey();
                        break;
                }
            }
            
        }
    }
}