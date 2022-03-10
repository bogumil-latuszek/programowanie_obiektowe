using System;

namespace zadania_domowe
{
    class zadanie1
    {
        static void Main(string[] args)
        {
            Length length1 = new Length(50, lengthMeasurment.meters);
            Length length2 = length1 * 2;
            Console.WriteLine(length2.ToString());
            length2 = 2 * length1;
            Console.WriteLine(length2.ToString());
            Length length3 = length1 + length2;
            Console.WriteLine(length3.ToString());
            Length length4 = length3 / 500;
            Console.WriteLine(length4.ToString());
            Length length5 = new Length(600, lengthMeasurment.milimeters);
            try { Length length6 = length5 + length1; }//this should throw an exception
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
    public enum lengthMeasurment
    {
        meters,
        centimeters,
        milimeters
    }
    public class Length
    {
        private decimal Value { get; set; }
        private lengthMeasurment Type;

        public Length(decimal value, lengthMeasurment type)
        {
            this.Value = value;
            this.Type = type;
        }

        public static Length operator *(Length l, int mltpFactor)
        {
            decimal resultValue = l.Value * mltpFactor;
            return new Length(resultValue, l.Type);
        }
        public static Length operator *( int mltpFactor, Length l)
        {
            decimal resultValue = l.Value * mltpFactor;
            return new Length(resultValue, l.Type);
        }
        public static Length operator +(Length l1, Length l2)
        {
            if (l1.Type.Equals(l2.Type) == false)
            {
                throw new Exception("can't add different measurement types");
            }
            decimal resultValue = l1.Value + l2.Value;
            return new Length(resultValue, l1.Type);
        }
        public static Length operator /(Length l, int dvsFactor)
        {
            decimal resultValue = l.Value / dvsFactor;
            return new Length(resultValue, l.Type);
        }

        public override string ToString()
        {
            return (this.Value.ToString() +" "+ this.Type.ToString());
        }
    }
}
