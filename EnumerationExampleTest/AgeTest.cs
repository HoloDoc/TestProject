using System;
using System.ComponentModel;
using System.Linq;
using EnumerationExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumerationExampleTest
{
    [TestClass]
    public class AgeTest
    {
        [TestMethod]
        public void EnumEquals()
        {
            Assert.AreEqual(Age.Under18, Age.Under18);
            Assert.AreNotEqual(Age.Under18, Age.Age19To30);
        }

        [TestMethod]
        public void EnumOrdered()
        {
            // By integer
            Assert.IsTrue(Age.Under18 < Age.Age19To30);
            Assert.IsFalse(Age.Age19To30 > Age.Age31To50);
            // By list
            string[] strings = Enum.GetNames(typeof(Age));
            Assert.IsTrue(strings.ToList().IndexOf("Under18") < strings.ToList().IndexOf("Age31To50"));
        }

        [TestMethod]
        public void EnumInterationOverValues()
        {
            foreach (object value in Enum.GetValues(typeof(Age)))
            {
                Age age = (Age) value; // No generics ☹
                Console.WriteLine("Age:" + age); // Printing string representation
                Console.WriteLine("Age as int:" + (int) age); // Printing int representation
            }
        }

        [TestMethod]
        public void EnumInterationOverString()
        {
            foreach (string value in Enum.GetNames(typeof(Age)))
            {
                Console.WriteLine("Age-String:" + value); // Printing string representation
            }
        }

        [TestMethod]
        public void EnumIntegerRepresentation()
        {
            // It is not an int
            Assert.AreNotEqual(Age.Under18, 0);
            // But you can cast it
            Assert.AreEqual((int) Age.Under18, 0);
            // But int can also be cast to Age
            Age ageZero = 0;
            Assert.AreEqual(Age.Under18, ageZero);
            Console.WriteLine("String representation of ageZero" + ageZero);
        }

        [TestMethod]
        public void TypeSafety()
        {
            int i = 14;
            Age outOfRange = (Age) i;
            PrintAge(outOfRange);
            
            // But:
            if (i is Age)
            {
                Console.WriteLine("Is age");
            }

            if (outOfRange is Age)
            {
                Console.WriteLine("Is age");
            }


            // Even worse, especially when used as field:
            Age defaultValue = default(Age);
            PrintAge(defaultValue);

            
        }

        [TestMethod]
        public void ParsingEnumFromString()
        {
            object o = Enum.Parse(typeof(Age), "Age19To30"); // No generics ☹
            Age age = (Age) o;
            Assert.AreEqual(age, Age.Age19To30);
        }

        [TestMethod]
        public void ParsingEnumFromInt()
        {
            object o = Enum.Parse(typeof(Age), "1"); // No generics ☹
            Age age = (Age)o;
            Assert.AreEqual(age, Age.Age19To30);
        }

        public void PrintAge(Age age)
        {
            Console.WriteLine("PrintAge:" + age); // Prints 14
        }
    }
}