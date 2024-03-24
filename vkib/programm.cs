using System;
using System.Windows;

namespace vk1
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            Application app = new Application();
            app.Run(new LoginWindow()); 
        }
    }
}
