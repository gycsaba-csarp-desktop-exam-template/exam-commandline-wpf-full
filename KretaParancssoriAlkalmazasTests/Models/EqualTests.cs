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
    public class EqualsStudentTests
    {
        [TestMethod()]
        public void EqualsStudentsTest()
        {
            Student student1 = new Student(1, "Kis Bence", 3);
            Student student2 = new Student(1, "Kis Bence", 3);

            bool expected = true;

            bool actual = student1.Equals(student2);

            Assert.AreEqual(expected, actual, "A két diák teljesen megegyezik. Az equals false értéket ad vissza.");
        }

        [TestMethod()]
        public void StudentsNotEqualByIdTest()
        {
            Student student1 = new Student(1, "Kis Bence", 3);
            Student student2 = new Student(2, "Kis Bence", 3);

            bool expected = false;

            bool actual = student1.Equals(student2);

            Assert.AreEqual(expected, actual, "A két diák id-ja nem egyezik meg. Az equals false értéket ad vissza.");
        }

        [TestMethod()]
        public void StudentsNotEqualByNameTest()
        {
            Student student1 = new Student(1, "Kis Imre", 3);
            Student student2 = new Student(1, "Kis Bence", 3);

            bool expected = false;

            bool actual = student1.Equals(student2);

            Assert.AreEqual(expected, actual, "A két diák neve nem egyezik meg. Az equals false értéket ad vissza.");
        }

        [TestMethod()]
        public void StudentsNotEqualByClassIDTest()
        {
            Student student1 = new Student(1, "Kis Bence", 3);
            Student student2 = new Student(1, "Kis Bence", 4);

            bool expected = false;

            bool actual = student1.Equals(student2);

            Assert.AreEqual(expected, actual, "A két diák osztálya nem egyezik meg. Az equals false értéket ad vissza.");
        }

        [TestMethod()]
        public void StudentsNotEqualByClassIDAndIDTest()
        {
            Student student1 = new Student(1, "Kis Bence", 3);
            Student student2 = new Student(2, "Kis Bence", 4);

            bool expected = false;

            bool actual = student1.Equals(student2);

            Assert.AreEqual(expected, actual, "A két diák osztálya és id-ja nem egyezik meg. Az equals false értéket ad vissza.");
        }
    }
}