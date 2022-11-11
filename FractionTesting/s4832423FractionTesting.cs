namespace FractionTesting;

using Fraction;
using NUnit.Framework;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void BuildFractionWithDenominatorEqualToZeroAndThrowException()
    {
        const int n = 4;
        const int d = 0;
        Assert.That(()=> new Fraction(n, d), Throws.TypeOf<ArgumentException>());
    }

    [TestCase(2, 1, 4, 2)]
    [TestCase(1, -1, -1, 1)]
    [TestCase(90, -6, -525, 35)]
    public void BuildFractionAndVerifyResult(int n1, int n2, int d1, int d2)
    {
        var normalized = new Fraction(n1, d1);
        Assert.Multiple(() => { 
            Assert.That(normalized.Numerator, Is.EqualTo(n2)); 
            Assert.That(normalized.Denominator, Is.EqualTo(d2));
        });
    }

    [TestCase(1, 2, 9, 2, 5, 10)]
    [TestCase(1, 2, 7, 2, 3, 6)]
    public void AddAndVerifyResult(int n1, int n2, int n3, int d1, int d2, int d3)
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        var f3 = f1 + f2;
        Assert.Multiple(() => {
            Assert.That(f3.Numerator, Is.EqualTo(n3));
            Assert.That(f3.Denominator, Is.EqualTo(d3));
        });
    }

    [TestCase(4, 33, -5, 1, 7, 7)]
    [TestCase(2, 45, -13, 3, 9, 3)]
    public void SubAndVerifyResult(int n1, int n2, int n3, int d1, int d2, int d3)
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        var f3 = f1 - f2;
        Assert.Multiple(() => {
            Assert.That(f3.Numerator, Is.EqualTo(n3));
            Assert.That(f3.Denominator, Is.EqualTo(d3));
        });
    }

    [TestCase(1, 11, 1, 11, 1, 1)]
    [TestCase(42, 0, 0, 1, 1, 1)]
    public void MultiplyAndVerifyResult(int n1, int n2, int n3, int d1, int d2, int d3)
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        var f3 = f1 * f2;
        Assert.Multiple(() => {
            Assert.That(f3.Numerator, Is.EqualTo(n3));
            Assert.That(f3.Denominator, Is.EqualTo(d3));
        });
    }

    [TestCase(33, 111, 44, 42, 8, 777)]
    [TestCase(23, 45, 23, 12, 9, 60)]
    public void DivideAndVerifyResult(int n1, int n2, int n3, int d1, int d2, int d3)
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        var f3 = f1 / f2;
        Assert.Multiple(() => {
            Assert.That(f3.Numerator, Is.EqualTo(n3));
            Assert.That(f3.Denominator, Is.EqualTo(d3));
        });
    }

    [Test]
    public void DivideByZeroThrowsException()
    {
        var f1 = new Fraction(42, 1);
        var f2 = new Fraction(0, 1);
        Assert.That(()=> f1 / f2, Throws.TypeOf<ArgumentException>());
    }

    [TestCase(0, 0, 1, 22)]
    [TestCase(1, 2, 2, 4)]
    public void TestIfEqualsOperator(int n1, int n2, int d1, int d2)
    {
        var f1 = new Fraction(n1, d2);
        var f2 = new Fraction(n1, d2);
        Assert.That(() => f1 == f2, Is.EqualTo(true));
    }

    [TestCase(1, 3, 4, 9)]
    [TestCase(2, 4, 2, 2)]
    [TestCase(2, 3, 4, 7)]
    public void TestIfNotEqualsOperator(int n1, int n2, int d1, int d2)
    {
        var f1 = new Fraction(n1, d1);
        var f2 = new Fraction(n2, d2);
        Assert.That(() => f1 != f2, Is.EqualTo(true));
    }

    [TestCase(0, 0, 1, 22)]
    [TestCase(1, 2, 2, 4)]
    public void TestIfEqualsFunction(int n1, int n2, int d1, int d2)
    {
        var f1 = new Fraction(n1, d2);
        var f2 = new Fraction(n1, d2);
        Assert.That(f1, Is.EqualTo(f2));
    }

    [TestCase(1, 2, "1/2")]
    [TestCase(11, 5, "11/5")]
    [TestCase(22, 11, "2")]
    [TestCase(22, -11, "-2")]
    [TestCase(0, 1, "0")]
    [TestCase(-43, -53, "-43/53")]
    public void ConvertToStringIsSuccessful(int n1, int d2, string s)
    {
        var f1 = new Fraction(n1, d2);
        var f1String = s;
        var f1ToString = f1.ToString();
        Assert.That(() => f1ToString, Is.EqualTo(f1String));
    }

    [TestCase(4)]
    [TestCase(0)]
    [TestCase(-12)]
    public void ExplicitConversionToInt(int n)
    {
        var f1 = (int) new Fraction(n, 1);
        Assert.That(f1, Is.EqualTo(n));
    }

    [Test]
    public void ExplicitConversionToIntThrowsExceptionIfDenominatorIsNotOne()
    {
        var f1 = new Fraction(4, 11);
        Assert.That(() => (int)f1, Throws.TypeOf<ArgumentException>());
    }


    [TestCase(42)]
    [TestCase(0)]
    [TestCase(-11)]
    public void ImplicitConversionToFract(int n)
    {
        Fraction f1 = n;
        Assert.That(f1, Is.EqualTo(new Fraction(n, 1)));
    }

    [TestCase(3,2)]
    [TestCase(0,1)]
    [TestCase(-11, -12)]
    public void VerifyIfGetHashIsOverloadedProperly(int n, int d)
    {
        var f1 = new Fraction(n, d);
        var h1 = f1.GetHashCode();
        var h2 = HashCode.Combine(f1.Numerator, f1.Denominator);
        Assert.That(h1, Is.EqualTo(h2));
    }
}
