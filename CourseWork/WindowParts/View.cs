using System;

namespace CourseWork.WindowParts
{
    public class View
    {
        public int _x;
        public int _y;
        public int _l;
        public int _h;
        public bool _hasContainer = false;

        public View(int x, int y, int h, int l)
        {
            _x = x;
            _y = y;
            _h = h;
            _l = l;
        }

        public virtual void DrawView(bool active) { }
        public void MoveView(int x, int y)
        {
            _x += x;
            _y += y;
        }
    }
}
