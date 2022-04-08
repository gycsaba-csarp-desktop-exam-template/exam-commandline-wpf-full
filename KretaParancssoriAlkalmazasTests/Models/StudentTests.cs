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

        [TestMethod()]
        public void CompareToTestThisBeforeObj()
        {
            Student thisStudent = new Student(1, "Kis Péter", 1);
            Student objStudent = new Student(1, "Nagy Péter", 1);

            int expected = -1;
            int actual = thisStudent.CompareTo(objStudent);
            Assert.AreEqual(expected, actual, "A this megelőzi az obj-t!");
        }

        [TestMethod()]
        public void CompareToTestThisAfterObj()
        {
            Student thisStudent = new Student(1, "Nagy Péter", 1);
            Student objStudent = new Student(1, "Kis Péter", 1);

            int expected = 1;
            int actual = thisStudent.CompareTo(objStudent);
            Assert.AreEqual(expected, actual, "A obj megelőzi az this-t!");
        }

        [TestMethod()]
        public void CompareToTestIdThisSmallerObj()
        {
            Student thisStudent = new Student(1, "Kis Péter", 1);
            Student objStudent = new Student(2, "Kis Péter", 1);

            int expected = -1;
            int actual = thisStudent.CompareTo(objStudent);
            Assert.AreEqual(expected, actual, "A this megelőzi az obj-t!");
        }

        [TestMethod()]
        public void CompareToTestIdThisBiggerObj()
        {
            Student thisStudent = new Student(2, "Kis Péter", 1);
            Student objStudent = new Student(1, "Kis Péter", 1);

            int expected = 1;
            int actual = thisStudent.CompareTo(objStudent);
            Assert.AreEqual(expected, actual, "A obj megelőzi az this-t!");
        }

        [TestMethod()]
        public void CompareToTestNotStudentObj()
        {
            Student thisStudent = new Student(2, "Kis Péter", 1);
            Subject objSubject = new Subject(1, "rossz");

            int expected = 0;
            int actual = thisStudent.CompareTo(objSubject);
            Assert.AreEqual(expected, actual, "A obj egyenlő thisel!");
        }
    }
}