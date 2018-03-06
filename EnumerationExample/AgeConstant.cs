using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationExample
{
    public class AgeConstant
    {
        private readonly string value;
//        private readonly bool mayBuyAdultStuff;

        private AgeConstant(string value)
        {
            this.value = value;
        }

        public string GetStuff()
        {
            return "a";
        }

        public static readonly AgeConstant Under18 = new AgeConstant("Under18");
        public static readonly AgeConstant Age19To30 = new AgeConstant("Age19To30");
        public static readonly AgeConstant Age31To50 = new AgeConstant("Age31To50");
        public static readonly AgeConstant Over50 = new AgeConstant("Over50");

        // String representation ✓
        // Int representation ~ Possible
        // Type safety ✓
        // Iterateable ✓
        // Ordered ✓
        // Any kind of attribute ✓

        public static readonly IReadOnlyList<AgeConstant> Values = typeof(AgeConstant).GetFields()
            .Where(member => member.FieldType == typeof(AgeConstant))
            .Select(member => (AgeConstant) member.GetValue(new object[] { })).ToList();

        public static AgeConstant Parse(string parameterName)
        {
            return Values.First(p => p.value.Equals(parameterName, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}