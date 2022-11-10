using Frazioni_IvanoDivano;

namespace TestFrazioni_IvanoDivano;
//(づ｡◕‿‿◕｡)づ
public class FractionTest_IvanoDivano
{
    [Test]
    public void TestFractionConstructorWithDenominatorZero([Random(-100, 100, 5)] int n)
    {
        Assert.That(() => new Fraction(n, 0), Throws.ArgumentException);
    }

    [Test]
    public void TestFractionSimplyfyFunction([Random(-100, 100, 5)] int x)
    {
        var f = new Fraction(2*x, 7*x);

        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(2));
            Assert.That(f.Denominator, Is.EqualTo(7));
        });
    }


    [Test]
    public void TestFractionConstructorWithNegativeDenominator([Random(-100, 100, 5)] int n)
    {
        var actual = new Fraction(n, -1);
        Assert.Multiple(() =>
        {
            Assert.That(actual.Numerator, Is.EqualTo(-n));
            Assert.That(actual.Denominator, Is.EqualTo(1));
        });
    }
    
    

    [Test]
    public void TestFractionSum()
    {
        var operand1 = new Fraction(1, 2);
        var operand2 = new Fraction(2, 5);

        var result = operand1 + operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(9));
            Assert.That(result.Denominator, Is.EqualTo(10));
        });
    }

    [Test]
    public void TestFractionSubtraction()
    {

        var operand1 = new Fraction(4, 1);
        var operand2 = new Fraction(33, 7);

        var result = operand1 - operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(-5));
            Assert.That(result.Denominator, Is.EqualTo(7));
        });
    }

    [Test]
    public void TestFractionMultiplication()
    {
        var operand1 = new Fraction(1, 11);
        var operand2 = new Fraction(11, 1);

        var result = operand1 * operand2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(1));
            Assert.That(result.Denominator, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestFractionDivision()
    {
        var f1 = new Fraction(33, 42);
        var f2 = new Fraction(111, 8);

        var result = f1 / f2;

        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(44));
            Assert.That(result.Denominator, Is.EqualTo(777));
        });
    }

    [Test]
    public void TestFractionMultiplicationWithZero([Random(-100, 100, 3)] int n, [Random(-100, 100, 1)] int d)
    {
        var operand1 = new Fraction(n, d);

        var result = operand1 * 0;
        Assert.Multiple(() =>
        {
            Assert.That(result.Numerator, Is.EqualTo(0));
            Assert.That(result.Denominator, Is.EqualTo(1));
        });
    }

    [Test]
    public void TestFractionDivisionWithZero()
    {
        var operand = new Fraction(42, 1);

        Assert.That(() => operand / 0, Throws.ArgumentException);
    }

    [Test]
    public void TestFractionMethodEqualsWithNoSimplification()
    {
        var f1 = new Fraction(0, 1);
        var f2 = new Fraction(0, 22);

        Assert.That(f1 == f2, Is.EqualTo(true));
    }

    [Test]
    public void TestFractionMethodEqualsWithSimplification([Random(-100, 100, 3)]int x)
    {
        var f1 = new Fraction(1, 2);
        var f2 = new Fraction(1*x, 2*x);

        Assert.That(f1 == f2, Is.EqualTo(true));
    }

    [Test]
    public void TestFractionMethodEqualsWhenFractionsArentEquals()
    {
        var f1 = new Fraction(4, 3);
        var f2 = new Fraction(7, 3);

        Assert.That(f1 != f2, Is.EqualTo(true));
    }
    [Test]
    public void TestFractionToStringWithDenominator()
    {
        var f = new Fraction(2, 4);

        Assert.That(f.ToString(), Is.EqualTo("1/2"));
    }
    [Test]
    public void TestFractionToStringWithDenominator1([Values(-2, 2)] int n, [Random(1, 100, 5)] int x)
    {
        var f = new Fraction(n*x, 1*x);

        Assert.That(f.ToString(), Is.EqualTo(n.ToString()));
    }
    [Test]
    public void TestFractionToStringWithDenominatorNegative1([Values(-2, 2)] int n, [Random(-100, -1, 5)] int x)
    {
        var f = new Fraction(n*x, 1*x);

        Assert.That(f.ToString(), Is.EqualTo(n.ToString()));
    }
    [Test]
    public void TestIntToFraction([Random(-100, 100, 3)] int n)
    {
        var f = new Fraction(n);

        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(n));
            Assert.That(f.Denominator, Is.EqualTo(1));
        });
    }
    [Test]
    public void TestZeroToFraction()
    {
        var f = new Fraction(0);
        
        Assert.Multiple(() =>
        {
            Assert.That(f.Numerator, Is.EqualTo(0));
            Assert.That(f.Denominator, Is.EqualTo(1));
        });
    }
    [Test]
    public void TestFractionToInt([Random(-100, 100, 5)] int n)
    {
        var f = new Fraction(n, 1);

        Assert.That(f.ToInt(), Is.EqualTo(n));
    }
    [Test]
    public void TestFractionToIntException()
    {
        var f = new Fraction(42, 11);

        Assert.That( () => f.ToInt(), Throws.ArgumentException);
    }

}