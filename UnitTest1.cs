using Frazioni;
using System;

namespace TestingFrazioni {
    public class Tests {
        private Fraction _fraction1;
        private Fraction _fraction2;
        private Fraction _result;
        [SetUp]
        public void Setup() {
        }
        //Constructor Tests
        [Test, Sequential]
        public void CorrectAssignmentOfArgs([Values(5, 22, 7, 17)]int num, [Values(7, 15, 11, 14)] int den) {
            _fraction1 = new Fraction(num, den);
            Assert.Multiple(() => {
                Assert.That(_fraction1.Numerator, Is.EqualTo(num)); 
                Assert.That(_fraction1.Denominator, Is.EqualTo(den));
            });
        }

        [Test]
        public void DenominatorIsPositive([Values(30, 2, -5, -27, 1)]int num, [Values(-27, 4, -7, 5, -1)]int den) {
            _fraction1 = new Fraction(num, den);
            Assert.That(_fraction1.Denominator, Is.Positive);
        }

        [Test, Sequential]
        public void DenominatorHasRightAbsValue([Values(30, 2, 5, -27, -34)]int num, [Values(7, 15, -11, -14, 7)]int den) {
            _fraction1 = new Fraction(num, den);
            Assert.That(_fraction1.Denominator, Is.EqualTo(Math.Abs(den)));
        }

        [Test, Sequential]
        public void CheckNumeratorSign([Values(30, 2, 5, -27, -34)] int num, [Values(7, 15, -11, -14, 7)] int den) {
            _fraction1 = new Fraction(num, den);
            Assert.That(_fraction1.Numerator, Is.EqualTo(den < 0 ? -num : num));
        }

        [TestCase(30, 42, 5, 7)]
        [TestCase(9, 27, 1, 3)]
        [TestCase(5, 25, 1, 5)]
        [TestCase(30, 120, 1, 4)]
        [TestCase(2, 4, 1, 2)]
        public void NumAndDenBothPositiveGetNormalized(int num, int den, int norm_num, int norm_den) {
            _fraction1 = new Fraction(num, den);
            Assert.Multiple(()=> {
                Assert.That(_fraction1.Numerator, Is.EqualTo(norm_num));
                Assert.That(_fraction1.Denominator, Is.EqualTo(norm_den));
            });
        }

        [TestCase(-30, 42, -5, 7)]
        [TestCase(9, -27, -1, 3)]
        [TestCase(-5, -25, 1, 5)]
        [TestCase(30, 120, 1, 4)]
        public void NumAndDenNotBothPositiveGetNormalized(int num, int den, int norm_num, int norm_den) {
            _fraction1 = new Fraction(num, den);
            Assert.Multiple(() => {
                Assert.That(_fraction1.Numerator, Is.EqualTo(norm_num));
                Assert.That(_fraction1.Denominator, Is.EqualTo(norm_den));
            });
        }

        [TestCase(-35)]
        [TestCase(2)]
        public void DenEqualsToZeroThrowsDivideByZeroException(int num) {
            Assert.That(()=> new Fraction(num, 0), Throws.TypeOf<DivideByZeroException>());
        }

        //Operators Tests
        [TestCase(1, 2, 1, 2, 1, 1)]
        [TestCase(-1, -2, 1, 2, 1, 1)]
        [TestCase(1, 2, -1, -2, 1, 1)]
        [TestCase(1, -2, -1, -2, 0, 1)]
        [TestCase(3, 2, 5, 7, 31, 14)]
        [TestCase(3, 2, -5, 7, 11, 14)]
        [TestCase(3, 2, 5, -7, 11, 14)]
        [TestCase(-4, 5, 3, 2, 7, 10)]
        [TestCase(4, -5, 3, 2, 7, 10)]
        [TestCase(-5, 1, 2, 3, -13, 3)]
        [TestCase(1, 2, 2, 5, 9, 10)]
        public void CheckSumFractions(int num1, int den1, int num2, int den2, int nres, int dres) {
            _fraction1 = new Fraction(num1, den1);
            _fraction2 = new Fraction(num2, den2);
            _result = _fraction1 + _fraction2;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [TestCase(1, 2, 1, 2, 0, 1)]
        [TestCase(-1, -2, 1, 2, 0, 1)]
        [TestCase(1, 2, -1, -2, 0, 1)]
        [TestCase(-1, -2, -1, -2, 0, 1)]
        [TestCase(-3, 2, 5, 7, -31, 14)]
        [TestCase(3, -2, 5, 7, -31, 14)]
        [TestCase(3, 2, -5, 7, 31, 14)]
        [TestCase(3, 2, 5, -7, 31, 14)]
        [TestCase(3, -2, -5, 7, -11, 14)]
        public void CheckSubFractions(int num1, int den1, int num2, int den2, int nres, int dres) {
            _fraction1 = new Fraction(num1, den1);
            _fraction2 = new Fraction(num2, den2);
            _result = _fraction1 - _fraction2;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [TestCase(1, 2, 1, 2, 1, 4)]
        [TestCase(3, 4, 5, 2, 15, 8)]
        [TestCase(4, 5, 3, 2, 6, 5)]
        public void CheckMulFractions(int num1, int den1, int num2, int den2, int nres, int dres) {
            _fraction1 = new Fraction(num1, den1);
            _fraction2 = new Fraction(num2, den2);
            _result = _fraction1 * _fraction2;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [TestCase(33, 42, 111, 8, 44, 777)]
        [TestCase(3, 4, 5, 2, 3, 10)]
        [TestCase(4, 5, -3, 2, -8, 15)]
        public void CheckDivFractions(int num1, int den1, int num2, int den2, int nres, int dres) {
            _fraction1 = new Fraction(num1, den1);
            _fraction2 = new Fraction(num2, den2);
            _result = _fraction1 / _fraction2;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [Test]
        public void DivFractionByZeroThrowsDivideByZeroException() {
            _fraction1 = new Fraction(42, 1);
            Assert.That(()=>_fraction1/0, Throws.TypeOf<DivideByZeroException>());
        }

        [TestCase(4, 1, 2, 9, 2)]
        [TestCase(-2, 4, 5, -6, 5)]
        public void CheckSumBetweenIntAndFraction(int i, int num, int den, int nres, int dres) {
            _fraction1 = new Fraction(num, den);
            _result = i+_fraction1;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [TestCase(4, 1, 2, 7, 2)]
        [TestCase(-2, 4, 5, -14, 5)]
        [TestCase(4, 33, 7, -5, 7)]
        public void CheckSubBetweenIntAndFraction(int i, int num, int den, int nres, int dres) {
            _fraction1 = new Fraction(num, den);
            _result = i - _fraction1;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }

        [TestCase(4, 1, 2, 2, 1)]
        [TestCase(-2, 4, 5, -8, 5)]
        [TestCase(11, 1, 11, 1, 1)]
        [TestCase(0, 42, 1, 0, 1)]
        public void CheckMulBetweenIntAndFraction(int i, int num, int den, int nres, int dres) {
            _fraction1 = new Fraction(num, den);
            _result = i * _fraction1;
            Assert.Multiple(() => {
                Assert.That(_result.Numerator, Is.EqualTo(nres));
                Assert.That(_result.Denominator, Is.EqualTo(dres));
            });
        }
        //TypeConversions
        [Test]
        public void IntToFractionImplicitConversion([Values(42, 0, -42, 5, -7)]int n) {
            _fraction1 = n;
            Assert.Multiple(() => {
                Assert.That(_fraction1.Numerator, Is.EqualTo(n));
                Assert.That(_fraction1.Denominator, Is.EqualTo(1));
            });
        }

        [TestCase(42, 1, 42)]
        [TestCase(69, -1, -69)]
        [TestCase(-33, 1, -33)]
        public void ExplicitConversionFractionToIntOnDenEqualsOneIsApplied(int num, int den, int i) {
            _fraction1 = new Fraction(num, den);
            int fConverted = (int) _fraction1;
            Assert.That(fConverted, Is.EqualTo(i));
        }

        [Test]
        public void ExplicitConversionFractionToIntOnDenNotEqualsToOneThrowsInvalidCastException() {
            _fraction1 = new Fraction(33, 42);
            Assert.That(()=>(int)_fraction1, Throws.TypeOf<InvalidCastException>());
        }
        //others
        [TestCase(2, 4, "1/2")]
        [TestCase(6, -3, "-2")]
        [TestCase(-5, 2, "-5/2")]
        [TestCase(4, -3, "-4/3")]
        [TestCase(9, 3, "3")]
        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void ToStringConvertsFractionIntoStringCorrectly(int num, int den, string str) {
            _fraction1 = new Fraction(num, den);
            Assert.That(_fraction1.ToString(), Is.EqualTo(str)); 
        }

        [TestCase(0, 1, 0, 22)]
        [TestCase(1, 2, 2, 4)]
        [TestCase(25, 5, 5, 1)]
        public void AssessmentOfTrueEquals(int num1, int den1, int num2, int den2) {
            _fraction1= new Fraction(num1, den1);
            _fraction2= new Fraction(num2, den2);
            var eq = _fraction1.Equals(_fraction2);
            Assert.That(eq, Is.True);
        }

        [TestCase(0, 1, 35, 22)]
        [TestCase(1, 2, 3, 4)]
        [TestCase(25, 5, 3, 1)]
        public void AssessmentOfFalseEquals(int num1, int den1, int num2, int den2) {
            _fraction1 = new Fraction(num1, den1);
            _fraction2 = new Fraction(num2, den2);
            var eq = _fraction1.Equals(_fraction2);
            Assert.That(eq, Is.False);
        }
    }
}