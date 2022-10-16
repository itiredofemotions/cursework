using System;

namespace CourseWork.WindowParts
{
    public class Button: View
    {
        public string _text;
        
        public Button(int x, int y, int h, int l, string text) : base(x, y, h, l)
        {
            _text = text;
        }

        public override void DrawView(bool active)
        {
            if (!active)
            {
                Console.SetCursorPosition(_x, _y);
                Console.Write(_text);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(_x, _y);
                Console.Write(_text);
                Console.ResetColor();
            }
        }
        
        public delegate void Operation();
        private Operation p;

        public void click()
        {
            p();
        }

        public void OnClick(Operation op)
        {
            p = op;
        }
    }
}