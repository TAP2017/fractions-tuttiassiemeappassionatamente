using FractionImplementation;

namespace TestProjectLabo1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        /// <summary>
        /// 1.	proprietà in sola lettura per numeratore (un intero con segno) e denominatore (un intero strettamente positivo);
        /// 2.	un costruttore che dati due interi, di cui il secondo non nullo, inizializza l'oggetto con la forma normale della
        ///     frazione avente il primo come numeratore ed il secondo come denominatore;
        /// 3.	i 4 operatori aritmetici (+,-,*,/) nell'usale sintassi infissa;
        /// 4.	il metodo ToString che sulla frazione corrispondente in forma normale a x/y stampa la stringa "x/y" se y!=1,
        ///     altrimenti solo "x";
        /// 5.	il metodo Equals (e quindi anche...) in modo che due frazioni risultino uguali sse se hanno la stessa forma normale;
        /// 6.	conversione implicita da intero a frazione (con denominatore =1);
        /// 7.	conversione esplicita da frazione a intero, che solleva un'eccezione se il denominatore in forma normale è diverso da 1;
        /// </summary>
        //2    
        [TestCase(-5, 7)]
        [TestCase(22, 15)]
        [TestCase(13, 5)]
        public void GivenTwoIntegersInitializeObject(int numerator, int denominator)
        {
            var fraction = new Fraction(numerator, denominator);
            /* ripetizione inutile
             * var actual = fraction.FractionConstruction(fraction.Numerator, fraction.Denominator);*/
            Assert.Multiple(() =>
            {
                Assert.That(fraction.Numerator, Is.EqualTo(numerator));
                Assert.That(fraction.Denominator, Is.EqualTo(denominator));
            });
        }

        [TestCase(13, 0)]
        [TestCase(1, 0)]
        [TestCase(1, -0)]
        public void GivenTwoIntegersReturnExceptionIfDenominatorIsEqualToZero(int numerator, int denominator)
        {
            /* l'asserzione non sarebbe catturata, quindi serve porla in modo differente
            var fraction = new Fraction(numerator, denominator);*/
            Assert.That(() => new Fraction(numerator, denominator), Throws.InstanceOf<ArgumentException>());
        }

        [TestCase(5, -7, -5, 7)]
        [TestCase(-22, -15, 22, 15)]
        [TestCase(13, -5, -13, 5)]
        public void GivenTwoNumberNotBothPositivePutNegativeSignToNumeratorOrMadeBothPositive(int numerator,
            int denominator, int expectedNumerator, int expectedDenominator)
        {
            var actual = new Fraction(numerator, denominator);
            Assert.Multiple(() =>
            {
                Assert.That(actual.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(actual.Denominator, Is.EqualTo(expectedDenominator));
            });
        }

        [TestCase(-30, 42, -5, 7)]
        [TestCase(8, -4, -2, 1)]
        [TestCase(30, 60, 1, 2)]
        [TestCase(90, -525, -6, 35)]
        [TestCase(1, -1, -1, 1)]
        public void GivenTwoNumberNotCoprimeMakeThemInNormalForm(int numerator, int denominator, int expectedNumerator,
            int expectedDenominator)
        {
            var actual = new Fraction(numerator, denominator);
            Assert.Multiple(() =>
            {
                Assert.That(actual.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(actual.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(1,2,2,5, 9, 10)]
        public void GivenTwoFractionReturnAFractionSumOfThem(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Fraction firstFraction = new (firstNumerator, firstDenominator);
            Fraction secondFraction = new (secondNumerator, secondDenominator);
            Fraction result = firstFraction + secondFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(33,7,4,1, 5, 7)]
        public void GivenTwoFractionReturnAFractionSubtractionOfThem(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Fraction firstFraction = new (firstNumerator, firstDenominator);
            Fraction secondFraction = new (secondNumerator, secondDenominator);
            Fraction result = firstFraction - secondFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(1, 11, 11, 1, 1, 1)]
        [TestCase(42, 1, 0, 1, 0, 1)]
        [TestCase(35, 7, 0, 3, 0, 1)]
        public void GivenTwoFractionReturnAFractionMultiplicationOfThem(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Fraction firstFraction = new (firstNumerator, firstDenominator);
            Fraction secondFraction = new (secondNumerator, secondDenominator);
            var result = firstFraction * secondFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(33, 42, 111, 8, 44, 777)]
        public void GivenTwoFractionReturnAFractionDivisionOfThem(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, int expectedNumerator, int expectedDenominator)
        {
            Fraction firstFraction = new (firstNumerator, firstDenominator);
            Fraction secondFraction = new (secondNumerator, secondDenominator);
            Fraction result = firstFraction / secondFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(42, 1, 0, 1)]
        public void GivenTwoFractionReturnExceptionIfDivideForZero(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator)
        {
            Assert.That(() => new Fraction(firstNumerator,firstDenominator)/new Fraction(secondNumerator,secondDenominator), Throws.InstanceOf<ArgumentException>());
        }
        [TestCase(39, 1, "39")]
        [TestCase(42, 1, "42")]
        [TestCase(9, 1, "9")]
        public void GivenTwoFractionPrintNumIfDenIsOne(int numerator, int denominator, string expectedNumerator)
        {
            Fraction actual = new(numerator, denominator);
            Assert.That(actual.ToString(), Is.EqualTo(expectedNumerator));
        }
        [TestCase(11, 5, "11/5")]
        [TestCase(15, 11, "15/11")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void GivenTwoFractionPrintNumAndDen(int numerator, int denominator, string expectedNumerator)
        {
            Fraction actual = new(numerator, denominator);
            Assert.That(actual.ToString(), Is.EqualTo(expectedNumerator));
        }
        [TestCase(1, 2, 2, 4, true)]
        [TestCase(33, 99, 6, 18, true)]
        [TestCase(0, 1, 0, 22, true)]
        [TestCase(0, 12, 0, 333, true)]
        [TestCase(3, 10, 9, 11, false)]
        [TestCase(1, 99, 4, 5, false)]
        public void GivenTwoFractionControlIfTheyAreEquals(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator, bool expectedValue)
        {
            Fraction first = new(firstNumerator, firstDenominator);
            Fraction second = new(secondNumerator, secondDenominator);
            Assert.That(expectedValue, Is.EqualTo(first.Equals(second)));
        }
        [TestCase(33, 99, 6, 18)]
        [TestCase(7, 14, 1, 2)]
        [TestCase(1, -2, -5, 10)]
        public void GivenTwoEqualsFractionControlIfTheyHaveSameHashCode(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator)
        {
            Fraction first = new(firstNumerator, firstDenominator);
            Fraction second = new(secondNumerator, secondDenominator);
            int firstHash= first.GetHashCode();
            int secondHash= second.GetHashCode();
            Assert.That(firstHash, Is.EqualTo(secondHash));
        }
        [TestCase(7,12,6,4)] 
        [TestCase(8, 10, 9, 20)]
        public void GivenTwoDifferentFractionControlIfTheyHaveDifferentHashCode(int firstNumerator, int firstDenominator, int secondNumerator, int secondDenominator)
        {
            Fraction first = new(firstNumerator, firstDenominator);
            Fraction second = new(secondNumerator, secondDenominator);
            int firstHash= first.GetHashCode();
            int secondHash= second.GetHashCode();
            Assert.That(firstHash, Is.Not.EqualTo(secondHash));
        }
        [TestCase(42,42,1 )]
        [TestCase(0,0,1 )]
        public void ImplicitConversionFromIntToFraction(int number, int expectedNumerator, int expectedDenominator)
        {
            Fraction actual = number;
            Assert.Multiple(() =>
            {
                Assert.That(actual.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(actual.Denominator, Is.EqualTo(expectedDenominator));
            });
        }
        [TestCase(42,1,42)]
        [TestCase(34, -1, -34)]
        public void ExplicitConversionFromFractionToInt(int numerator, int denominator, int expectedNumber)
        {
            int actual = (int)new Fraction(numerator, denominator);
            Assert.Multiple(() =>
            {
                Assert.That(actual, Is.EqualTo(expectedNumber));
            });
        }
        [TestCase(42,11)]
        [TestCase(2, 3)]
        public void ExplicitConversionFromFractionToIntReturnErrorIfDenominatorDifferentFromOne(int numerator, int denominator)
        {
            Assert.That(() => (int)new Fraction(numerator, denominator), Throws.InstanceOf<ArgumentException>());
        }
    }
}