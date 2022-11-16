using FractionImplementation;

namespace TestFraction
{
    public class FractionTests
    {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Create_NotNull_Fraction() {
            var f = new Fraction(1, 2);
            Assert.IsNotNull(f);
        }

        [Test]
        public void Fraction_CantHaveZeroDenominator() {
            Assert.Throws<ArgumentException>(() => new Fraction(1, 0));
        }

        [Test]
        public void Read_FractionNumerator() {
            var f = new Fraction(1, 2);
            Assert.That(f.Numerator, Is.EqualTo(1));
        }

        [Test]
        public void Read_FractionDenominator() {
            var f = new Fraction(1, 2);
            Assert.That(f.Denominator, Is.EqualTo(2));
        }

        [Test]
        public void Fraction_CanBeReduced() {
            var f = new Fraction(2, 4);
            Assert.That(f.Numerator, Is.EqualTo(1));
            Assert.That(f.Denominator, Is.EqualTo(2));
        }

        [Test]
        public void Fraction_CanBeNegative() {
            var f = new Fraction(-5, 7);
            Assert.That(f.Numerator, Is.EqualTo(-5));
            Assert.That(f.Denominator, Is.EqualTo(7));
        }

        [Test]
        public void Fraction_WithZero()
        {
            var f = new Fraction(0, 7);
            Assert.That(f.Numerator, Is.EqualTo(0));
            Assert.That(f.Denominator, Is.EqualTo(1));
        }


        [Test]
        public void Fraction_CanBeAdded() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var f3 = f1 + f2;
            Assert.That(f3.Numerator, Is.EqualTo(5));
            Assert.That(f3.Denominator, Is.EqualTo(6));
        }

        [Test]
        public void Fraction_CanBeSubtracted() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var f3 = f1 - f2;
            Assert.That(f3.Numerator, Is.EqualTo(1));
            Assert.That(f3.Denominator, Is.EqualTo(6));
        }

        [Test]
        public void Fraction_CanBeMultiplied() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var f3 = f1 * f2;
            Assert.That(f3.Numerator, Is.EqualTo(1));
            Assert.That(f3.Denominator, Is.EqualTo(6));
        }

        [Test]
        public void Fraction_CanBeDivided() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            var f3 = f1 / f2;
            Assert.That(f3.Numerator, Is.EqualTo(3));
            Assert.That(f3.Denominator, Is.EqualTo(2));
        }

        [Test]
        public void Fraction_CanBePrinted() {
            var f = new Fraction(1, 2);
            Assert.That(f.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Fraction_CanBePrintedReduced() {
            var f = new Fraction(2, 4);
            Assert.That(f.ToString(), Is.EqualTo("1/2"));
        }

        [Test]
        public void Fraction_WithSameNumeratorAndDenominator_AreEqual() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [Test]
        public void Int_CanBeEqualToFraction()
        {
            var f1 = new Fraction(5, 1);
         Fraction f2 = 5;
            Assert.That(f1, Is.EqualTo(f2));
        }

        [Test]
        public void Fraction_CanBeEqualToInt() {
            var f1 = new Fraction(5, 1);
            Assert.That((int)f1 == 5, Is.True);
        }

        [Test]
        public void Fraction_WithDifferentNumeratorAndDenominator_AreNotEqual() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            Assert.That(f1, Is.Not.EqualTo(f2));
        }

        [Test]
        public void Fraction_WithDifferentNumeratorandDenominatorButSameValueIfNormalized_AreEqual() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(2, 4);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [Test]
        public void Fraction_WithSameNumeratorAndDenominator_AreEqualUsingOperator() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            Assert.That(f1 == f2, Is.True);
        }

        [Test]
        public void Fraction_WithDifferentNumeratorAndDenominator_AreNotEqualUsingOperator() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 3);
            Assert.That(f1 == f2, Is.False);
        }

        [Test]
        public void Fraction_WithSameNumeratorAndDenominator_HasTheSameHashCode()
        {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(1, 2);
            Assert.That(f1.GetHashCode(), Is.EqualTo(f2.GetHashCode()));
        }

        [TestCase(3)]
        [TestCase(5)]
        [TestCase(-7)]
        [TestCase(0)]
        [TestCase(-13)]
        public void ImplicitConversion_IntToMyFraction(int n)
        {
         Fraction f = n;
            Assert.That(f.Numerator, Is.EqualTo(n));
            Assert.That(f.Denominator, Is.EqualTo(1));
        }

        [TestCase(3, 1)]
        [TestCase(5, 1)]
        [TestCase(-7, 1)]
        [TestCase(0, 1)]
        [TestCase(-13, 13)]
        public void EsplicitConversion_MyFractionToInt(int n, int d) {
         Fraction f = new Fraction(n, d);
            int i = (int)f;
            Assert.That(i, Is.EqualTo(n / d));
        }

        [TestCase(3, 6)]
        [TestCase(5, 7)]
        [TestCase(-7, 8)]
        public void CantConvert_MyFractionToInt_IfIsDouble(int n, int d) {
         Fraction f = new Fraction(n, d);
            Assert.Throws<InvalidCastException>(() => {
                int i = (int)f;
            });
        }


    }

    public class Laboratorio1Tests
    {
        /*
         *
         * costruire una frazione col denominatore uguale a zero sollevi un'eccezione
         * costruire un oggetto con numeratore=2 e denominatore=4 produca una frazione il cui numeratore � 1 e denominatore 2 (in altre parole, verificare che la frazione venga normalizzata)
         * costruire un oggetto con numeratore=1 e denominatore=-1 produca una frazione il cui numeratore � -1 e denominatore=1
         * sommare 1/2 e 2/5 produca 9/10
         * sottrarre 33/7 da 4 produca -5/7
         * moltiplicare 1/11 e 11 produca 1
         * dividere 33/42 per 111/8 produca 44/777
         * moltiplicare 42/1 per 0 produca 0
         * dividere 42/1 per 0 sollevi un'eccezione
         * 0/1 sia uguale a 0/22
         * 1/2 sia uguale a 2/4
         * la rappresentazione in stringa di 11/5 sia "11/5"
         * la rappresentazione in stringa di 22/11 sia "2"
         * la rappresentazione in stringa di 22/-11 sia "-2"
         * l'intero 42 sia implicitamente convertibile in 42/1
         * l'intero 0 sia implicitamente convertibile in 0/1
         * la conversione esplicita di 42/1 abbia successo e restituisca l'intero 42
         * la conversione esplicita di 42/11 sollevi un'eccezione
         */

        [Test]
        public void FractionsWithZeroDenominatorCantExists()
        {
            Assert.Throws<ArgumentException>(() => new Fraction(1, 0));
        }

        [Test]
        public void FractionsCanBeNormalized() {
            var f = new Fraction(2, 4);
            Assert.That(f.Numerator, Is.EqualTo(1));
            Assert.That(f.Denominator, Is.EqualTo(2));
        }

        [Test]
        public void FractionsCanBeNormalizedWithNegativeDenominator() {
            var f = new Fraction(1, -1);
            Assert.That(f.Numerator, Is.EqualTo(-1));
            Assert.That(f.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void SumOfTwoFractions() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(2, 5);
            var f3 = f1 + f2;
            Assert.That(f3.Numerator, Is.EqualTo(9));
            Assert.That(f3.Denominator, Is.EqualTo(10));
        }

        [Test]
        public void SubtractionOfTwoFractions() {
            var f1 = new Fraction(4, 1);
            var f2 = new Fraction(33, 7);
            var f3 = f1 - f2;
            Assert.That(f3.Numerator, Is.EqualTo(-5));
            Assert.That(f3.Denominator, Is.EqualTo(7));
        }

        [Test]
        public void MultiplicationOfFractionAndInteger() {
            var f1 = new Fraction(1, 11);
            var f2 = f1 * 11;
            Assert.That(f2.Numerator, Is.EqualTo(1));
            Assert.That(f2.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void DivisionOfTwoFractions() {
            var f1 = new Fraction(33, 42);
            var f2 = new Fraction(111, 8);
            var f3 = f1 / f2;
            Assert.That(f3.Numerator, Is.EqualTo(44));
            Assert.That(f3.Denominator, Is.EqualTo(777));
        }

        [Test]
        public void MultiplicationOfFractionAndZero() {
            var f1 = new Fraction(42, 1);
            var f2 = f1 * 0;
            Assert.That(f2.Numerator, Is.EqualTo(0));
            Assert.That(f2.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void DivisionOfFractionAndZero() {
            var f1 = new Fraction(42, 1);
            Assert.Throws<DivideByZeroException>(() => {
                var f2 = f1 / 0;
            });
        }

        [Test]
        public void ZeroIsEqualToZero() {
            var f1 = new Fraction(0, 1);
            var f2 = new Fraction(0, 22);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [Test]
        public void OneHalfIsEqualToTwoFourth() {
            var f1 = new Fraction(1, 2);
            var f2 = new Fraction(2, 4);
            Assert.That(f1, Is.EqualTo(f2));
        }

        [Test]
        public void FractionToString() {
            var f1 = new Fraction(11, 5);
            Assert.That(f1.ToString(), Is.EqualTo("11/5"));
        }

        [Test]
        public void FractionToString2() {
            var f1 = new Fraction(22, 11);
            Assert.That(f1.ToString(), Is.EqualTo("2"));
        }

        [Test]
        public void FractionToString3() {
            var f1 = new Fraction(22, -11);
            Assert.That(f1.ToString(), Is.EqualTo("-2"));
        }

        [Test]
        public void ImplicitConversionFromIntegerToFraction() {
         Fraction f1 = 42;
            Assert.That(f1.Numerator, Is.EqualTo(42));
            Assert.That(f1.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void ImplicitConversionFromZeroToFraction() {
         Fraction f1 = 0;
            Assert.That(f1.Numerator, Is.EqualTo(0));
            Assert.That(f1.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void ExplicitConversionFromFractionToInteger() {
         Fraction f1 = new Fraction(42, 1);
            int i = (int)f1;
            Assert.That(i, Is.EqualTo(42));
        }

        [Test]
        public void ExplicitConversionFromFractionToInteger2() {
         Fraction f1 = new Fraction(42, 11);
            Assert.Throws<InvalidCastException>(() => {
                int i = (int)f1;
            });
        }

        
    }
}