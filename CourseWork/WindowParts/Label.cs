using System;

namespace CourseWork.WindowParts
{
    public class Label: View
    {
        public string _text;

        public Label(int x, int y, int h, int l, string text) : base(x, y, h, l)
        {
            _text = text;
        }

        private void WriteText()
        {
            int index = 0;

            for (int i = 0; i < _h; i++)
            {
                Console.SetCursorPosition(_x, _y + i);
                for (int j = 0; j < _l; j++)
                {
                    if (index < _text.Length)
                    {
                        Console.Write(_text[index]);
                        index++;
                    }
                    else break;
                }

                if (index >= _text.Length) break;
            }
        }

        public override void DrawView(bool active)
        {
            WriteText();
            //Console.SetCursorPosition(_x, _y);
            //Console.Write(_text);
        }
    }
}