using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

#pragma warning disable CS0660 // Type defines operator == or operator != but does not override Object.Equals(object o)

namespace System
{
    public struct MonthOnly : IComparable, IComparable<MonthOnly>, IEquatable<MonthOnly>, ISpanFormattable, IFormattable
    {
        private readonly DateOnly dateOnly;

        #region Properties

        public int Month => dateOnly.Month;

        public int Year => dateOnly.Year;

        #endregion

        #region Ctor

        public MonthOnly() { }

        public MonthOnly(int year, int month) => dateOnly = new DateOnly(year, month, 1);

        #endregion

        #region Public methods

        public MonthOnly AddMonths(int value) => FromDateOnly(dateOnly.AddMonths(value));

        public MonthOnly AddYears(int value) => FromDateOnly(dateOnly.AddYears(value));

        public int CompareTo(object? obj) => dateOnly.CompareTo(obj);

        public int CompareTo(MonthOnly other) => dateOnly.CompareTo(other.dateOnly);

        public bool Equals(MonthOnly other) => dateOnly.Equals(other.dateOnly);

        public bool TryFormat(Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) => dateOnly.TryFormat(destination, out charsWritten, format, provider);

        public string ToString(string? format, IFormatProvider? formatProvider) => dateOnly.ToString(format, formatProvider);

        public override string ToString() => dateOnly.ToString("yyyy-MM");

        public string ToString(string? format) => dateOnly.ToString(format);

        public string ToString(IFormatProvider? provider) => dateOnly.ToString(provider);

        public DateOnly ToDateOnly() => dateOnly;

        public DateTime ToDateTime(TimeOnly time) => dateOnly.ToDateTime(time);

        public DateTime ToDateTime(int day, TimeOnly time) => dateOnly.AddDays(day - 1).ToDateTime(time);

        public DateOnly GetLastDay() => dateOnly.AddMonths(1).AddDays(-1);

        public override int GetHashCode() => dateOnly.GetHashCode();

        #endregion

        #region Static methods

        public static MonthOnly FromDateOnly(DateOnly dateOnly)
        {
            return new MonthOnly(dateOnly.Year, dateOnly.Month);
        }

        public static MonthOnly FromDateTime(DateTime dateTime)
        {
            return new MonthOnly(dateTime.Year, dateTime.Month);
        }

        public static MonthOnly Parse(ReadOnlySpan<char> s, IFormatProvider? provider = null, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.Parse(s, provider, style);
            return CheckAndConvert(r);
        }

        public static MonthOnly Parse(string s, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.Parse(s, provider, style);
            return CheckAndConvert(r);
        }

        public static MonthOnly Parse(string s)
        {
            var r = DateOnly.Parse(s);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(string s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.ParseExact(s, formats, provider, style);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(string s, string format, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.ParseExact(s, format, provider, style);
            return CheckAndConvert(r);
        }
        public static MonthOnly ParseExact(string s, string format)
        {
            var r = DateOnly.ParseExact(s, format);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(ReadOnlySpan<char> s, string[] formats, IFormatProvider? provider, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.ParseExact(s, formats, provider, style);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(ReadOnlySpan<char> s, string[] formats)
        {
            var r = DateOnly.ParseExact(s, formats);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider = null, DateTimeStyles style = DateTimeStyles.None)
        {
            var r = DateOnly.ParseExact(s, format, provider, style);
            return CheckAndConvert(r);
        }

        public static MonthOnly ParseExact(string s, string[] formats)
        {
            var r = DateOnly.ParseExact(s, formats);
            return CheckAndConvert(r);
        }

        public static bool TryParse([NotNullWhen(true)] string s, out MonthOnly result)
        {
            var r = DateOnly.TryParse(s, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParse(s, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> s, out MonthOnly result)
        {
            var r = DateOnly.TryParse(s, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParse(s, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, [NotNullWhen(true)] string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, formats, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact([NotNullWhen(true)] string? s, [NotNullWhen(true)] string? format, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, format, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact([NotNullWhen(true)] string? s, [NotNullWhen(true)] string? format, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, format, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact([NotNullWhen(true)] string? s, [NotNullWhen(true)] string?[]? formats, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, formats, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, [NotNullWhen(true)] string?[]? formats, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, formats, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact([NotNullWhen(true)] string? s, [NotNullWhen(true)] string?[]? formats, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, formats, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, IFormatProvider? provider, DateTimeStyles style, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, format, provider, style, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        public static bool TryParseExact(ReadOnlySpan<char> s, ReadOnlySpan<char> format, out MonthOnly result)
        {
            var r = DateOnly.TryParseExact(s, format, out DateOnly dateOnly);
            return CheckAndConvert(r, dateOnly, out result);
        }

        #endregion

        #region Operators

        public static bool operator ==(MonthOnly left, MonthOnly right) => left.dateOnly == right.dateOnly;

        public static bool operator !=(MonthOnly left, MonthOnly right) => left.dateOnly != right.dateOnly;

        public static bool operator <(MonthOnly left, MonthOnly right) => left.dateOnly < right.dateOnly;

        public static bool operator >(MonthOnly left, MonthOnly right) => left.dateOnly > right.dateOnly;

        public static bool operator <=(MonthOnly left, MonthOnly right) => left.dateOnly <= right.dateOnly;

        public static bool operator >=(MonthOnly left, MonthOnly right) => left.dateOnly >= right.dateOnly;

        #endregion

        #region Private methods

        private static MonthOnly CheckAndConvert(DateOnly dateOnly)
        {
            if (dateOnly.Day != 1)
                throw new FormatException($"String was not recognized as a valid MonthOnly.");

            return FromDateOnly(dateOnly);
        }

        private static bool CheckAndConvert(bool r, DateOnly dateOnly, out MonthOnly monthOnly)
        {
            if (r == false || dateOnly.Day != 1)
                return false;

            monthOnly = FromDateOnly(dateOnly);
            return true;
        }

        #endregion
    }
}
