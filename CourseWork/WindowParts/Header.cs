using System;

namespace CourseWork.WindowParts
{
    public class Header: View
    {
        private bool _hide;
        private string _litletext;
        
        public Header(int x, int y, int h, int l, string litletext, bool hide): base(x, y, h, l)
        {
            _hide = hide;
            _litletext = litletext;
        }

        public void Draw()
        {
            Console.SetCursorPosition(_x + 1,_y + 2);
            for (int i = 0; i < _l - 2; i++)
                Console.Write("-");
            
            
            Console.SetCursorPosition(_x + 2, _y + 1);
            Console.WriteLine(_litletext);
            
            Console.SetCursorPosition(_x + _l - 3, _y + 1);
            Console.Write("_");
        }
    }
}