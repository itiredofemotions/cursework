using System;
using System.Collections.Generic;
using System.IO;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class Authorization
    {
        
        public static string fullName; 
        public static void CreateWindow()
        {
            List<string> usersData = new List<string>();
            
            using (StreamReader read = new StreamReader("UsersData.txt"))
            {
                string line;
                while ((line = read.ReadLine()) != null) usersData.Add(line);
            }
            
            int l = 60;
            int h = 20;

            var main = new Window(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l,
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l, "Authorization", true));
            
            TextInput boxMail = new TextInput(12, 3, 3, 40);
            Label labelMail = new Label(2, 4, 1, 4, "Mail");
            TextInput boxPassword = new TextInput(12, 6, 3, 40);
            Label labelPasssword = new Label(2, 7, 1, 7, "Пароль");
            Button registation = new Button(10, 13, 3, 5, "Регистрация");
            Button enter = new Button(44, 13, 3, 10, "Войти");

            Label exception1 = new Label(20, 9, 1, 23, "Mail не зарегистрирован");
            Label exception2 = new Label(24, 9, 1, 20, "Неверный пароль");
            Label exception3 = new Label(24, 9, 1, 20, "Есть пустые поля");
            
            registation.OnClick(() =>
            {
                Program.name = "regi";
                Program.DrawActivateWindow(ref Program.name);
            });

            enter.OnClick(() =>
            {
                
                if (boxMail._text != null && boxPassword._text != null)
                {
                    main.UnPack(exception3);
                    for (int i = 1; i < usersData.Count; i += 3)
                    {
                        if (boxMail._text == usersData[i])
                        {
                            main.UnPack(exception1);
                            if (boxPassword._text == usersData[i + 1])
                            {
                                
                                main.UnPack(exception2);
                            
                                fullName = usersData[i - 1];

                                Welcome.CreateWindow();
                                Manager.windowsList[2] = Manager.windowsList[6];
                                Manager.windowsList.RemoveAt(6);

                                Program.name = "welc";
                                Program.DrawActivateWindow(ref Program.name);
                            }
                            else
                            {
                                main.Pack(exception2);
                            }
                        }
                        else
                        {
                            main.Pack(exception1);
                        }
                    }
                }
                else
                {
                    main.Pack(exception3);
                }
            });
            
            Manager.windowsList.Add(main);
            main.Pack(boxMail);
            main.Pack(labelMail);
            main.Pack(boxPassword);
            main.Pack(labelPasssword);
            main.Pack(enter);
            main.Pack(registation);
        }
    }
}