// Decompiled with JetBrains decompiler
// Type: CSharp.Lesson6.Task1.Program
// Assembly: CSharp.Lesson7.Task, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 402553AE-AD9E-4A2A-9BA8-0AFA1854C28B
// Assembly location: C:\Users\ua1wc_000\Desktop\Lesson-7\Task\CSharp.Lesson7.Task\bin\Release\CSharp.Lesson7.Task.exe

using Alba.CsConsoleFormat;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace CSharp.Lesson6.Task1
{
  internal class Program
  {
    private static LineThickness strokeRight = new LineThickness(LineWidth.None, LineWidth.None, LineWidth.Single, LineWidth.None);

    private static void Main() => Program.WelcomeScreen();

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
      string str = Console.ReadLine();
      if (!(str == "1"))
      {
        if (!(str == "2"))
        {
          if (!(str == "3"))
          {
            if (!(str == "4"))
            {
              if (str == "5")
                return;
              Program.PrintError("Incorrect value. Please, try again");
              Program.WelcomeScreen();
            }
            else
            {
              Program.KillAllProcessesByName();
              Program.WelcomeScreen();
            }
          }
          else
          {
            Program.KillProcessByName();
            Program.WelcomeScreen();
          }
        }
        else
        {
          Program.KillProcessById();
          Program.WelcomeScreen();
        }
      }
      else
      {
        Program.PrintRecords();
        Program.WelcomeScreen();
      }
    }

    private static void PrintRecords() => Program.PrintTable(Process.GetProcesses());

    private static void KillProcessById() => Program.ActionWithErrorSuppress((Action) (() =>
    {
      Console.Write("Enter ID to kill and press <Enter>: ");
      Program.KillProcessWithPrompt(int.Parse(Console.ReadLine()));
    }));

    private static void KillAllProcessesByName() => Program.ActionWithErrorSuppress((Action) (() =>
    {
      Process[] byName = Program.FindByName();
      if (byName.Length == 0)
        return;
      foreach (Process process in byName)
        Program.KillProcess(process.Id);
    }));

    private static void KillProcessByName() => Program.ActionWithErrorSuppress((Action) (() =>
    {
      Process[] byName = Program.FindByName();
      if (byName.Length == 0)
        return;
      Process process = ((IEnumerable<Process>) byName).FirstOrDefault<Process>();
      Console.Write(string.Format("Enter ID to kill. Default [{0}]: ", (object) process.Id));
      string s = Console.ReadLine();
      Program.KillProcessWithPrompt(string.IsNullOrWhiteSpace(s) ? process.Id : int.Parse(s));
    }));

    private static void KillProcessWithPrompt(int processId)
    {
      Console.Write("Kill? <y/n> ");
      string lower = Console.ReadLine().ToLower();
      if (!(lower == "yes") && !(lower == "yep") && !(lower == "y"))
      {
        if (lower == "no" || lower == "nope" || lower == "n");
            Program.PrintError("Error: Incorrect answer! Prease repeat again.");
      }
      else
        Program.KillProcess(processId);
    }

    private static void KillProcess(int processId)
    {
      Process.GetProcessById(processId).Kill();
      Program.PrintSuccess(string.Format("Process ID:[{0}] killed successfully", (object) processId));
    }

    private static void ActionWithErrorSuppress(Action action)
    {
      try
      {
        action();
      }
      catch (Exception ex)
      {
        Program.PrintError("ERROR: " + ex.Message + ". Please, try again");
      }
    }

    private static Process[] FindByName()
    {
      Console.Write("Enter process name: ");
      Process[] processesByName = Process.GetProcessesByName(Console.ReadLine());
      if (processesByName.Length == 0)
      {
        Program.PrintError("Process not found. Enter another name.");
        return new Process[0];
      }
      Program.PrintTable(processesByName);
      return processesByName;
    }

    private static void PrintSuccess(string message) => Program.PrintMessage(message, ConsoleColor.Green);

    private static void PrintError(string message)
    {
      Console.WriteLine(Environment.NewLine);
      Program.PrintMessage(message, ConsoleColor.Red);
      Console.WriteLine(Environment.NewLine);
    }

    private static void PrintMessage(string errorMessage, ConsoleColor color)
    {
      Console.ForegroundColor = color;
      Console.WriteLine(errorMessage);
      Console.ForegroundColor = ConsoleColor.White;
    }

    private static void PrintTable(Process[] processes)
    {
      LineThickness lineThickness = new LineThickness(LineWidth.None, LineWidth.Double);
      object[] objArray = new object[1];
      Grid grid = new Grid();
      grid.Stroke = lineThickness;
      grid.StrokeColor = new ConsoleColor?(ConsoleColor.DarkGray);
      grid.Columns.Add((object) new Column()
      {
        Width = GridLength.Auto
      });
      grid.Columns.Add((object) new Column()
      {
        Width = GridLength.Auto,
        MaxWidth = 20
      });
      grid.Columns.Add((object) new Column()
      {
        Width = GridLength.Star(1)
      });
      grid.Columns.Add((object) new Column()
      {
        Width = GridLength.Auto
      });
      ElementCollection children1 = grid.Children;
      Cell cell1 = new Cell(new object[1]
      {
        (object) "Id"
      });
      cell1.Stroke = lineThickness;
      cell1.Color = new ConsoleColor?(ConsoleColor.White);
      children1.Add((object) cell1);
      ElementCollection children2 = grid.Children;
      Cell cell2 = new Cell(new object[1]
      {
        (object) "Name"
      });
      cell2.Stroke = lineThickness;
      cell2.Color = new ConsoleColor?(ConsoleColor.White);
      children2.Add((object) cell2);
      ElementCollection children3 = grid.Children;
      Cell cell3 = new Cell(new object[1]
      {
        (object) "Main Window Title"
      });
      cell3.Stroke = lineThickness;
      cell3.Color = new ConsoleColor?(ConsoleColor.White);
      children3.Add((object) cell3);
      ElementCollection children4 = grid.Children;
      Cell cell4 = new Cell(new object[1]
      {
        (object) "Private Memory"
      });
      cell4.Stroke = lineThickness;
      cell4.Color = new ConsoleColor?(ConsoleColor.White);
      children4.Add((object) cell4);
      grid.Children.Add((object) ((IEnumerable<Process>) processes).Select<Process, Cell[]>((Func<Process, Cell[]>) (process =>
      {
        Cell[] cellArray = new Cell[4]
        {
          new Cell(new object[1]{ (object) process.Id })
          {
            Stroke = Program.strokeRight
          },
          new Cell(new object[1]
          {
            (object) process.ProcessName
          })
          {
            Stroke = Program.strokeRight,
            Color = new ConsoleColor?(ConsoleColor.Yellow),
            TextWrap = TextWrap.NoWrap
          },
          new Cell(new object[1]
          {
            (object) process.MainWindowTitle
          })
          {
            Stroke = Program.strokeRight,
            Color = new ConsoleColor?(ConsoleColor.White),
            TextWrap = TextWrap.NoWrap
          },
          new Cell(new object[1]
          {
            (object) process.PrivateMemorySize64.ToString("n0")
          })
          {
            Stroke = LineThickness.None,
            Align = Align.Right
          }
        };
        return cellArray;
      })));
      objArray[0] = (object) grid;
      ConsoleRenderer.RenderDocument(new Document(objArray));
    }
  }
}
