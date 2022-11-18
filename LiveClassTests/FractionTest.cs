using System.Security.Cryptography.X509Certificates;

namespace FractionTesting {
    using FractionImplementation;
    using System;

    public class FractionTests {
        Random Generator => new Random();
        Fraction RandomGeneration() {
            var den = Generator.Next(1, Int32.MaxValue);
            var num = Generator.Next();
            if ((num + den) % 2 == 0) num *= -1;
            return new Fraction(num, den);
        }
        [TestCase(5, 7)]
        [TestCase(-5, 7)]
        [TestCase(5, 11)]
        [TestCase(-44, 73)]
        public void ConstructorOnCoprimePositiveOk(int num, int den) {
            var result = new Fraction(num, den);
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(num));
                Assert.That(result.Denominator, Is.EqualTo(den));
            });
        }
        [TestCase(5, -7, -5, 7)]
        public void ConstructorOnCoprimeOk(int inNum, int inDen, int outNum, int outDen) {
            var result = new Fraction(inNum, inDen);
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(8)]
        public void ConstructorThrowsIfDenominatorIs0(int num) {
            Assert.That(() => {
                var x = new Fraction(num, 0);
            }, Throws.TypeOf<ArgumentException>());
        }
        [TestCase(2, 4, 1, 2)]
        [TestCase(3 * 11, 4 * 11, 3, 4)]
        [TestCase(31 * 11, 4 * 11, 31, 4)]
        [TestCase(31 * 1432, -4 * 1432, -31, 4)]
        public void ConstructorSimplifies(int inNum, int inDen, int outNum, int outDen) {
            var result = new Fraction(inNum, inDen);
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(3, 5, 7, 2, 41, 10)]
        [TestCase(1, 2, 2, 5, 9, 10)]
        [TestCase(-18, 20, 33, -11, -39, 10)]
        [TestCase(1, 2, 1, 4, 3, 4)]
        [TestCase(-1, 2, 1, 2, 0, 1)]
        [TestCase(1, 243, 0, 1, 1, 243)]
        public void SumOk(int inNum1, int inDen1, int inNum2, int inDen2, int outNum, int outDen) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            var result = f1 + f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(3, 5, 7, 2, -29, 10)]
        [TestCase(1, 2, -2, 5, 9, 10)]
        [TestCase(3, 4, 1, 4, 1, 2)]
        [TestCase(1, 2, 2, 5, 1, 10)]
        [TestCase(-3, 4, 1, 4, -1, 1)]
        [TestCase(1, 2, 1, 4, 1, 4)]
        [TestCase(1, 2, 1, 2, 0, 1)]
        [TestCase(1, 243, 0, 1, 1, 243)]
        public void DifferenceOk(int inNum1, int inDen1, int inNum2, int inDen2, int outNum, int outDen) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            var result = f1 - f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(3, 5, 7, 2, 21, 10)]
        [TestCase(1, 2, 2, 5, 1, 5)]
        [TestCase(3, 4, 1, 4, 3, 16)]
        [TestCase(1, 2, -2, 5, -1, 5)]
        [TestCase(-3, 4, 4, 9, -1, 3)]
        [TestCase(1, 2, 2, 3, 1, 3)]
        [TestCase(1, 2, 0, 3, 0, 1)]
        [TestCase(0, 2, 2, 3, 0, 1)]
        public void ProductOk(int inNum1, int inDen1, int inNum2, int inDen2, int outNum, int outDen) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            var result = f1 * f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(3, 5, 2, 7, 21, 10)]
        [TestCase(1, 2, 5, 2, 1, 5)]
        [TestCase(3, 4, 4, 1, 3, 16)]
        [TestCase(1, 2, -5, 2, -1, 5)]
        [TestCase(-3, 4, 9, 4, -1, 3)]
        [TestCase(1, 2, 3, 2, 1, 3)]
        public void DivisionOk(int inNum1, int inDen1, int inNum2, int inDen2, int outNum, int outDen) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            var result = f1 / f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
        [TestCase(1, 2)]
        [TestCase(-51, 112)]
        [TestCase(0, 1)]
        public void DivisionByZeroThrows(int inNum1, int inDen1) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(0, 1);
            Assert.That(() => {
                var x = f1 / f2;
            }, Throws.TypeOf<DivideByZeroException>());
        }
        [Test]
        public void SameInstanceEquals() {
            var f = new Fraction(5, 6);
            Assert.That(f.Equals(f), Is.True);
        }
        [TestCase(3, 5)]
        [TestCase(0, 1)]
        [TestCase(3, 4)]
        [TestCase(-3, 4)]
        [TestCase(11, 1)]
        public void DifferentInstancesSameValueEqualsIsTrue(int inNum, int inDen) {
            var f1 = new Fraction(inNum, inDen);
            var f2 = new Fraction(inNum, inDen);
            Assert.That(f1.Equals(f2), Is.True);
        }
        [TestCase(2, 4, 1, 22)]
        [TestCase(2, 7, -73, 4)]
        [TestCase(0, 1, 31, 4)]
        [TestCase(-31, 4, 0, 1)]
        public void DifferentValuesEqualsIsFalse(int inNum1, int inDen1, int inNum2, int inDen2) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            Assert.That(f1.Equals(f2), Is.False);
        }
        [Test]
        public void GetHashCodeIsNotConstant() {
            var sampleSize = 100;
            var knownHash = RandomGeneration().GetHashCode();
            for (int i = 0; i < sampleSize; i++) {
                if (RandomGeneration().GetHashCode() != knownHash) {
                    Assert.Pass();
                    return;
                }
            }
            Assert.Fail($"{sampleSize} randomly generated fractions have the same Hash Code");
        }
        [Test]
        public void GetHashCodePreservesEquality() {
            var sampleSize = 100;
            for (int i = 0; i < sampleSize; i++) {
                var f1 = RandomGeneration();
                var f2 = new Fraction(f1.Numerator, f1.Denominator);
                if (Equals(!f1.Equals(f2)))
                    Assert.Inconclusive("Two fractions with the same numerator and denominator should be equal");
                var hashCode = f1.GetHashCode();
                Assert.That(hashCode, Is.EqualTo(f2.GetHashCode()));
            }
        }
        [TestCase(3, 5, "3/5")]
        [TestCase(-3, 52, "-3/52")]
        public void ToStringOnProperFractionsOk(int inNum, int inDen, string expected) {
            var actual = new Fraction(inNum, inDen).ToString();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(3435, "3435")]
        [TestCase(-452, "-452")]
        [TestCase(0, "0")]
        public void ToStringOnIntegersAsFractionsOk(int inNum, string expected) {
            var actual = new Fraction(inNum, 1).ToString();
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(363)]
        [TestCase(0)]
        [TestCase(-7464)]
        public void ExplicitConversionOk(int expected) {
            var actual = (int)new Fraction(expected, 1);
            Assert.That(actual, Is.EqualTo(expected));
        }
        [TestCase(45, 77)]
        [TestCase(-63, 74)]
        public void ExplicitConversionThrows(int inNum, int inDen) {
            var receiver = new Fraction(inNum, inDen);
            Assert.That(() => {
                var x = (int)receiver;
            }, Throws.TypeOf<InvalidOperationException>());
        }
        [TestCase(363)]
        [TestCase(0)]
        [TestCase(-7464)]
        public void ImplicitConversionOk(int expected) {
            Fraction actual = expected;
            Assert.Multiple(() => {
                Assert.That(actual.Numerator, Is.EqualTo(expected));
                Assert.That(actual.Denominator, Is.EqualTo(1));
            });
        }
    }
}