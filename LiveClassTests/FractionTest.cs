using System.Security.Cryptography.X509Certificates;

namespace FractionTesting {
    using FractionImplementation;
    using System;

    public class FractionTests {

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
                var x = new Fraction(num, 0);},Throws.TypeOf<ArgumentException>());
        }
        [TestCase(2,4,1,2)]
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
        public void SumOk(int inNum1, int inDen1, int inNum2, int inDen2, int outNum, int outDen) {
            var f1 = new Fraction(inNum1, inDen1);
            var f2 = new Fraction(inNum2, inDen2);
            var result = f1 + f2;
            Assert.Multiple(() => {
                Assert.That(result.Numerator, Is.EqualTo(outNum));
                Assert.That(result.Denominator, Is.EqualTo(outDen));
            });
        }
    }
}