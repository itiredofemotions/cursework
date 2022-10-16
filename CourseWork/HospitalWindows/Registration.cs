using System;
using System.Collections.Generic;
using System.IO;
using CourseWork.WindowParts;

namespace CourseWork.HospitalWindows
{
    public abstract class Registration
    {
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
                new Header(Console.WindowWidth / 2 - l / 2 - 1, Console.WindowHeight / 2 - h / 2 - 1, h, l, "Registration", true));

            TextInput fullNameBox = new TextInput(12, 0, 3, 40);
            Label fullNameLabel = new Label(2, 1, 1, 3, "ФИО");
            TextInput mailBox = new TextInput(12, 3, 3, 40);
            Label mailLabel = new Label(2, 4, 1, 4, "Mail");
            TextInput passwordBox = new TextInput(12, 6, 3, 40);
            Label passwordLabel = new Label(2, 7, 1, 7, "Пароль");
            TextInput repitPasswordBox = new TextInput(12, 9, 3, 40);
            Label repitPasswordLabel = new Label(2, 10, 2, 6, "Под.  пароль");
            Button back = new Button(10, 14, 3, 5, "Назад");
            Button enter = new Button(50 - 2 - 2, 14, 3, 10, "Ок");
            
            Label exception1 = new Label(24, 12, 1, 20, "Пароли не совпадают");
            Label exception2 = new Label(28, 12, 1, 20, "Нет ФИО");
            Label exception3 = new Label(26, 12, 1, 20, "Нет Mail");
            Label exception4 = new Label(24, 12, 1 , 20, "Нет пароля");
            Label exception5 = new Label(24, 12, 1, 20, "Короткий пароль");
            Label exception6 = new Label(18, 12, 1, 30, "Этот Mail уже зарегистрирован");
            
            back.OnClick(() =>
            {
                Program.name = "auth";
                Program.DrawActivateWindow(ref Program.name);
            });
            
            enter.OnClick(() =>
            {
                if (fullNameBox._text != null)
                {
                    main.UnPack(exception2);
                    if (mailBox._text != null)
                    {
                        main.UnPack(exception3);
                        if (!usersData.Contains(mailBox._text))
                        {
                            main.UnPack(exception6);
                            if (passwordBox._text != null)
                            {
                                main.UnPack(exception4);
                                if (passwordBox._text.Length >= 6)
                                {
                                    main.UnPack(exception5);
                                    if (passwordBox._text == repitPasswordBox._text)
                                    {
                                        main.UnPack(exception3);

                                        fullNameBox.SaveText("UsersData.txt");
                                        mailBox.SaveText("UsersData.txt");
                                        passwordBox.SaveText("UsersData.txt");
                                        
                                        Authorization.CreateWindow();
                                        Manager.windowsList[0] = Manager.windowsList[6];
                                        Manager.windowsList.RemoveAt(6);


                                        Program.name = "auth";
                                        Program.DrawActivateWindow(ref Program.name);
                                    }
                                    else
                                    {
                                        main.Pack(exception1);
                                    }
                                }
                                else
                                {
                                    main.Pack(exception5);
                                }
                            }
                            else
                            {
                                main.Pack(exception4);
                            }
                        }
                        else
                        {
                            main.Pack(exception6);
                        }
                    }
                    else
                    {
                        main.Pack(exception3);
                    }
                }
                else
                {
                        main.Pack(exception2);
                }
            });
            
            main.Pack(fullNameBox);
            main.Pack(fullNameLabel);
            main.Pack(mailBox);
            main.Pack(mailLabel);
            main.Pack(passwordBox);
            main.Pack(passwordLabel);
            main.Pack(repitPasswordBox);
            main.Pack(repitPasswordLabel);
            main.Pack(enter);
            main.Pack(back);
            Manager.windowsList.Add(main);

        }
    }
}