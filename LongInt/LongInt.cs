using System;
using System.Collections.Generic;
using System.Text;

namespace LongInt
{
    //  minValue = -MaxValue;
    //  maxValue =  9,999...(9) * 10^(int.MaxValue  - 56)
    //           =  9,999...(9) * 10^((2^32 / 2 - 1) - 56)
    //           =  9,999...(9) * 10^(2.147.483.591);
    public class longint
    {
        private const int MAX_LENGTH_ARRAY = 2147483591; // int.MaxValue - 56

        private bool negative;
        public bool Negative
        {
            get
            {
                if (value == null) { negative = false; }
                else if (value.Length == 0) { negative = false; }
                else if (value.Length == 1) { if (value[0] == 0) { negative = false; } }

                return negative;
            }
            set
            {
                negative = value;

                if (this.value == null) { negative = false; }
                else if (this.value.Length == 0) { negative = false; }
                else if (this.value.Length == 1) { if (this.value[0] == 0) { negative = false; } }
            }
        }

        private sbyte[] value;
        public sbyte[] Value
        {
            get
            {
                if (value == null)
                    value = new sbyte[1];
                else if (value.Length == 0)
                    value = new sbyte[1];

                return value;
            }
            set
            {
                if (value != null)
                {
                    if (value.Length != 0)
                        this.value = value;
                    else
                        this.value = new sbyte[1];
                }
                else
                    this.value = new sbyte[1] { 0 };

                this.value = CorrectValue(this.value);
            }
        } // 127..-128 - 1 byte

        public longint()
        {

        }
        public longint(bool negative, sbyte[] value)
        {
            Array.Reverse(value);

            Value = value;
            Negative = negative;
        }
        public longint(int value)
        {
            List<sbyte> dataValue = new List<sbyte>();
            bool negative = false;

            if (value < 0) { negative = true; }
            else { negative = false; }

            if (value != 0)
                for (int i = 0; value >= 1 || value <= -1; ++i)
                {
                    dataValue.Add((sbyte)Math.Abs((value % 10)));
                    value /= 10;
                }
            else
                dataValue.Add(0);

            Value = dataValue.ToArray();
            Negative = negative;
        }

        public override bool Equals(object obj)
        {
            CheckValueForNull(this); CheckValueForNull(obj);

            if (obj?.GetType() != typeof(longint))
                return false;

            longint li = (longint)obj;

            return this == li;
        }
        public override int GetHashCode()
        {
            CheckValueForNull(this);
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            CheckValueForNull(this);
            StringBuilder sbResult = new StringBuilder();
            string result = "";

            if (Negative)
                sbResult.Append('-');

            if (Value.Length > 0)
                for (int i = Value.Length - 1; i >= 0; --i)
                {
                    if (sbResult.Length >= 3000)
                    {
                        result += sbResult.ToString();
                        sbResult = new StringBuilder();
                    }

                    sbResult.Append(Value[i].ToString());
                }
            else
                sbResult.Append('0');

            return sbResult.ToString();
        }

        public static void CheckValueForNull(object obj)
        {
            if (obj == null)
                throw new ArgumentNullException("Value is null.");
        }
        private static sbyte[] CorrectValue(sbyte[] value)
        {
            for (int i = 0; i < value.Length - 1; ++i)
            {
                if (value[i] < 0)
                {
                    value[i] = (sbyte)(value[i] + 10);
                    value[i + 1]--;
                }
                else if (value[i] >= 10 && value[i] <= 18)
                {
                    value[i] = (sbyte)(value[i] - 10);
                    value[i + 1]++;
                }
                else if (value[i] > 18)
                {
                    while (value[i] >= 10)
                    {
                        value[i] = (sbyte)(value[i] - 10);
                        value[i + 1]++;
                    }
                }
            }

            if (value[value.Length - 1] == 0)
            {
                while (value[value.Length - 1] == 0 && value.Length - 1 != 0)
                {
                    sbyte[] newValue = new sbyte[value.Length - 1];

                    for (int i = 0; i < value.Length - 1; i++)
                        newValue[i] = value[i];

                    value = newValue;
                }
            }
            else if (value[value.Length - 1] >= 10)
            {
                sbyte[] newValue = new sbyte[value.Length + 1];

                value[value.Length - 1] -= 10;
                newValue[newValue.Length - 1] = 1;

                for (int i = 0; i < value.Length; ++i)
                    newValue[i] = value[i];

                value = newValue;
            }

            return value;
        }

        public static bool operator ==(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);
            int count;

            if (li1.Value.Length < li2.Value.Length || li1.Value.Length > li2.Value.Length || (li1.Negative != li2.Negative))
                return false;
            else
                count = li1.Value.Length;

            for (int i = li1.Value.Length - 1; i >= 0; --i)
            {
                if (li1.Value[i] < li2.Value[i] || li1.Value[i] > li2.Value[i])
                    return false;
            }

            return true;
        }
        public static bool operator !=(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);
            int count;

            if (li1.Value.Length < li2.Value.Length || li1.Value.Length > li2.Value.Length || (li1.Negative != li2.Negative))
                return true;
            else
                count = li1.Value.Length;

            for (int i = li1.Value.Length - 1; i >= 0; --i)
            {
                if (li1.Value[i] < li2.Value[i] || li1.Value[i] > li2.Value[i])
                    return true;
            }

            return false;
        }
        public static bool operator <(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);

            if (li1.Negative && !li2.Negative)
                return true;
            else if (!li1.Negative && li2.Negative)
                return false;

            if (li1.Value.Length < li2.Value.Length)
                return true;
            else if (li1.Value.Length > li2.Value.Length)
                return false;

            for (int i = li1.Value.Length - 1; i >= 0; --i)
            {
                if (li1.Value[i] < li2.Value[i])
                    return true;
                else if (li1.Value[i] > li2.Value[i])
                    return false;
            }

            return false;
        }
        public static bool operator >(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);

            if (!li1.Negative && li2.Negative)
                return true;
            else if (li1.Negative && !li2.Negative)
                return false;

            if (li1.Value.Length > li2.Value.Length)
                return true;
            else if (li1.Value.Length < li2.Value.Length)
                return false;

            for (int i = li1.Value.Length - 1; i >= 0; --i)
            {
                if (li1.Value[i] > li2.Value[i])
                    return true;
                else if (li1.Value[i] < li2.Value[i])
                    return false;
            }

            return false;
        }
        public static bool operator <=(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);
            return li1 < li2 || li1 == li2;
        }
        public static bool operator >=(longint li1, longint li2)
        {
            CheckValueForNull(li1); CheckValueForNull(li2);
            return li1 > li2 || li1 == li2;
        }

        public static implicit operator longint(int value)
        {
            return new longint(value);
        }
    }
}