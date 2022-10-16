using System;
using System.Collections.Generic;
using System.IO;

namespace CourseWork.WindowParts
{
    public class ReadWrite
    {
        private static string path = "D:/JetBrains/JetBrains Rider 2021.3.3/projects/fefu/CourseWork/dataName.txt";
        public static void yes()
        {
            StreamWriter sw = new StreamWriter(path);
            sw.WriteLine("sdgffdgfd");
        }
    }
    
    
}