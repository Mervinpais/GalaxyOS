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

        private readonly Bitmap bitmap = new Bitmap(10, 10,
                new byte[] { 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255,
                    23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 23, 59, 88, 255, 153, 57, 12, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 153, 57, 12, 255, 23, 59, 88, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72, 72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0,
                    255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 72, 72,
                    72, 255, 72, 72, 72, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255,
                    10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255,
                    243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148, 255, 10, 66, 148,
                    255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255,
                    0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, 0, 255, 243, 255, }, ColorDepth.ColorDepth32);
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
                try
                {
                    Console.WriteLine("=== " + input.Substring(4).TrimStart() + " ===");
                    Console.WriteLine(File.ReadAllText(input.Substring(4).TrimStart()));
                    Console.WriteLine("==== END OF FILE ====");
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("File Not Found");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (input == "help")
            {
                Console.Clear();
                Console.WriteLine("help - help message");
                Console.WriteLine("dir, ls - displays directory files");
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

                    // A GreenYellow horizontal line
                    canvas.DrawLine(Color.GreenYellow, 250, 100, 400, 100);

                    // An IndianRed vertical line
                    canvas.DrawLine(Color.IndianRed, 350, 150, 350, 250);

                    // A MintCream diagonal line
                    canvas.DrawLine(Color.MintCream, 250, 150, 400, 250);

                    // A PaleVioletRed rectangle
                    canvas.DrawRectangle(Color.PaleVioletRed, 350, 350, 80, 60);

                    // A LimeGreen rectangle
                    canvas.DrawRectangle(Color.LimeGreen, 450, 450, 80, 60);

                    // A bitmap
                    canvas.DrawImage(bitmap, 100, 150);

                    canvas.Display(); // Required for something to be displayed when using a double buffered driver

                    Console.ReadKey();
                    Sys.Power.Shutdown();
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