namespace FractionImplementation { 
    /*
    proprietà in sola lettura per numeratore (un intero con segno) e 
    denominatore (un intero strettamente positivo);
    i 4 operatori aritmetici (+,-,*,/) nell'usale sintassi infissa;
    il metodo ToString che sulla frazione corrispondente in forma normale 
    a x/y stampa la stringa "x/y" se y!=1, solo "x" altrimenti;
    il metodo Equals (e quindi anche...) in modo che due frazioni 
    risultino uguali se e solo se hanno la stessa forma normale;
    conversione implicita da intero a frazione (con denominatore =1);
    conversione esplicita da frazione a intero, che solleva un'eccezione 
    se il denominatore in forma normale è diverso da 1;
    
    Suggerimento: definire un metodo di semplificazione che mette una 
    frazione in forma normale.
    */
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
        public int Numerator { get; }
        public int Denominator { get; }
        public Fraction(int numerator, int denominator) {
            if (0 == denominator)
                throw new ArgumentException("Denominator cannot be null", nameof(denominator));
            var sign =(denominator<0)?-1:1;
            var gcd = Utilities.GCD(Math.Abs(numerator), Math.Abs(denominator));
            Numerator = sign*numerator/gcd;
            Denominator = sign * denominator/gcd;
        }
        public Fraction(int numerator):this(numerator,1) { }
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
        public bool Equals(Fraction? other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }
        public static bool operator ==(Fraction? left, Fraction? right) {
            return Equals(left, right);
        }
        public static bool operator !=(Fraction? left, Fraction? right) {
            return !Equals(left, right);
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
        public override string ToString() {
            return base.ToString();
        }
        public static explicit operator int(Fraction f) {
            return 0;
        }
        public static implicit operator Fraction(int n) {
            return null!;
        }
        /*un costruttore che dati due interi, di cui il secondo non nullo, 
    inizializza l'oggetto con la forma normale della frazione avente 
    il primo come numeratore ed il secondo come denominatore;*/

    }
}