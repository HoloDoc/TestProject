using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using EnumerationExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EnumerationExampleTest
{
    [TestClass]
    public class AgeConstantTest
    {
        [TestMethod]
        public void EnumEquals()
        {
            Assert.AreEqual(AgeConstant.Under18, AgeConstant.Under18); // Actually: Same Instance!
            Assert.AreNotEqual(AgeConstant.Under18, AgeConstant.Age19To30);
        }

        [TestMethod]
        public void EnumOrdered()
        {
            // By integer
//            Assert.IsTrue(AgeConstant.Under18 < AgeConstant.Age19To30);
//            Assert.IsFalse(AgeConstant.Age19To30 > AgeConstant.Age31To50);
            // By list
            IReadOnlyList<AgeConstant> readOnlyList = AgeConstant.Values;
            Assert.IsTrue(readOnlyList.ToList().IndexOf(AgeConstant.Under18) < readOnlyList.ToList().IndexOf(AgeConstant.Over50));
        }

        [TestMethod]
        public void EnumInterationOverValues()
        {
            foreach (AgeConstant age in AgeConstant.Values)
            {
                //AgeConstant age = (AgeConstant) value; // Is generic ☺
                Console.WriteLine("Age:" + age); // Printing string representation
//                Console.WriteLine("Age as int:" + (int) age); // Printing int representation
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

        [TestMethod]
        public void TypeSafety()
        {
            //AgeConstant outOfRange = new AgeConstant(); //safe because private
            // PrintAge(outOfRange);

            // Even worse, especially when used as field:
//            Age defaultValue = default(Age);
//            PrintAge(defaultValue);
        }

        [TestMethod]
        public void ParsingEnumFromString()
        {
            AgeConstant age = AgeConstant.Parse("Age19To302"); // Is generic ☺
            //Age age = (Age) o;
            Assert.AreEqual(age, AgeConstant.Age19To30);
        }

//        [TestMethod]
//        public void ParsingEnumFromInt()
//        {
//            object o = Enum.Parse(typeof(Age), "1"); // No generics ☹
//            Age age = (Age)o;
//            Assert.AreEqual(age, Age.Age19To30);
//        }

        public void PrintAge(AgeConstant age)
        {
            Console.WriteLine("PrintAge:" + age); // Prints 14
        }
    }
}
