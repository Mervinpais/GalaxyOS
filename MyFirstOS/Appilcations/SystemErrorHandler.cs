using System;

namespace GalaxyOS.Appilcations
{
    public class SystemErrorHandler
    {
        public static void SysError(Exception ex = null)
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            if (ex != null)
            {
                Console.WriteLine(ex.Message);
            }
            string[] errorMessage = {
                        "",
                        "",
                        "",
                        "==              A SYSTEM ERROR OCCURED",
                        "   (           PLEASE SHUTDOWN AS SOON AS POSSIBLE TO PREVENT CORRUPTION",
                        "==            ",
                        ""
                    };
            Console.WriteLine(string.Join(Environment.NewLine, errorMessage));
        }
    }
}
