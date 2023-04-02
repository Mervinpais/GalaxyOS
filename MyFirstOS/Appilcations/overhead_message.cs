using System;

namespace GalaxyOS.Appilcations
{
    public class overhead_message
    {
        public static string LastMessage { get; set; }

        public static bool MessageNotImportant { get; set; }

        public static void OverHead_Message(string message = null)
        {
            if (message == null)
            {
                if (LastMessage == null)
                {
                    return;
                }
                else
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine(LastMessage + "\n");
                }
            }
            else
            {
                LastMessage = message;
                Console.WriteLine(message + "\n");
                Console.WriteLine();
            }
            //Console.WriteLine(string.Join(Environment.NewLine, lastLines));
        }
    }
}
