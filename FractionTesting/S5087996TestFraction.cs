using FractionImplementation;

namespace S5087996TestFractions
{
    public class Tests
    {
        
        [TestCase(2,4,1,2)]
        [TestCase(1, -1, -1, 1)]
        public void CorrectnessTest(int numerator, int denominator, int expectedNum, int expectedDen)
        {
            var fr = new Fraction(numerator, denominator);
            Assert.Multiple(() =>
            {
                Assert.That(fr.Numerator, Is.EqualTo(expectedNum));
                Assert.That(fr.Denominator, Is.EqualTo(expectedDen));
            });
        }

        [TestCase(1, 0)]
        // ReSharper disable once ObjectCreationAsStatement
        public void ZeroDenominatorTest(int numerator, int denominator) => Assert.Throws<ArgumentException>(() => new Fraction(numerator, denominator));

        [TestCase(1, 2, 2, 5, 9, 10, '+')]
        [TestCase(4, 1, 33, 7, -5, 7, '-')]
        [TestCase(1, 11, 11, 1, 1, 1, '*')]
        [TestCase(33, 42, 111, 8, 44, 777, '/')]
        [TestCase(42, 1, 0, 1, 0, 1, '*')]
        public void OperationTest(int num1, int den1, int num2, int den2, int expectedNum, int expectedDen, char op)
        {
            var fr1 = new Fraction(num1, den1);
            var fr2 = new Fraction(num2, den2);

            var fr3 = op switch
            {
                '+' => fr1+fr2,
                '-' => fr1-fr2,
                '*' => fr1*fr2,
                '/' => fr1/fr2,
                _ => throw new ArgumentException("Unknown operation")
            };
            
            Assert.Multiple(() =>
            {
                Assert.That(fr3.Numerator, Is.EqualTo(expectedNum));
                Assert.That(fr3.Denominator, Is.EqualTo(expectedDen));
            });
        }

        [TestCase(42, 1)]
        public void ZeroDivisionTest(int num, int den) => Assert.That(() => new Fraction(num, den)/new Fraction(0, 1), Throws.Exception.TypeOf<DivideByZeroException>());

        [TestCase(0, 1, 0, 22)]
        [TestCase(1, 2, 2, 4)]
        public void EqualityTest(int num1, int den1, int num2, int den2)
        {
            var fr1 = new Fraction(num1, den1);
            var fr2 = new Fraction(num2, den2);
            Assert.Multiple(
                () => {
                    Assert.That(fr1, Is.EqualTo(fr2));
                    Assert.True(fr1==fr2);
                    Assert.That(fr1.GetHashCode(), Is.EqualTo(fr2.GetHashCode()));
                }
            );
        }

        [Test]
        public void SameObjectEqualityTest()
        {
            var fr1 = new Fraction(1, 2);
            Assert.Multiple(
                () => {
                    Assert.That(fr1, Is.EqualTo(fr1));
                    Assert.True(fr1==fr1);
                    Assert.That(fr1.GetHashCode(), Is.EqualTo(fr1.GetHashCode()));
                }
            );
        }

        [Test]
        public void EqualityWithBothNullTest() => Assert.That(null, Is.EqualTo(null));

        [Test]
        public void InequalityWithNullTest() => Assert.That(new Fraction(1, 2), Is.Not.EqualTo(null));

        [Test]
        public void InequalityWithDifferentTypeTest()
        {
            var fr1 = new Fraction(1, 2);
            Assert.Multiple(
                () => {
                    Assert.That(fr1, Is.Not.EqualTo(1));
                    Assert.False(fr1==1);
                }
            );
        }

        [TestCase(0, 1, 1, 22)]
        [TestCase(1, 2, 3, 4)]
        public void InequalityTest(int num1, int den1, int num2, int den2)
        {
            var fr1 = new Fraction(num1, den1);
            var fr2 = new Fraction(num2, den2);
            Assert.Multiple(
                () => {
                    Assert.That(fr1, Is.Not.EqualTo(fr2));
                    Assert.True(fr1!=fr2);
                    Assert.That(fr1.GetHashCode(), Is.Not.EqualTo(fr2.GetHashCode()));
                }
            );
        }

        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void StringRepresentationTest(int num, int den, string expected) => Assert.That(new Fraction(num, den).ToString(), Is.EqualTo(expected));

        [TestCase(42, 42, 1)]
        [TestCase(0, 0, 1)]
        public void IntToFractionConversionTest(int number, int expectedNum, int expectedDen)
        {
            Fraction fr = number;
            Assert.Multiple(() => {
                Assert.That(fr.Numerator, Is.EqualTo(expectedNum));
                Assert.That(fr.Denominator, Is.EqualTo(expectedDen));
            });
        }

        [TestCase(42, 1, 42)]
        public void SuccessfulFractionToIntConversionTest(int num, int den, int expected) => Assert.That((int)new Fraction(num, den), Is.EqualTo(expected));

        [TestCase(42, 11)]
        public void UnsuccessfulFractionToIntConversionTest(int num, int den) => Assert.That(() => (int)new Fraction(num, den), Throws.Exception.TypeOf<InvalidCastException>());
    }
}