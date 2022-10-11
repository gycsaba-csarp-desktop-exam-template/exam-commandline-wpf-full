using Kreta.Models.DataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;


namespace Kreta.Models.Tests
{
    [TestClass()]
    public class AddressTests
    {
        [TestMethod()]
        public void EqualsTestIsNull()
        {
            Address address1 = new Address(1, "Szeged", "Utca 1.a", 6722);

            bool actual = address1.Equals(null);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestEverythingIsDifferent()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2, "Budapest", "Utca 23.a", 1024);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        // 1 same
        [TestMethod()]
        public void EqualsTestCityIsSame()
        {
            Address address1 = new Address(1, "Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2, "Szeged", "Utca 23.a", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestStreetIsSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2,"Budapest", "Utca 1.a", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestPostCodeIsSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2, "Budapest", "Utca 1.b", 6722 );

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestIdIsSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Budapest", "Utca 1.b", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        // 2 same
        [TestMethod()]
        public void EqualsTestCityAndStreetAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2,"Szeged", "Utca 1.a", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestCityAndPostCodeAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2,"Szeged", "Utca 1.b", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestCityAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Szeged", "Utca 1.b", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestStreetAndPostCodeAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2,"Budapest", "Utca 1.a", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestStreetAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Budapest", "Utca 1.a", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestPostCodeAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1, "Budapest", "Utca 1.b", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        // 3 same
        [TestMethod()]
        public void EqualsTestCityAndStreetAndPostCodeAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(2,"Szeged", "Utca 1.a", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestCityAndStreetAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Szeged", "Utca 1.a", 6724);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestCityAndPostCodeAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Szeged", "Utca 1.b", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        [TestMethod()]
        public void EqualsTestStreetAndPostCodeAndIdAreSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Budapest", "Utca 1.a", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsFalse(actual);
        }

        // 4 same
        [TestMethod()]
        public void EqualsTestAddressesAreEqual()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);
            Address address2 = new Address(1,"Szeged", "Utca 1.a", 6722);

            bool actual = address1.Equals(address2);

            Assert.IsTrue(actual);
        }

        // reference
        [TestMethod()]
        public void EqualsTestReferenceIsSame()
        {
            Address address1 = new Address(1,"Szeged", "Utca 1.a", 6722);

            bool actual = address1.Equals(address1);

            Assert.IsTrue(actual);
        }
    }
}