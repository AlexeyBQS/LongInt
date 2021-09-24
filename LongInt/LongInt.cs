namespace LongInt
{
    //  minValue = -MaxValue;
    //  maxValue =  9,999...(9) * 10^(int.MaxValue  - 56)
    //           =  9,999...(9) * 10^((2^32 / 2 - 1) - 56)
    //           =  9,999...(9) * 10^(2.147.483.591);
    public class LongInt
    {
        private const int MAX_LENGTH_ARRAY = 2147483591; // int.MaxValue - 56

        private bool negative;
        public bool Negative
        {
            get
            {
                return negative;
            }
            set
            {
                negative = value;
            }
        }

        private sbyte[]? value;
        public sbyte[] Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        public LongInt(bool negative, sbyte[] value)
        {
            Value = value;
            Negative = negative;
        }


    }
}