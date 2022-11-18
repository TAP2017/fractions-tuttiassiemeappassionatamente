namespace FractionImplementation { 
    class Utilities {
        internal static int GCD(int a, int b) {
            while (a != 0 && b != 0) {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a | b;
        }
    }
    public class Fraction : IEquatable<Fraction> {
        /*    proprietà in sola lettura per numeratore (un intero con segno) e 
    denominatore (un intero strettamente positivo);*/
        public int Numerator { get; }
        public int Denominator { get; }
        /*un costruttore che dati due interi, di cui il secondo non nullo, 
   inizializza l'oggetto con la forma normale della frazione avente 
   il primo come numeratore ed il secondo come denominatore;*/
        public Fraction(int numerator, int denominator) {
            if (0 == denominator)
                throw new ArgumentException("Denominator cannot be null", nameof(denominator));
            var sign =(denominator<0)?-1:1;
            var gcd = Utilities.GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = sign*numerator/gcd;
            Denominator = sign * denominator/gcd;
        }
        public Fraction(int numerator):this(numerator,1) { }
        /*    i 4 operatori aritmetici (+,-,*,/) nell'usale sintassi infissa;*/
        public static Fraction operator +(Fraction left, Fraction right) {
            return new Fraction(left.Numerator*right.Denominator+left.Denominator*right.Numerator,left.Denominator*right.Denominator);
        }
        public static Fraction operator -(Fraction left, Fraction right) {
            return new Fraction(left.Numerator * right.Denominator - left.Denominator * right.Numerator, left.Denominator * right.Denominator);
        }
        public static Fraction operator *(Fraction left, Fraction right) {
            return new Fraction(left.Numerator * right.Numerator , left.Denominator * right.Denominator);
        }
        public static Fraction operator /(Fraction left, Fraction right) {
            if (right.Numerator==0)
                throw new DivideByZeroException("Division by zero");
            return new Fraction(left.Numerator * right.Denominator, left.Denominator * right.Numerator);
        }
        /*    il metodo Equals (e quindi anche...) in modo che due frazioni 
    risultino uguali se e solo se hanno la stessa forma normale;*/
        public bool Equals(Fraction? other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }
        public override bool Equals(object? obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Fraction)obj);
        }
        public override int GetHashCode() {
            return HashCode.Combine(Numerator, Denominator);
        }
        /*    il metodo ToString che sulla frazione corrispondente in forma normale 
    a x/y stampa la stringa "x/y" se y!=1, solo "x" altrimenti;*/
        public override string ToString() {
            return Denominator == 1 ? Numerator.ToString() : $"{Numerator}/{Denominator}";
        }
        /*
        conversione esplicita da frazione a intero, che solleva un'eccezione 
        se il denominatore in forma normale è diverso da 1; */
        public static explicit operator int(Fraction f) {
            return f.Denominator==1?f.Numerator:throw new InvalidOperationException($"impossible conversion to int as denominator is {f.Denominator}");
        }
        /*
       conversione implicita da intero a frazione (con denominatore =1);  */
        public static implicit operator Fraction(int n) {
            return new Fraction(n,1);
        }


    }
}