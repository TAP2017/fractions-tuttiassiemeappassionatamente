using Fra;
using NUnit.Framework;

namespace UnitTest
{
    public class NewFractionTests
    {
        private Fraction _frac = null!;
        private Fraction _frac2 = null!;
        private Fraction _fracRes = null!;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(5,7)]
        [TestCase(22, 15)]
        public void NumAndDenCoPrimesPositiveGetSameValues(int num, int den)
        {
            _frac = new Fraction(num, den);
            Assert.Multiple(() =>
            {
                Assert.That(_frac.Numerator, Is.EqualTo(num));
                Assert.That(_frac.Denumerator, Is.EqualTo(den));
            });
        }

        [Test]
        [TestCase(1, -1)]
        [TestCase(-5, 7)]
        [TestCase(22, -15)]
        [TestCase(-22, -15)]
        public void NumAndDenCoPrimesNotBothPositiveGetDenPositive(int num, int den)
        {
            _frac = new Fraction(num, den);
            Assert.That(_frac.Denumerator,Is.GreaterThan(0));
        }

        [Test]
        [TestCase(1,-1)]
        [TestCase(-5, 7)]
        [TestCase(22, -15)]
        [TestCase(-22, -15)]
        public void NumAndDenCoPrimesNotBothPositiveGetRightDen(int num, int den)
        {
            _frac = new Fraction(num, den);
            Assert.That(_frac.Denumerator, Is.EqualTo(den < 0 ? -den : den));
        }

        [Test]
        [TestCase(1, -1)]
        [TestCase(-5, 7)]
        [TestCase(22, -15)]
        [TestCase(-22, -15)]
        public void NumAndDenCoPrimesNotBothPositiveGetRightNum(int num,int den)
        {
            _frac = new Fraction(num, den);
            Assert.That(_frac.Numerator, Is.EqualTo(den < 0 ? -num : num));
        }

        [Test]
        [TestCase(2, 4, 1, 2)]
        [TestCase(30, 42,5,7)]
        [TestCase(22, 10,11,5)]
        public void NumAndDenNotCoPrimesPositiveGetRightValues(int num, int den, int nres,int dres)
        {
            _frac = new Fraction(num, den);
            Assert.Multiple(() =>
            {
                Assert.That(_frac.Numerator, Is.EqualTo(nres));
                Assert.That(_frac.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase(-30, 42, -5, 7)]
        [TestCase(22, -10, -11, 5)]
        [TestCase(-22, -10, 11, 5)]
        public void NumAndDenNotCoPrimesNotBothPositiveGetRightValues(int num, int den, int nres, int dres)
        {
            _frac = new Fraction(num, den);
            Assert.Multiple(() =>
            {
                Assert.That(_frac.Numerator, Is.EqualTo(nres));
                Assert.That(_frac.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase(5)]
        [TestCase(-7)]
        public void DenEqualsZeroThrows(int n)
        {
            Assert.That(() => _frac = new Fraction(n, 0), Throws.InstanceOf< DivideByZeroException> ());
        }

        [Test]
        [TestCase(1, 2, 2, 5, 9, 10)]
        public void SumPositiveFractions(int n1, int d1, int n2, int d2, int nres, int dres)
        {
            _frac = new Fraction(n1, d1);
            _frac2 = new Fraction(n2, d2);
            _fracRes = _frac + _frac2;
            Assert.Multiple(() =>
            {
                Assert.That(_fracRes.Numerator, Is.EqualTo(nres));
                Assert.That(_fracRes.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase( 4, 1,33,7, -5, 7)]
        public void SubPositiveFractions(int n1, int d1, int n2, int d2, int nres, int dres)
        {
            _frac = new Fraction(n1, d1);
            _frac2 = new Fraction(n2, d2);
            _fracRes = _frac - _frac2;
            Assert.Multiple(() =>
            {
                Assert.That(_fracRes.Numerator, Is.EqualTo(nres));
                Assert.That(_fracRes.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase(4, 33, 7, -5, 7)]
        public void SubPositiveFractionFromInt(int i, int n, int d, int nres, int dres)
        {
            _frac = new Fraction(i);
            _frac2 = new Fraction(n, d);
            _fracRes = _frac - _frac2;
            Assert.Multiple(() =>
            {
                Assert.That(_fracRes.Numerator, Is.EqualTo(nres));
                Assert.That(_fracRes.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase(1, 11, 11, 1, 1, 1)]
        public void MulPositiveFractions(int n1, int d1, int n2, int d2, int nres, int dres)
        {
            _frac = new Fraction(n1, d1);
            _frac2 = new Fraction(n2, d2);
            _fracRes = _frac * _frac2;
            Assert.Multiple(() =>
            {
                Assert.That(_fracRes.Numerator, Is.EqualTo(nres));
                Assert.That(_fracRes.Denumerator, Is.EqualTo(dres));
            });
        }

        [Test]
        [TestCase(33, 42, 111, 8, 44, 777)]
        public void DivPositiveFractions(int n1, int d1, int n2, int d2, int nres, int dres)
        {
            _frac = new Fraction(n1, d1);
            _frac2 = new Fraction(n2, d2);
            _fracRes = _frac / _frac2;
            Assert.Multiple(() =>
            {
                Assert.That(_fracRes.Numerator, Is.EqualTo(nres));
                Assert.That(_fracRes.Denumerator, Is.EqualTo(dres));
            });
        }


        [Test]
        [TestCase(33, 42)]
        [TestCase(44, 2)]
        public void MulPositiveFractionByZero(int n, int d)
        {
            _frac = new Fraction(n, d);
            Assert.That(_frac * 0, Is.EqualTo(0));
        }

        [Test]
        [TestCase(33,44)]
        [TestCase(-4,82)]
        public void CompareFractionsThatAreEqualToZero(int d1,int d2)
        {
            _frac= new Fraction(0,d1);
            _frac2 = new Fraction(0,d2);
            Assert.That(_frac, Is.EqualTo(_frac2));
        }

        [Test]
        [TestCase(1, 2, 2, 4)]
        [TestCase(-4, 8, 16, -32)]
        public void CompareFractionsThatAreEqualOnceFactorized(int n1, int d1, int n2, int d2)
        {
            _frac = new Fraction(n1, d1);
            _frac2 = new Fraction(n2, d2);
            Assert.That(_frac, Is.EqualTo(_frac2));
        }

        [Test]
        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void CompareToStringWithActualString(int n, int d, string s)
        {
            _frac = new Fraction(n, d);
            Assert.That(_frac.ToString(), Is.EqualTo(s));
        }

        [Test]
        [TestCase(42, 1, 42)]
        public void RoundFractionGetRightConversionToInt(int n, int d, int r)
        {
            _frac=new Fraction(n, d);
            Assert.That((int)_frac,Is.EqualTo(r));
        }
        [Test]
        [TestCase(42, 11)]
        public void NotRoundFractionGetsCastException(int n, int d)
        {
            _frac = new Fraction(n, d);
            Assert.That(() => (int)_frac, Throws.InstanceOf<InvalidCastException>());
        }
    }
}