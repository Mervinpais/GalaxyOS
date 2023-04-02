using System;

namespace GalaxyOS.Appilcations
{
    public class os_textEditor
    {
        public static void Load(string file = null)
        {
            Console.Clear();

            while (true)
            {
                // Show the cursor
                Console.Write("");
                //return;
                // Wait for the user to press a key
                try
                {
                    //string[] file_contents = { "" };
                    // Handle the key press
                    while (true)
                    {
                        string line = Console.ReadLine();
                        //file_contents = file_contents.Concat(new string[] { line }).ToArray();

                        if (line.Contains("\n"))
                        {
                            Console.WriteLine();
                        }
                        else if (line.Contains(@"\s"))
                        {
                            Console.Clear();
                            Console.WriteLine("Please Enter a Name to save your file");
                            Console.Write(">>>");
                            string fileName = Console.ReadLine();
                            //File.WriteAllLines(fileName, file_contents);
                            return;
                        }
                        else if (line.Contains(@"\x"))
                        {
                            Console.Clear();
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.Clear();
                    SystemErrorHandler.SysError(ex);
                    overhead_message.OverHead_Message("SYSTEM ERROR, PLEASE SHUTDOWN AS SOON AS POSSIBLE");
                    return;
                }
            }
        }
    }
}
