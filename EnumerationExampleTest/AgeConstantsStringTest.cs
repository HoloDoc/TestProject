using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnumerationExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumerationExampleTest
{
    [TestClass]
    public class AgeConstantsStringTest
    {
        [TestMethod]
        public void EnumEquals()
        {
            Assert.AreEqual(AgeConstantsString.Under18, AgeConstantsString.Under18);
            Assert.AreNotEqual(AgeConstantsString.Under18, AgeConstantsString.Age19To30);
        }

        [TestMethod]
        public void EnumOrdered()
        {
            // By integer (NOT POSSIBLE)
            //Assert.IsTrue(AgeConstantsSimple.Under18 < AgeConstantsSimple.Age19To30);
            //Assert.IsFalse(AgeConstantsSimple.Age19To30 > AgeConstantsSimple.Age31To50);

            // By list
            IReadOnlyList<string> strings = AgeConstantsString.Values;
            Assert.IsTrue(strings.ToList().IndexOf("Under18") < strings.ToList().IndexOf("Age31To50"));
        }

        [TestMethod]
        public void EnumInterationOverValues()
        {
            foreach (string value in AgeConstantsString.Values)
            {
                Console.WriteLine("Age:" + value); // Printing string representation
                //Console.WriteLine("Age as int:" + (int)value); // Printing int representation (NOT POSSIBLE)
            }
        }

        [TestMethod]
        public void EnumInterationOverString()
        {
            foreach (string value in AgeConstantsString.Values)
            {
                Console.WriteLine("Age-String:" + value); // Printing string representation
            }
        }

//        [TestMethod]
//        public void EnumIntegerRepresentation()
//        {
//            // It is not an int
//            Assert.AreNotEqual(Age.Under18, 0);
//            // But you can cast it
//            Assert.AreEqual((int) Age.Under18, 0);
//            // But int can also be cast to Age
//            var ageZero = (Age) 0;
//            Assert.AreEqual(Age.Under18, ageZero);
//            Console.WriteLine("String representation of ageZero" + ageZero);
//        }

//        [TestMethod]
//        public void TypeSafety()
//        {
//            string outOfRange = AgeConstantsString.
//            PrintAge(outOfRange);
//
//            // Even worse, especially when used as field:
//            Age defaultValue = default(Age);
//            PrintAge(defaultValue);
//        }

//        [TestMethod]
//        public void ParsingEnumFromString()
//        {
//            object o = Enum.Parse(typeof(Age), "Age19To30"); // No generics ☹
//            Age age = (Age) o;
//            Assert.AreEqual(age, Age.Age19To30);
//        }

//        [TestMethod]
//        public void ParsingEnumFromInt()
//        {
//            object o = Enum.Parse(typeof(Age), "1"); // No generics ☹
//            Age age = (Age) o;
//            Assert.AreEqual(age, Age.Age19To30);
//        }

        public void PrintAge(string age)
        {
            Console.WriteLine("PrintAge:" + age); // Prints 14
        }
    }
}