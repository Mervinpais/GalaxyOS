using Cosmos.System.Graphics;
using System;
using System.Drawing;
using System.IO;
using Sys = Cosmos.System;

namespace GalaxyOS
{
    public class Kernel : Sys.Kernel
    {
        Canvas canvas;

        Sys.FileSystem.CosmosVFS fs = new Sys.FileSystem.CosmosVFS();
        protected override void BeforeRun()
        {
            Console.Clear();
            Console.WriteLine("Cosmos loaded/booted successfully.");
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
            Console.WriteLine("GalaxyOS Booted successfully! :D\n");
            Console.Beep();
            if (!File.Exists(@"0:\readme.txt"))
            {
                File.WriteAllText(@"0:\readme.txt", "Use the \'help\' to get all commands and also use \'intro\' to get an intro");
            }
        }

        protected override void Run()
        {
            //overhead_message.OverHead_Message();
            Console.Write(">");
            string input = Console.ReadLine();
            if (input == "")
            {
                // Do nothing
            }
            else if (input.StartsWith("echo"))
            {
                Console.WriteLine(input.Substring(4).TrimStart());
            }
            else if (input == "dir" || input == "ls")
            {
                var directory_list = Directory.GetFiles(@"0:\");
                try
                {
                    foreach (var file in directory_list)
                    {
                        try
                        {
                            var content = File.ReadAllText(file);
                        }
                        catch { }
                        Console.WriteLine("File name: " + file);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
            else if (input.StartsWith("read"))
            {
                input = input.Substring(4).TrimStart();
                if (!input.StartsWith("0:\\"))
                {
                    input = "0:\\" + input;
                }

                Console.WriteLine("=== " + input + " ===\n");

                try
                {
                    Console.WriteLine(File.ReadAllText(input));
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("!File Not Found!");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.WriteLine("\n==== END OF FILE ====");
            }
            else if (input == "help")
            {
                Console.Clear();
                string[] help = {
                    "help - help message",
                    "dir, ls - displays directory files",
                    "shutdown - shuts down/turn off the computer",
                    "restart - turns off the computer, and then turns back on again",
                    "read - reads file specified in arguments",
                    "       Syntax; read <fileLocation>",
                    "text - Loads inbuilt text editor"
                };
                Console.Write(string.Join("\n", help));
            }
            else if (input == "text")
            {
                Appilcations.os_textEditor.Load();
            }
            else if (input == "shutdown")
            {
                Console.WriteLine("PLEASE PRESS ENTER TO CONFIRM SHUTDOWN\nOR PRESS ANY OTHER KEY TO STOP");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Enter) { Sys.Power.Shutdown(); }
                else { Console.WriteLine(); }
            }
            else if (input == "reboot")
            {
                Console.WriteLine("PLEASE PRESS ENTER TO CONFIRM RESTART\nOR PRESS ANY OTHER KEY TO STOP");
                ConsoleKeyInfo consoleKey = Console.ReadKey();
                if (consoleKey.Key == ConsoleKey.Enter) { Sys.Power.Reboot(); }
                else { Console.WriteLine(); }
            }
            else if (input == "gui_load")
            {
                try
                {
                    canvas = FullScreenCanvas.GetFullScreenCanvas(new Mode(640, 480, ColorDepth.ColorDepth32));
                    canvas.Clear(Color.Blue);
                    // A red Point
                    canvas.DrawPoint(Color.Red, 69, 69);

                    // A MintCream diagonal line
                    canvas.DrawLine(Color.MintCream, 250, 150, 400, 250);

                    // A PaleVioletRed rectangle
                    canvas.DrawFilledRectangle(Color.PaleVioletRed, 350, 350, 80, 60);

                    // A LimeGreen rectangle
                    canvas.DrawRectangle(Color.LimeGreen, 450, 450, 80, 60);

                    // A bitmap
                    //canvas.DrawImage(bitmap, 100, 120, 200, 200);

                    canvas.Display(); // Required for something to be displayed when using a double buffered driver

                    Console.ReadKey();

                    canvas.Disable();
                }
                catch (Exception e)
                {
                    mDebugger.Send("Exception occurred: " + e.Message);
                    Sys.Power.Shutdown();
                }
            }
            else
            {
                Console.WriteLine("Command \'" + input + "\' is not a command");
            }

        }
    }
}