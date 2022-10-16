using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CourseWork.WindowParts
{
    public class Container: View
    {
        protected readonly List<View> _elementsList = new List<View>();
        private int _numActiveElement;
        
        protected Container(int x, int y, int h, int l) : base(x, y, h, l) { }

        public void Pack(View element)
        {
            if (!element._hasContainer)
            {
                element._hasContainer = true;
                element._x += _x + 1;
                element._y += _y + 3;
                _elementsList.Add(element);   
            }
        }

        public void UnPack(View element)
        {
            element._hasContainer = false;
            element._x -= _x + 1;
            element._y -= _y + 3 ;
            _elementsList.Remove(element);
        }

        public void DrawViews()
        {
            foreach (var element in _elementsList)
            {
                if (element != _elementsList[_numActiveElement])
                    element.DrawView(false);
            }
            _elementsList[_numActiveElement].DrawView(true);
        }

        private void ChangeView()
        {
            if (_elementsList[(_numActiveElement + 1) % _elementsList.Count].ToString() != "CourseWork.WindowParts.Label")
            {
                _numActiveElement = (_numActiveElement + 1) % _elementsList.Count;
            }
            else
            {
                _numActiveElement = (_numActiveElement + 1) % _elementsList.Count;
                ChangeView();
            }
        }
        
        public void ButtonSelection()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.Tab:
                    ChangeView();
                    DrawViews();
                    ButtonSelection();
                    break;
                case ConsoleKey.Enter:
                    switch (_elementsList[_numActiveElement].ToString())
                    {
                        case "CourseWork.WindowParts.Button":
                            Button now = (Button)_elementsList[_numActiveElement];
                            now.click();
                            break;
                        case "CourseWork.WindowParts.TextInput":
                            TextInput text = (TextInput)_elementsList[_numActiveElement];
                            text.ReadText();
                            break;    
                    }
                    break;
                case ConsoleKey.Q:
                    Manager.ButtonSelection();
                    break;
                default:
                    ButtonSelection();
                    break;
            }
        }
    }
}