using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Razor.Parser;

namespace Bit.Helpers.Console
{
    public class ConsoleCommandHelpers
    {
        public void Header(string line)
        {
            Line(line, ConsoleColor.Cyan, 1, 1);
        }

        public void Test(string title)
        {
            System.Console.Write(title + " " + new string('.', 50 - title.Length) + " ");
        }

        public void Success()
        {
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.Write("Success!\n");
            System.Console.ResetColor();
        }

        public void Failure()
        {
            System.Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write("Failed!\n");
            System.Console.ResetColor();
        }

        public void SuccessOrFailure(bool result)
        {
            if (result) Success(); else Failure();
        }

        public void Warning(string warningText = "")
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.Write("Warning! {0}\n", warningText);
            System.Console.ResetColor();
        }

        public string Question(string title)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write(title + ": ");
            System.Console.ResetColor();

            return System.Console.ReadLine();
        }

        public bool Ask(string title)
        {
            System.Console.ForegroundColor = ConsoleColor.White;
            System.Console.Write(title + " (y/n)? ");
            System.Console.ResetColor();

            var allowedKeys = new[] { ConsoleKey.Y, ConsoleKey.N };

            ConsoleKeyInfo pressedKey = default(ConsoleKeyInfo);

            while (!allowedKeys.Contains(pressedKey.Key))
            {
                pressedKey = System.Console.ReadKey(true);
            }

            System.Console.Write(pressedKey.KeyChar);
            System.Console.Write("\n");

            return pressedKey.Key == ConsoleKey.Y;
        }

        public void WaitCountdown(string message, int seconds = 3)
        {
            Break();
            System.Console.Write(message + " " + new string('.', 50 - message.Length) + " ");
            System.Console.ForegroundColor = ConsoleColor.Yellow;

            var counter = seconds*1000;
            var sleep = 1000;

            while (!System.Console.KeyAvailable && counter > 0)
            {
                System.Console.Write((counter / 1000) + " ");
                Thread.Sleep(sleep);
                counter -= sleep;
            }

            System.Console.ResetColor();
            Break();
        }

        public void Line(string format, params object[] parameters)
        {
            Line(string.Format(format, parameters));
        }

        public void Line(string line)
        {
            System.Console.WriteLine(line);
        }

        public void Line(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                Line(line);
            }
        }

        public void Break(int number = 1)
        {
            Enumerable.Range(0, number).ToList().ForEach(x => Line(string.Empty));
        }

        private void Line(string line, ConsoleColor color, int breaksBefore, int breaksAfter)
        {
            if (breaksBefore > 0) Break(breaksBefore);
            System.Console.ForegroundColor = color;
            System.Console.WriteLine(line);
            System.Console.ResetColor();
            if (breaksAfter > 0) Break(breaksAfter);
        }

        private List<int> TableColumns { get; set; }

        public void StartTable(params int[] widths)
        {
            TableColumns = widths.ToList();
        }

        public void TableHead(params string[] headers)
        {
            Header(StringsInColumns(headers));
        }

        public void TableRow(params string[] columns)
        {
            Line(StringsInColumns(columns));
        }

        private string StringsInColumns(params string[] strings)
        {
            var result = new List<string>();

            for (var i = 0; i < strings.Length; i++)
            {
                var length = TableColumns.Count <= i 
                    ? 10
                    : TableColumns[i];

                var transformed = strings[i].Length > length
                    ? strings[i].Substring(length)
                    : strings[i] + new string(' ', length - strings[i].Length);

                result.Add(transformed);
            }

            return string.Join("", result);
        }
    }
}