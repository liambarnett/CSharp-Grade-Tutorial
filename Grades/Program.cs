using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    class Program
    {
        static void Main(string[] args)
        {

             string _name;

        //  SpeechSynthesizer synth = new SpeechSynthesizer();
        //  synth.Speak("Hello! This is the GradBook program");

        GradeBook book = new GradeBook();

            //event subscribers
            book.NameChanged += OnNameChanged;

            //  book.Name = "Liam's gradebook";
            //  book.Name = "Lora's gradebook";

            //   Console.WriteLine(book.Name);

            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
            book.WriteGrades(Console.Out);

            book.Name = Console.ReadLine();



            GradeStatistics stats = book.ComputeStatistics();

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            Console.WriteLine("Lowest: " + stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);

            book.AddSubject("Computer Science");

            foreach (string subject in book.Subjects)
            {
                Console.WriteLine(subject);
            }

            if (System.Diagnostics.Debugger.IsAttached) Console.ReadLine();
        }

        static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine($"Grade book changing name from {args.ExistingName} to {args.NewName}");
        }

        static void WriteResult(string description, float result)
        {
            Console.WriteLine($"{description}: {result:F2}");
        }

        static void WriteResult(string description, string result)
        {
            Console.WriteLine($"{description}: {result}");
        }

        /*    static void WriteResult(string description, int result)
            {
                Console.WriteLine(description + ": " + result);
            }*/
    }
}


