using FractionNS;

namespace TestFraction
{
    public class Tests
    {
        private Fraction fraction;

        [SetUp]
        public void Setup()
        {
            fraction = new Fraction();
        }

        [Test]
        public void CorrectNumeratorAndDenominator()
        {
            var fraction = new Fraction(5,7);
            const int expectedNum = 5;
            const int expectedDen = 7;
            Assert.Multiple(() => { Assert.That(fraction.Numerator, Is.EqualTo(expectedNum)); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen));});
        }

        [Test]
        public void NegativeNumeratorAndDenominatorExpectingPositiveDenominatorAndNumerator()
        {
            var fraction = new Fraction(-5, -7);
            const int expectedDen = 7;
            Assert.Multiple(() => { Assert.That(fraction.Denominator, Is.Positive); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen)); Assert.That(fraction.Numerator, Is.Positive); });
        }

        [Test]
        public void PositiveNumeratorAndNegativeDenominatorExpectingPositiveDenominatorAndNegativeNumerator()
        {
            var fraction = new Fraction(5,-7);
            const int expectedDen = 7;
            Assert.Multiple(() => { Assert.That(fraction.Denominator, Is.Positive); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen)); Assert.That(fraction.Numerator, Is.Negative); });
        }

        [Test]
        public void NegativeNumeratorAndPositiveDenominatorExpectingPositiveDenominatorAndNegativeNumerator()
        {
            var fraction = new Fraction(-5, 7);
            const int expectedNum = -5;
            const int expectedDen = 7;
            Assert.Multiple(() =>
            {
                Assert.That(fraction.Numerator, Is.Negative); Assert.That(fraction.Numerator, Is.EqualTo(expectedNum));
                Assert.That(fraction.Denominator, Is.Positive); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen));
            });
        }

        [Test]
        public void TestingIfNormalFormIsWorking()
        {
            var fraction = new Fraction(30,42);
            const int expectedNum = 5;
            const int expectedDen = 7;
            Assert.Multiple(()=>{Assert.That(fraction.Numerator, Is.EqualTo(expectedNum)); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen));});
        }
        [Test]
        public void TestingIfNormalFormIsWorkingWithDifferentSign()
        {
            var fraction = new Fraction(90, -525);
            const int expectedNum = -6;
            const int expectedDen = 35;
            Assert.Multiple(() => { Assert.That(fraction.Numerator, Is.EqualTo(expectedNum)); Assert.That(fraction.Denominator, Is.EqualTo(expectedDen)); });
        }

        
        //4 parametri: 2 valori da passare al costruttore (num e den) e i due valori attesi (expected)
        [TestCase(5,7,5,7)]
        [TestCase(22,15,22,15)]
        [TestCase(30,42,5,7)]
        [TestCase(90,-525,-6,35)]
        [TestCase(50,20,5,2)]
        [TestCase(42,-2,-21,1)]
        [TestCase(2,4,1,2)]
        [TestCase(1,-1,-1,1)]

        public void ParameterizedTestWithDifferentValues(int numerator, int denominator, int expectedNumerator, int expectedDenominator)
        {
            var fraction = new Fraction(numerator, denominator);
            Assert.Multiple(() => { Assert.That(fraction.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(fraction.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test]
        public void ZeroDenominatorThrowsException()
        {
            Assert.That(() => new Fraction(2,0), Throws.TypeOf<ArgumentNullException>());
        }

        //Testing operators
        [Test]
        public void SumTwoFractions()
        {
            var fraction1 = new Fraction(1, 2);
            var fraction2 = new Fraction(2, 5);
            var result = fraction1 + fraction2;
            var expectedNumerator = 9;
            var expectedDenominator = 10;
            Assert.Multiple(() => { Assert.That(result.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(result.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test]
        public void DifferenceBetweenTwoFractions()
        {
            var fraction1 = new Fraction(4);
            var fraction2 = new Fraction(33, 7);
            var result = fraction1 - fraction2;
            var expectedNumerator = -5;
            var expectedDenominator = 7;
            Assert.Multiple(() => { Assert.That(result.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(result.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test]
        public void MultTwoFractions()
        {
            var fraction1 = new Fraction(11);
            var fraction2 = new Fraction(1, 11);
            var result = fraction1 * fraction2;
            var expectedNumerator = 1;
            var expectedDenominator = 1;
            Assert.Multiple(() => { Assert.That(result.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(result.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test]
        public void FractTwoFractions()
        {
            var fraction1 = new Fraction(33, 42);
            var fraction2 = new Fraction(111, 8);
            var result = fraction1 / fraction2;
            var expectedNumerator = 44;
            var expectedDenominator = 777;
            Assert.Multiple(()=>{Assert.That(result.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(result.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test]
        public void MultFractionByZero()
        {
            var fraction = new Fraction(42, 5);
            var result = fraction * 0;
            int expectedNum = 0;
            Assert.That(result.Numerator, Is.EqualTo(expectedNum));
        }

        [Test]
        public void DivFractionByZeroThrows()
        {
            var fraction = new Fraction(42, 1);
            Assert.That(() => fraction/0, Throws.TypeOf<DivideByZeroException>());
        }

        [Test]
        public void DivFractionByInt()
        {
            var fraction = new Fraction(15, 4);
            var result = fraction / 5;
            int expectedNumerator = 3;
            int expectedDenominator = 4;
            //Assert.True((expectedDenominator == result.Denominator) && (expectedNumerator == result.Numerator));
            Assert.Multiple(() => { Assert.That(result.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(result.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [TestCase(0,1,0,22)]
        [TestCase(1,2,2,4)]
        [TestCase(4,2,8,4)]
        [TestCase(1,3,1,3)]

        public void TwoFractionsAreEqualsWithOperator(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            var fraction1 = new Fraction(numerator1, denominator1);
            var fraction2 = new Fraction(numerator2, denominator2);
            bool result = fraction1 == fraction2;
            Assert.That(result, Is.True);
        }

        [TestCase(0, 1, 0, 22)]
        [TestCase(1, 2, 2, 4)]
        [TestCase(4, 2, 8, 4)]
        [TestCase(1, 3, 1, 3)]
        public void TwoFractionsAreEqualsWithEqualsMethod(int numerator1, int denominator1, int numerator2, int denominator2)
        {
            var fraction1 = new Fraction(numerator1, denominator1);
            var fraction2 = new Fraction(numerator2, denominator2);
            bool result = fraction1.Equals(fraction2);
            Assert.That(result, Is.True);
        }

        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11,"2")]
        [TestCase(22, -11, "-2")]
        [TestCase(3, 14, "3/14")]

        public void FractionToString(int numerator, int denominator, string expectedString)
        {
            var fraction1 = new Fraction(numerator, denominator);
            var result = fraction1.ToString();
            Assert.That(result, Is.EqualTo(expectedString));
        }

        //[TestCase(42,new Fraction())]
        [TestCase(42)]
        [TestCase(21)]
        [TestCase(13)]
        [TestCase(56)]
        [TestCase(0)]
        public void ImplicitIntToFraction(int numToConvert)
        {
            Fraction result = numToConvert;
            Fraction expectedFraction = new Fraction(numToConvert,1);
            //Console.WriteLine(result.Numerator+" "+result.Denominator);
            Assert.That(result, Is.EqualTo(expectedFraction));
        }

        [TestCase(42,1)]
        [TestCase(35,1)]
        [TestCase(12,1)]
        [TestCase(16,1)]
        public void ExplicitFractionToInt(int numerator, int denominator)
        {
            fraction.Numerator = numerator;
            fraction.Denominator = denominator;
            int result = (int)fraction;
            Assert.That(result, Is.EqualTo(numerator));
        }

        [Test]
        public void ExplicitConversionToIntThrows()
        {
            fraction.Numerator = 42;
            fraction.Denominator = 11;
            int res = 0;
            Assert.That(() => res = (int)fraction, Throws.InstanceOf<ArgumentException>());
        }

    }
}