/*using System.Net.WebSockets;
using FractionImplementation;

namespace TestLab1
{
    public class FractionTests
    {
        private Fraction fract = new Fraction();

        [SetUp]
        public void Setup()
        {

        }

        [TestCase(10, 0, "")]
        [TestCase(2, 4, "1/2")]
        [TestCase(1, -1, "-1")]
        public void TestCostr(int x, int y, String str)
        {
            try
            {
                Fraction z = new Fraction(x, y);
                Assert.That(z.ToString(), Is.EqualTo(str));
            }
            catch (Exception e)
            {
                if (e.Message == "Denominator mustn't be 0") Assert.Pass($"{e}");
                else Assert.Fail($"{e}");
            }
        }

        [TestCase(1, 2, 2, 5, "9/10")]
        public void TestSum(int a, int b, int c, int d, String str)
        {
            var e = new Fraction(a, b);
            var f = new Fraction(c, d);
            Assert.That(fract.Sum(e, f).ToString(), Is.EqualTo(str));
        }

        [TestCase(4, 1, 33, 7, "-5/7")]
        public void TestDiff(int a, int b, int c, int d, String str)
        {
            var e = new Fraction(a, b);
            var f = new Fraction(c, d);
            Assert.That(fract.Diff(e, f).ToString(), Is.EqualTo(str));
        }

        [TestCase(1, 11, 11, 1, "1")]
        [TestCase(42, 1, 0, 1, "0")]
        public void TestProd(int a, int b, int c, int d, String str)
        {
            try
            {
                var e = new Fraction(a, b);
                var f = new Fraction(c, d);
                Assert.That(fract.Prod(f, e).ToString(), Is.EqualTo(str));
            }
            catch (Exception e)
            {
                if (e.Message == "The second Numerator can't be 0") Assert.Pass($"{e}");
                
                Assert.Fail($"{e}");
            }
        }

        [TestCase(33, 42, 111, 8, "44/777")]
        [TestCase(42, 1, 0, 1, "")]
        public void TestDiv(int a, int b, int c, int d, String str)
        {
            try
            {
                var e = new Fraction(a, b);
                var f = new Fraction(c, d);
                Assert.That(fract.Div(e, f).ToString(), Is.EqualTo(str));
            }
            catch (Exception e)
            {
                if (e.Message == "Denominator mustn't be 0") Assert.Pass($"{e}");
                if (e.Message == "The second Numerator can't be 0") Assert.Pass($"{e}");
                Assert.Fail($"{e}");
            }
        }

        [TestCase(0, 1, 0, 42, "True")]
        [TestCase(1, 2, 2, 4, "True")]
        public void TestEquals(int a, int b, int c, int d, String str)
        {
            var e = new Fraction(a, b);
            var f = new Fraction(c, d);
            Assert.That(Equals(e, f).ToString(), Is.EqualTo(str));
        }

        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void TestString(int a, int b, String str)
        {
            var e = new Fraction(a, b);
            Assert.That(e.ToString(), Is.EqualTo(str));
        }

        [TestCase(42, "42/1")]
        [TestCase(0, "0/1")]
        public void TestConvImp(int a, String str)
        {
            String ris= fract.ImplicitConv(a);
            Assert.That(ris, Is.EqualTo(str));
        }

        [TestCase(42, 1, "42")]
        [TestCase(42, 11, "")]
        public void TestConvEsp(int a, int b, String str)
        {
            try
            {
                var c = new Fraction(a, b);
                String ris = fract.EsplicitConv(c);
                Assert.That(ris, Is.EqualTo(str));
            }
            catch (Exception e)
            {
                if (e.Message == "The Denominator must be 1") Assert.Pass($"{e}");
                Assert.Fail($"{e}");
            }
        }
    }
}*/