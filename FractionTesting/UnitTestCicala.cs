using FractionClass;

namespace TestFraction {
    public class Tests {

        [Test, Sequential]
        public void ConstructorWithoutNormalization([Values(1)] int numerator, [Values(2)] int denominator, [Values(1)] int expectedNumerator, [Values(2)] int expectedDenominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.Multiple(() => { Assert.That(fract.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(fract.Denominator, Is.EqualTo(expectedDenominator)); });
        }
        [Test, Sequential]
        public void ConstructorCheckDenominatorAlwaysPositive([Values(5, -7, 3, -2)] int numerator, [Values(-3, 5, 2, -7)] int denominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(fract.Denominator, Is.GreaterThan(0));
        }

        [Test, Sequential]
        public void ConstructorCheckDenominatorValueWithNegativeNumber([Values(5, -7, -2)] int numerator, [Values(-3, 5, -7)] int denominator, [Values(3, 5, 7)] int expectedDenominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(fract.Denominator, Is.EqualTo(expectedDenominator));
        }

        [Test, Sequential]
        public void ConstructorCheckNumeratorValue([Values(5, -7, -2, 0, 0)] int numerator, [Values(-3, 5, -7, -2, 2)] int denominator, [Values(-5, -7, 2, 0, 0)] int expectedNumerator) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(fract.Numerator, Is.EqualTo(expectedNumerator));
        }

        [Test, Sequential]
        public void ConstructorCheckSignValue([Values(5, -7, -2, 0, 0)] int numerator, [Values(-3, 5, -7, 2, -2)] int denominator, [Values(-1, -1, 1, 0, 0)] int expectedSign) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(Math.Sign(fract.Numerator), Is.EqualTo(expectedSign));
        }

        [Test, Sequential]
        public void ConstructorCheckNormalization([Values(30, 70, 5)] int numerator, [Values(42, 10, 25)] int denominator, [Values(5, 7, 1)] int expectedNumerator, [Values(7, 1, 5)] int expectedDenominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.Multiple(() => { Assert.That(fract.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(fract.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void ConstructorCheckNormalizationWithSign([Values(90, -91, -100)] int numerator, [Values(-525, 26, -200)] int denominator, [Values(-6, -7, 1)] int expectedNumerator, [Values(35, 2, 2)] int expectedDenominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.Multiple(() => { Assert.That(fract.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(fract.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void ConstructorCheckExceptionDenominatorValue0([Values(1)] int numerator, [Values(0)] int denominator) {
            Assert.That(() => new Fraction(numerator, denominator), Throws.TypeOf<ArgumentException>());
        }
        [Test, Sequential]
        public void CheckSum([Values(1, 1, 3)] int numerator1, [Values(2, 3, 10)] int denominator1, [Values(2, 1, 5)] int numerator2, [Values(5, 6, 4)] int denominator2, [Values(9, 1, 31)] int expectedNumerator, [Values(10, 2, 20)] int expectedDenominator) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1 + fract2;
            Assert.Multiple(() => { Assert.That(res.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(res.Denominator, Is.EqualTo(expectedDenominator)); });
        }
        [Test, Sequential]
        public void CheckDifference([Values(4, -1, 3)] int numerator1, [Values(1, 3, 10)] int denominator1, [Values(33, 1, 5)] int numerator2, [Values(7, 6, 4)] int denominator2, [Values(-5, -1, -19)] int expectedNumerator, [Values(7, 2, 20)] int expectedDenominator) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1 - fract2;
            Assert.Multiple(() => { Assert.That(res.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(res.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void CheckMultiplication([Values(1, -3, -2)] int numerator1, [Values(11, 5, 7)] int denominator1, [Values(11, 2, -3)] int numerator2, [Values(1, 9, 5)] int denominator2, [Values(1, -2, 6)] int expectedNumerator, [Values(1, 15, 35)] int expectedDenominator) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1 * fract2;
            Assert.Multiple(() => { Assert.That(res.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(res.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void CheckDivision([Values(1, -1, -2)] int numerator1, [Values(11, 11, 7)] int denominator1, [Values(11, 1, -4)] int numerator2, [Values(1, 11, 49)] int denominator2, [Values(1, -1, 7)] int expectedNumerator, [Values(121, 1, 2)] int expectedDenominator) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1 / fract2;
            Assert.Multiple(() => { Assert.That(res.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(res.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void CheckDivisionBy0ThrowException([Values(1)] int numerator1, [Values(2)] int denominator1, [Values(0)] int numerator2, [Values(1)] int denominator2) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            Assert.That(() => fract1 / fract2, Throws.TypeOf<ArgumentException>());
        }

        [Test, Sequential]
        public void CheckToString([Values(11, 22, -22)] int numerator, [Values(5, 11, 11)] int denominator, [Values("11/5", "2", "-2")] string expectedString) {
            var fract = new Fraction(numerator, denominator);
            string res = fract.ToString();
            Assert.That(res, Is.EqualTo(expectedString));
        }

        [Test, Sequential]
        public void CheckEquals([Values(0, 1)] int numerator1, [Values(1, 2)] int denominator1, [Values(0, 2)] int numerator2, [Values(22, 4)] int denominator2) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            Assert.That(fract1.Equals(fract2), Is.True);
        }

        [Test, Sequential]
        public void CheckNotEquals([Values(0, 1)] int numerator1, [Values(1, 3)] int denominator1, [Values(1, 2)] int numerator2, [Values(22, 4)] int denominator2) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            Assert.That(fract1.Equals(fract2), Is.False);
        }

        [Test, Sequential]
        public void CheckEqualsNull([Values(0, 1)] int numerator, [Values(1, 2)] int denominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(fract.Equals(null), Is.False);
        }

        [Test, Sequential]
        public void CheckEqualsObject([Values(0, 1)] int numerator, [Values(1, 2)] int denominator) {
            var fract = new Fraction(numerator, denominator);
            var obj = new object();
            Assert.That(fract.Equals(obj), Is.False);
        }

        [Test, Sequential]
        public void CheckEqualsHashCode([Values(0, 1)] int numerator1, [Values(1, 2)] int denominator1, [Values(0, 2)] int numerator2, [Values(22, 4)] int denominator2) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1.GetHashCode() == fract2.GetHashCode();
            Assert.That(res, Is.True);
        }

        [Test, Sequential]
        public void CheckNotEqualsHashCode([Values(0, 1)] int numerator1, [Values(1, 3)] int denominator1, [Values(1, 2)] int numerator2, [Values(22, 4)] int denominator2) {
            var fract1 = new Fraction(numerator1, denominator1);
            var fract2 = new Fraction(numerator2, denominator2);
            var res = fract1.GetHashCode() == fract2.GetHashCode();
            Assert.That(res, Is.False);
        }

        [Test, Sequential]
        public void CheckImplictCastIntToFraction([Values(2, 0)] int number, [Values(2, 0)] int expectedNumerator, [Values(1, 1)] int expectedDenominator) {
            Fraction fract = number;
            Assert.Multiple(() => { Assert.That(fract.Numerator, Is.EqualTo(expectedNumerator)); Assert.That(fract.Denominator, Is.EqualTo(expectedDenominator)); });
        }

        [Test, Sequential]
        public void CheckExplicitCastFractionToInt([Values(42)] int numerator, [Values(1)] int denominator, [Values(42)] int expectedNumber) {
            var fract = new Fraction(numerator, denominator);
            int res = (int)fract;
            Assert.That(res, Is.EqualTo(expectedNumber));
        }

        [Test, Sequential]
        public void CheckCastThrowException([Values(7)] int numerator, [Values(3)] int denominator) {
            var fract = new Fraction(numerator, denominator);
            Assert.That(() => (int)fract, Throws.TypeOf<ArgumentException>());
        }
    }
}