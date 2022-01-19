using Alba.CsConsoleFormat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static System.ConsoleColor;

namespace CSharp.Lesson6.Task1
{
    class Program
    {
        private static LineThickness strokeRight = new LineThickness(LineWidth.None, LineWidth.None, LineWidth.Single, LineWidth.None);

        static void Main()
        {
            WelcomeScreen();
        }

        private static void WelcomeScreen()
        {
            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("Task Manager\n");
            Console.WriteLine("1) Show all processes");
            Console.WriteLine("2) Kill process by PID");
            Console.WriteLine("3) Kill process by Name");
            Console.WriteLine("4) Kill all processes by Name");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintRecords();
                    WelcomeScreen();
                    break;
                case "2":
                    KillProcessById();
                    WelcomeScreen();
                    break;
                case "3":
                    KillProcessByName();
                    WelcomeScreen();
                    return;
                case "4":
                    KillAllProcessesByName();
                    WelcomeScreen();
                    return;
                case "5":
                    return;
                default:
                    PrintError("Incorrect value. Please, try again");
                    WelcomeScreen();
                    break;
            }            
        }

        private static void PrintRecords()
        {
            var processes = Process.GetProcesses();
            PrintTable(processes);
        }

        private static void KillProcessById()
        {
            ActionWithErrorSuppress(() =>
            {
                Console.Write("Enter ID to kill: ");
                var processId = int.Parse(Console.ReadLine());
                KillProcessWithPrompt(processId);
            });
        }

        private static void KillAllProcessesByName()
        {
            ActionWithErrorSuppress(() =>
            {
                var processes = FindByName();
                if (processes.Length == 0)
                {
                    return;
                }

                foreach (var process in processes)
                {
                    KillProcess(process.Id, entireProcessTree: true);
                }
            });
        }

        private static void KillProcessByName()
        {
            ActionWithErrorSuppress(() =>
            {
                var processes = FindByName();
                if (processes.Length == 0)
                {
                    return;
                }

                var defaultValue = processes.FirstOrDefault();
                Console.Write($"Enter ID to kill. Default [{defaultValue.Id}]: ");

                var userInput = Console.ReadLine();
                var processId = string.IsNullOrWhiteSpace(userInput)
                    ? defaultValue.Id
                    : int.Parse(userInput);

                KillProcessWithPrompt(processId);
            });
        }

        private static void KillProcessWithPrompt(int processId)
        {
            Console.Write("Kill entire process tree? <y/n> ");
            switch (Console.ReadLine().ToLower())
            {
                case "yes":
                case "yep":
                case "y":
                    KillProcess(processId, entireProcessTree: true);
                    break;
                case "no":
                case "nope":
                case "n":
                    KillProcess(processId);
                    break;
                default:
                    PrintError("Error: Incorrect answer! Prease repeat again.");
                    return;
            } 
        }

        private static void KillProcess(int processId, bool entireProcessTree = false)
        {
            Process.GetProcessById(processId).Kill(entireProcessTree: entireProcessTree);
            PrintSuccess($"Process ID:[{processId}] killed successfully");
        }

        private static void ActionWithErrorSuppress(Action action)
        {
            try
            {
                action();
            }
            catch (Exception exception)
            {
                PrintError($"ERROR: {exception.Message}. Please, try again");
                return;
            }
        }

        private static Process[] FindByName()
        {
            Console.Write("Enter process name: ");
            var result = Console.ReadLine();
            var processes = Process.GetProcessesByName(result);
            if (processes.Length == 0)
            {
                PrintError("Process not found. Enter another name.");
                return new Process[] { };
            }
            PrintTable(processes);

            return processes;
        }

        private static void PrintSuccess(string message)
        {
            PrintMessage(message, Green);
        }

        private static void PrintError(string message)
        {
            Console.WriteLine(Environment.NewLine);
            PrintMessage(message, Red);
            Console.WriteLine(Environment.NewLine);
        }

        private static void PrintMessage(string errorMessage, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(errorMessage);
            Console.ForegroundColor = White;
        }

        private static void PrintTable(Process[] processes)
        {
            var strokeHeader = new LineThickness(LineWidth.None, LineWidth.Double);
            
            var document =
                new Document(
                    new Grid
                    {
                        Stroke = strokeHeader,
                        StrokeColor = DarkGray,
                        Columns =
                        {
                            new Column { Width = GridLength.Auto },
                            new Column { Width = GridLength.Auto, MaxWidth = 20 },
                            new Column { Width = GridLength.Star(1) },
                            new Column { Width = GridLength.Auto }
                        },
                        Children =
                        {
                            new Cell("Id") { Stroke = strokeHeader, Color = White },
                            new Cell("Name") { Stroke = strokeHeader, Color = White },
                            new Cell("Main Window Title") { Stroke = strokeHeader, Color = White },
                            new Cell("Private Memory") { Stroke = strokeHeader, Color = White },
                            processes.Select(process => new[] {
                                new Cell(process.Id) { Stroke = strokeRight },
                                new Cell(process.ProcessName) { Stroke = strokeRight, Color = Yellow, TextWrap = TextWrap.NoWrap },
                                new Cell(process.MainWindowTitle) { Stroke = strokeRight, Color = White, TextWrap = TextWrap.NoWrap },
                                new Cell(process.PrivateMemorySize64.ToString("n0")) { Stroke = LineThickness.None, Align = Align.Right },
                            })
                        }
                    });

            ConsoleRenderer.RenderDocument(document);
        }
    }
}
