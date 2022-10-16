using System;
using System.Collections.Generic;

namespace CourseWork.WindowParts
{
    public class Window: Container
    {
        private Header _header;
        
        public Window(int x, int y, int h, int l, Header header) : base(x, y, h, l)
        {
            _header = header;
        }
        
        public void MoveWindow(int x, int y)
        {
            if (_x + x > 0 & _y + y > 0 & _x + x < Console.WindowWidth - _l & _y + y < Console.WindowHeight)
            {
                _x += x;
                _y += y;
                _header._x += x;
                _header._y += y;

                
                if (_elementsList.Count > 0)
                {
                    foreach (var element in _elementsList)
                    {
                        element.MoveView(x, y);
                    }
                }
            }
        }

        private void DrawBoarders()
        {
            Drawer.DrawAll(_x, _y, _l, _h);
        }
        
        public void Draw(bool active)
        {
            if (!active)
            {
                DrawBoarders();
                _header.Draw();
                if (_elementsList.Count > 0) DrawViews();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                DrawBoarders();
                _header.Draw();
                Console.ResetColor();
                if (_elementsList.Count > 0) DrawViews();
            }
        }
    }
}
