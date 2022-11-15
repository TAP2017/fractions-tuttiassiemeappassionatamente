using Fraction_Namespace;

namespace FractionTestSuite
{
    public class Tests
    {
        /* TEST CONSTRUCTOR */

        [Test]
        public void TestFractionReturnAnEqualIntegerFromNumerator()
        {
            var testNumerator = 11;
            var test = new Fraction(testNumerator, 8);
            Assert.That(test.Numerator, Is.EqualTo(testNumerator));
        }

        [Test]
        public void TestFractionReturnAnEqualIntegerFromDenominator()
        {
            var testDenominator = 8;
            var test = new Fraction(11, testDenominator);
            Assert.That(test.Denominator, Is.EqualTo(testDenominator));
        }

        [Test]
        public void TestFractionConstructorThrowsExceptionIfDenominatorIsZero([Values(34,0)] int numerator)
        {
            Assert.That(() => new Fraction(numerator, 0), Throws.TypeOf<ArgumentException>());
        }

        [Test]
        public void TestFractionChangeValuesSignsIfDenominatorNegativeAndNumeratorPositive()
        {
            var test = new Fraction(11, -10);
            Assert.Multiple(() =>
            {
                Assert.That(test.Numerator, Is.EqualTo(-11));
                Assert.That(test.Denominator, Is.EqualTo(10));
            });
        }

        [Test]
        public void TestFractionMakeNumeratorAndDenominatorPositiveIfBothNegative()
        {
            var test = new Fraction(-33, -7);
            Assert.Multiple(() =>
            {
                Assert.That(test.Numerator, Is.EqualTo(33)); Assert.That(test.Denominator, Is.EqualTo(7));
            });
        }

        [TestCase(28, 70, 2, 5)]                    
        [TestCase(11, 9, 11, 9)]
        [TestCase(440, -842, -220, 421)]
        [TestCase(-1020, 2060, -51, 103)]
        [TestCase(0, 10, 0, 1)]
        public void TestFractionReturnCorrectNormalForm(int numerator, int denominator, int expectedNumer, int expectedDenom)
        {
            var test = new Fraction(numerator, denominator);
            Assert.Multiple(() =>
            {
                Assert.That(test.Numerator, Is.EqualTo(expectedNumer));
                Assert.That(test.Denominator, Is.EqualTo(expectedDenom));
            });
        }


        /* TEST ARITHMETIC OPERATORS */

        private Fraction PrepareFractionClass(int numerator, int denominator)
        {
            if (0 == denominator)       // Bypassing "denominator = 0" control to simplify tests with implicit casting (Tests that verify denominator value already exists)
                return numerator;
            return new Fraction(numerator, denominator);
        }

        [TestCase(1, 2, 2, 5, 9, 10)]
        [TestCase(0, 0, 1, 1, 1, 1)]
        [TestCase(-18, 20, 33, -11, -39, 10)]
        public void TestFractionOperatorPlus(int fstNumerator, int fstDenominator, int sndNumerator, int sndDenominator, int expectedNumerator, int expectedDenominator)
        {
            var test = PrepareFractionClass(fstNumerator, fstDenominator);
            var otherFraction = PrepareFractionClass(sndNumerator, sndDenominator);

            Fraction result = test + otherFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }

        [TestCase(4, 0, 33, 7, -5, 7)]
        [TestCase(0, 0, 0, 0, 0, 1)]
        [TestCase(-18, -9, 2, 0, 0, 1)]
        public void TestFractionOperatorMinus(int firstNumerator, int firstDenominator, int sndNumerator, int sndDenominator, int expectedNumerator, int expectedDenominator)
        {
            var test = PrepareFractionClass(firstNumerator, firstDenominator);
            var otherFraction = PrepareFractionClass(sndNumerator, sndDenominator);

            Fraction result = test - otherFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }

        [TestCase(1, 11, 11, 0, 1, 1)]
        [TestCase(42, 1, 0, 0, 0, 1)]
        [TestCase(11, 9, 9, 11, 1, 1)]
        public void TestFractionOperatorMultiply(int firstNumerator, int firstDenominator, int sndNumerator, int sndDenominator, int expectedNumerator, int expectedDenominator)
        {
            var test = PrepareFractionClass(firstNumerator, firstDenominator);
            var otherFraction = PrepareFractionClass(sndNumerator, sndDenominator);

            Fraction result = test * otherFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }

        [TestCase(33, 42, 111, 8, 44, 777)]
        [TestCase(0, 1, 1, 1, 0, 1)]
        [TestCase(11, 9, 11, 9, 1, 1)]
        public void TestFractionOperatorDivide(int firstNumerator, int firstDenominator, int sndNumerator, int sndDenominator, int expectedNumerator, int expectedDenominator)
        {
            var test = PrepareFractionClass(firstNumerator, firstDenominator);
            var otherFraction = PrepareFractionClass(sndNumerator, sndDenominator);

            Fraction result = test / otherFraction;
            Assert.Multiple(() =>
            {
                Assert.That(result.Numerator, Is.EqualTo(expectedNumerator));
                Assert.That(result.Denominator, Is.EqualTo(expectedDenominator));
            });
        }

        [Test]
        public void TestFractionOperatorDivideThrowsExceptionIfDividedByZero()
        {
            Assert.That(() => new Fraction(42, 1) / 0, Throws.TypeOf<DivideByZeroException>());
        }

        [TestCase(84,44,42,22)]
        [TestCase(0,1,0,22)]
        [TestCase(1,0,1,1)]
        public void TestFractionCheckTwoFractionHasSameHashCode(int fstNumerator, int fstDenominator, int sndNumerator, int sndDenominator)
        {
            var first = PrepareFractionClass(fstNumerator,fstDenominator);
            var second = PrepareFractionClass(sndNumerator,sndDenominator);

            Assert.That(() => first.GetHashCode(), Is.EqualTo(second.GetHashCode()));
        }

        [TestCase(42,22,20,10)]
        [TestCase(1,0,0,1)]
        [TestCase(102345,500,999,666)]
        public void TestFractionCheckTwoFractionHasDifferentHashCode(int fstNumerator, int fstDenominator, int sndNumerator, int sndDenominator)
        {
            var first = PrepareFractionClass(fstNumerator, fstDenominator);
            var second = PrepareFractionClass(sndNumerator, sndDenominator);

            Assert.That(() => first.GetHashCode(), Is.Not.EqualTo(second.GetHashCode()));
        }

        [TestCase(1,2,2,4)]
        [TestCase(0,1,0,22)]
        [TestCase(1,1,1,0)]
        public void TestFractionConfirmTwoFractionClassAreEquals(int fstNumerator, int fstDenominator, int sndNumerator, int sndDenominator)
        {
            var first = PrepareFractionClass(fstNumerator,fstDenominator);
            var second = PrepareFractionClass(sndNumerator,sndDenominator);

            Assert.That(() => first.Equals(second), Is.True);
        }

        [TestCase(0,1,1,0)]
        [TestCase(33,11,333,11)]
        [TestCase(14,7,7,14)]
        public void TestFractionConfirmTwoFractionClassAreNotEquals(int fstNumerator, int fstDenominator, int sndNumerator, int sndDenominator)
        {
            var first = PrepareFractionClass(fstNumerator, fstDenominator);
            var second = PrepareFractionClass(sndNumerator, sndDenominator);

            Assert.That(() => first.Equals(second), Is.False);
        }

        [Test]
        public void TestFractionReturnFalseIfComparingWithNonFractionClass([Values(null,"10/5",2)]object? obj)
        {
            var first = PrepareFractionClass(10, 5);
            Assert.That(() => first.Equals(obj), Is.False);
        }

        [Test]
        public void TestFractionThrowsExceptionIfFractionIsNull()
        {
            Fraction fraction = null!;
            Assert.That(() => fraction.Equals(new Fraction(1,2)), Throws.TypeOf<NullReferenceException>());
        }


        /* TEST IMPLICIT/EXPLICIT CONVERSION */

        [Test]
        public void TestFractionImplicitConversionIntToFraction([Values(15, -1, 0)] int fromInteger)
        {
            Fraction toFraction = fromInteger;
            Assert.That(toFraction.Denominator, Is.EqualTo(1));
        }

        [Test]
        public void TestFractionSuccessfullyExplicitConvertFractionToInt([Values(33, -4, 0)] int numerator)
        {
            var test = new Fraction(numerator, 1);
            Assert.That((int)test, Is.EqualTo(numerator));
        }

        [Test]
        public void TestFractionThrowsExceptionIfExplicitConversionFractionToIntIsNotValid()
        {
            var test = new Fraction(101, 11);
            Assert.That(() => (int)test, Throws.TypeOf<ArgumentException>());
        }

        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        [TestCase(4,16,"1/4")]
        public void FractionTestReturnCorrectStringConversion(int numerator, int denominator, string expectedResult)
        {
            var test = new Fraction(numerator, denominator);
            Assert.That(() => test.ToString(), Is.EqualTo(expectedResult));
        }
    }
}
