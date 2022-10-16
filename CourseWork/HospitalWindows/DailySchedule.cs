using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class DailySchedule
    {
        public static void CreateWindow()
        {
            WeeklySchedule.dataPatients.Clear();
            using (StreamReader read = new StreamReader("PatientsData.txt"))
            {
                string line;
                while ((line = read.ReadLine()) != null) WeeklySchedule.dataPatients.Add(line);
            }
            
            List<Label> endTimeList = new List<Label>();
            List<Label> starTimeList = new List<Label>();
            List<Label> fullNameList = new List<Label>();
            List<Button> deleteButtons = new List<Button>();
            List<Button> changeButtons = new List<Button>();

            int l = 60;
            int h = 19;

            var main = new Window(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                    "DailySchedule", true));
            Button create = new Button(44, 0, 0, 0, "Добавить");
            Button back = new Button(6, 0, 0, 0, "Назад");
            Label lane = new Label(0, 1, 1, 60, "----------------------------------------------------------");
            Label label = new Label(19, 0, 2, 20, $"Расписание на {WeeklySchedule.dayName}");
            
            back.OnClick(() =>
            {
                
                WeeklySchedule.CountPatients();
                WeeklySchedule.CreateWindow();
                Manager.windowsList[3] = Manager.windowsList[6];
                Manager.windowsList.RemoveAt(6);
                Program.name = "week";
                Program.DrawActivateWindow(ref Program.name);
            });

            create.OnClick(() =>
            {
                Program.name = "pati";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            
            switch (WeeklySchedule.dayName)
            {
                case "Пн":
                    for (int i = 0; i < WeeklySchedule.dataPatients.Count; i += 4)
                    {
                        starTimeList.Add(new Label(2, 3 + i/2, 1, 8, WeeklySchedule.dataPatients[i + 2] + " - "));
                        endTimeList.Add(new Label(10, 3 + i/2, 1, 8, WeeklySchedule.dataPatients[i + 3] + " - "));
                        fullNameList.Add(new Label(18, 3 + i/2, 1, 20, WeeklySchedule.dataPatients[i + 1]));
                        changeButtons.Add(new Button(41, 3 + i/2, 0, 0, "Изменить"));
                        deleteButtons.Add(new Button(52, 3 + i/2, 0, 0, "X"));
                    }
                    break;
                default:
                    break;
            }

            foreach (var element in starTimeList) main.Pack(element);
            foreach (var element in endTimeList) main.Pack(element);
            foreach (var element in fullNameList) main.Pack(element);
            foreach (var element in deleteButtons)
            {
                main.Pack(element);
                element.OnClick(() =>
                {
                    string text = "";
                    foreach (var name in fullNameList)
                    {
                        if (element._y == name._y)
                        {
                            text = name._text;
                        }
                    }

                    List<string> tempList = new List<string>();

                    tempList = File.ReadAllLines("PatientsData.txt").ToList();
                    for (int i = 0; i < tempList.Count; i ++)
                    {
                        if (tempList[i] == text)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                tempList.RemoveAt(i-1);
                            }
                        }
                    }
                    File.WriteAllLines("PatientsData.txt", tempList);
                });
            }
            
            foreach (var element in changeButtons)
            {
                main.Pack(element);
                
                element.OnClick(() =>
                {
                    string text = "";
                    int x = element._x - 40;
                    int y = element._y;
                    foreach (var name in fullNameList)
                    {
                        if (element._y == name._y)
                        {
                            text = name._text;
                            x = name._x;
                            y = name._y;
                        }
                    }

                    List<string> tempList = new List<string>();
                    
                    tempList = File.ReadAllLines("PatientsData.txt").ToList();
                    for (int i = 0; i < tempList.Count; i ++)
                    {
                        if (tempList[i] == text)
                        {
                            Console.CursorVisible = true;
                            Console.SetCursorPosition(x - 16, y);
                            tempList[i + 1] = Console.ReadLine();
                            Console.SetCursorPosition(x - 8, y);
                            tempList[i + 2] = Console.ReadLine();
                            Console.SetCursorPosition(x, y);
                            tempList[i] = Console.ReadLine();
                            Console.CursorVisible = false;
                        }
                    }
                    File.WriteAllLines("PatientsData.txt", tempList);
                });
            }
            
            Manager.windowsList.Add(main);
            main.Pack(lane);
            main.Pack(label);
            main.Pack(create);
            main.Pack(back);
        }
    }
}