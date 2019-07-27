using System;
using System.Linq;

namespace InvoicingSystem_XML.Logic.Extensions {
    public static class StringExtensions {
        public static T ParseEnum<T> (this string value) => (T)Enum.Parse(typeof(T), value, true);

        public static bool IsNullOrEmpty(this string value) => value is null || value == string.Empty;

        public static bool ContainsDigit(this string value) => value.Any(c => int.TryParse(c.ToString(), out _));
    }
}
