using System;
using System.IO;

namespace CourseWork.WindowParts
{
    public class TextInput: View
    {
        public string _text;
        

        public TextInput(int x, int y, int h, int l) : base(x, y, h, l)
        {
         
        }

        public override void DrawView(bool active)
        {
            if (!active)
            {
                Drawer.DrawAll(_x, _y, _l, _h);
                Console.SetCursorPosition(_x + 2, _y + 1);
                Console.Write(_text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Drawer.DrawAll(_x, _y, _l, _h);
                Console.SetCursorPosition(_x + 2, _y + 1);
                Console.Write(_text);
                Console.ResetColor();

            }
        }

        public void ReadText()
        {
            Console.SetCursorPosition(_x + 2, _y + 1);
            _text = Console.ReadLine();
        }

        public void SaveText(string path)
        {
            StreamWriter dataFio = new StreamWriter(path, true);
            dataFio.WriteLine(_text);
            dataFio.Close();
         
        }
    }
}