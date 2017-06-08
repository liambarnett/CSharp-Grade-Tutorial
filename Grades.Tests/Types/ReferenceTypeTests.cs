using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades.Tests.Types
{
    [TestClass]
    public class TypeTests
    {

        [TestMethod]
        public void UsingArrays()
        {
            float[] grades;
            grades = new float[3];

            string[] subject;
            subject = new string[3];

            AddGrades(grades);

            Assert.AreEqual(89.1f, grades[1]);
            Assert.AreEqual(20.1f, grades[2]);
        }

        private void AddGrades(float[] grades)
        {
            grades[1] = 89.1f;
            grades[2] = 20.1f;
        }

        [TestMethod]
        public void UppercaseString()
        {
            string name = "liam";
            name = name.ToUpper();

            Assert.AreEqual("LIAM", name);
        }

        [TestMethod]
        public void AddDaysToDateTime()
        {
            DateTime date = new DateTime(2015, 1, 1);
            date = date.AddDays(1);

            Assert.AreEqual(2, date.Day);
        }

        [TestMethod]
        public void ValueTypesPassedByValue()
        {
            int x = 46;
            IncrementNumber(ref x);
            Assert.AreEqual(47, x);
        }

        private void IncrementNumber(ref int number)
        {
            number += 1;
        }

        [TestMethod]
        public void ReferenceTypesPassedByValue()
        {
            GradeBook book1 = new GradeBook();
            GradeBook book2 = book1;

            GiveBookName(book2);
            Assert.AreEqual("A GradeBook", book1.Name);
        }

        private void GiveBookName(GradeBook book)
        {
           // book = new GradeBook();
            book.Name = "A GradeBook";
        }

        [TestMethod]
        public void StringComparisons()
        {
            string name1 = "Scott";
            string name2 = "scott";

            bool result = String.Equals(name1,name2, StringComparison.InvariantCultureIgnoreCase);
            Assert.IsTrue(result);
  
        }

        [TestMethod]
        public void IntVariablesHoldAValue()
        {
            int x1 = 100;
            int x2 = x1;

            x1 = 4;
            Assert.AreNotEqual(x1, x2);
        }

        [TestMethod]
        public void GradeBookVariablesHoldAReference()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            g1 = new GradeBook();

            g1.Name = "Liam's gradebook";
            Assert.AreNotEqual(g1.Name, g2.Name);
        }
    }
}
