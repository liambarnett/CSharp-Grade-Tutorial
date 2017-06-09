﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class GradeBook
    {

        public GradeBook()
        {
            _name = "Empty";
            grades = new List<float>();
            Subjects = new List<string>(); //public list
        }

        public GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();

            /* Avg  */
            float sum = 0;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;

            return stats;
        }

        public void WriteGrades(TextWriter destination)
        {
            for (int i = grades.Count; i > 0; i--)
            {
                destination.WriteLine(grades[i - 1]);
            }
        }

        public void AddGrade(float grade)
        {
            grades.Add(grade);
        }

        public void AddSubject(string subject)
        {
            Subjects.Add(subject);
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                while (string.IsNullOrEmpty(value)) //loops until a not null value has been input
                {
                    Console.WriteLine("Please enter a valid value");
                    value = Console.ReadLine();
                }

                if (string.IsNullOrEmpty(value)) //if null value is detected exception is thrown
                {
                    throw new ArgumentException("Name cannot be null or empty");

                }
                else if (_name != value) //if input is not equal to current value then proceed
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = _name;
                    args.NewName = value;

                    NameChanged(this, args);
                    // Console.WriteLine("test");
                }
                _name = value;
            }

        }

        public event NameChangedDelegate NameChanged;

        private string _name;

        private List<float> grades;

        public List<string> Subjects; //public list

    }
}
