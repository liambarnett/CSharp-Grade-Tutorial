using System;
using System.Collections.Generic;
using System.IO;
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
            IGradeTracker book = CreateGradeBook(); //create new Gradebook object

            // speak(); //methods uses an imported reference to speak at runtime

            GetBookName(book); //set the book name
            AddGrades(book);   //add grades to gradebook
            SaveGrades(book);  //save grades to file
            WriteResults(book); //write grades to console

            //outside tutorial
        //    AddSubject(book);
        //   SaveSubject(book);

            if (System.Diagnostics.Debugger.IsAttached) Console.ReadLine();
        }

        private static IGradeTracker CreateGradeBook()
        {
            return new ThrowAwayGradeBook();
        }

        private static void WriteResults(IGradeTracker book)
        {
            //Instantiate GradeStatistics object 
            GradeStatistics stats = book.ComputeStatistics();

            foreach (float grade in book) //polymorphism example using IEnumerator 
            {
                Console.WriteLine(grade);
            }

            //Write grades to console
            book.WriteGrades(Console.Out);

            WriteResult("Average", stats.AverageGrade);
            WriteResult("Highest", stats.HighestGrade);
            WriteResult("Lowest", stats.LowestGrade);
            WriteResult(stats.Description, stats.LetterGrade);
        }

        private static void speak()
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            synth.Speak("Hello! This is the GradBook program");
        }

    /*    private static void AddSubject(GradeTracker book)
        {
            book.AddSubject("Computer Science");
        }

        private static void SaveSubject(GradeTracker book)
        {
            foreach (string subject in book.Subjects)
            {
                Console.WriteLine(subject);
            }
        } */

        private static void SaveGrades(IGradeTracker book)
        {

            //Write grades to file
            using (StreamWriter outputFile = File.CreateText("grades.txt"))
            {
                book.WriteGrades(outputFile);
            }

        }

        private static void AddGrades(IGradeTracker book)
        {
            book.AddGrade(91);
            book.AddGrade(89.5f);
            book.AddGrade(75);
        }

        private static void GetBookName(IGradeTracker book)
        {
            //event subscribers
          //  book.NameChanged += OnNameChanged;

            try
            {
       //         Console.WriteLine("Enter a name");
            //    book.Name = Console.ReadLine();
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Somthing went wrong lol");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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


