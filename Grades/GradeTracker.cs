using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrades(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

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

        protected string _name;
    }
}
