using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumerationExample
{
    public static class AgeConstantsString
    {
        public static readonly string Under18 = "Under18";
        public static readonly string Age19To30 = "Age19To30";
        public static readonly string Age31To50 = "Age31To50";
        public static readonly string Over50 = "Over50";

        // String representation ✓
        // Int representation ✘
        // Type safety ✘
        // Iterateable ✓
        // Ordered ~


        public static readonly IReadOnlyList<string> Values = typeof(AgeConstantsString).GetFields()
            .Where(member => member.FieldType == typeof(string))
            .Select(m => (string)m.GetValue(new object[] { })).ToList();

    }
}
