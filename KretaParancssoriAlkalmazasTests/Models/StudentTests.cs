using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kreta.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kreta.Models.Tests
{
    [TestClass()]
    public class StudentTests
    {
        [TestMethod()]
        public void CompareToTestThisEqualObj()
        {
            Student thisStudent = new Student(1, "Kis Péter", 1);
            Student objStudent = new Student(1, "Kis Péter", 1);

            int expected = 0;
            int actual = thisStudent.CompareTo(objStudent);
            Assert.AreEqual(expected, actual, "A két diák teljesen megegyezik, de a CompareTo nem nullát ad vissza!");
        }

        // Írja meg a többi tesztet
    }
}