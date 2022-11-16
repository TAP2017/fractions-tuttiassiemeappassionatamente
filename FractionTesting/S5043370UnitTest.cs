using System.ComponentModel.DataAnnotations;
using FractionImplementation;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace TestLabo1
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TearDown]
        public void TearDown()
        {
        }

        [Test]
        public void NormalFormConversionCheck()
        {
            var FractionToNormalize = new Fraction(5, 10);
            var FractionNormalized = new Fraction(1, 2);
            Assert.Multiple(() =>
            {
                Assert.That(FractionToNormalize.Denominator, Is.EqualTo(FractionNormalized.Denominator));
                Assert.That(FractionToNormalize.Numerator, Is.EqualTo(FractionNormalized.Numerator));
            });
        }

        [Test]
        public void NormalFormConversionCheckIfDenominatorEquals0()
        {
            Assert.That(() => new Fraction(7, 0), Throws.InstanceOf<ArgumentException>());
        }

        [Test]
        public void NormalFormConversionCheckIfDenominatorMinorThanZero()
        {
            var FractionToNormalize = new Fraction(5, -3);
            var FractionNormalized = new Fraction(-5, 3);
            Assert.Multiple(() =>
            {
                Assert.That(FractionToNormalize.Denominator, Is.EqualTo(FractionNormalized.Denominator));
                Assert.That(FractionToNormalize.Numerator, Is.EqualTo(FractionNormalized.Numerator));
            });
        }
        [Test]
        public void CheckSum()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(1, 9);
            var ReturnValue = RigthValue + LeftValue;
            var shouldBe = new Fraction(54, 81);
            Assert.Multiple(() =>
            {
                Assert.That(ReturnValue.Denominator, Is.EqualTo(shouldBe.Denominator));
                Assert.That(ReturnValue.Numerator, Is.EqualTo(shouldBe.Numerator));
            });
        }

        [Test]
        public void CheckDifference()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(1, 9);
            var ReturnValue = RigthValue - LeftValue;
            var shouldBe = new Fraction(4, 9);
            Assert.Multiple(() =>
            {
                Assert.That(ReturnValue.Denominator, Is.EqualTo(shouldBe.Denominator));
                Assert.That(ReturnValue.Numerator, Is.EqualTo(shouldBe.Numerator));
            });
        }

        [Test]
        public void CheckMultiplies()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(1, 9);
            var ReturnValue = RigthValue * LeftValue;
            var shouldBe = new Fraction(5, 81);

            Assert.Multiple(() =>
            {
                Assert.That(ReturnValue.Denominator, Is.EqualTo(shouldBe.Denominator));
                Assert.That(ReturnValue.Numerator, Is.EqualTo(shouldBe.Numerator));
            });
        }

        [Test]
        public void CheckDivision()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(1, 9);
            var ReturnValue = RigthValue / LeftValue;
            var shouldBe = new Fraction(5, 1);
            Assert.Multiple(() =>
            {
                Assert.That(ReturnValue.Denominator, Is.EqualTo(shouldBe.Denominator));
                Assert.That(ReturnValue.Numerator, Is.EqualTo(shouldBe.Numerator));
            });
        }
        [Test]
        public void CheckEqualsNegative()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(1, 9);
            var ReturnValue = RigthValue == LeftValue;
            var shouldBe = false;
            Assert.That(ReturnValue, Is.EqualTo(shouldBe));
        }
        [Test]
        public void CheckEqualsPositive()
        {
            var RigthValue = new Fraction(5, 9);
            var LeftValue = new Fraction(5, 9);
            var ReturnValue = RigthValue == LeftValue;
            var shouldBe = true;
            Assert.That(ReturnValue, Is.EqualTo(shouldBe));
        }

        [Test]
        public void CheckToString()
        {
            var fraction1 = new Fraction(5, 1);
            var fraction2 = new Fraction(10, 23);
            var stringfraction1 = "5";
            var stringfraction2 = "10/23";
            Assert.Multiple(() =>
            {
                Assert.That(fraction1.ToString(), Is.EqualTo(stringfraction1)); 
                Assert.That(fraction2.ToString(),Is.EqualTo(stringfraction2));
            });
        }

        [Test]
        public void checkEquals()
        {
            var fraction1 = new Fraction(4, 5);
            var fraction2 = new Fraction(4, 5);
            var fraction3 = new Fraction(8, 10);
            Assert.Multiple(() =>
            {
                Assert.That(fraction1.Equals(fraction2));
                Assert.That(fraction1.Equals(fraction3));
                Assert.That(fraction2.Equals(fraction1));
                Assert.That(fraction3.Equals(fraction1));
            });
        }

        [Test]
        public void checkImplicitConversionFromInt()
        {
            var fraction1 = new Fraction(10, 1);
            var fraction2 = new Fraction(20, 2);
            int toConvert = 10;
            Fraction newFractionFromInt = toConvert;
            Assert.Multiple(() =>
            {
                Assert.That(newFractionFromInt.Equals(fraction1));
                Assert.That(newFractionFromInt.Equals(fraction2));
                Assert.That(fraction2.Equals(newFractionFromInt));
                Assert.That(fraction1.Equals(newFractionFromInt));
            });

        }

        [Test]
        public void checkExplicitConversionToInt()
        {
            var fraction1 = new Fraction(10, 1);
            var fraction2 = new Fraction(13, 5);
            int convertedCorrectly = 10;
            int converted = (int)fraction1;
            Assert.Multiple(() =>
            {
                Assert.That(fraction1.Equals(convertedCorrectly));
                Assert.That(converted == convertedCorrectly );
                Assert.That(()=> (int)fraction2, Throws.InstanceOf<ArgumentException>());
            });
        }

        [Test]
        public void AdditiveTests()
        {

            var fraction1 = new Fraction(2, 4);
            var fraction1Normalized = new Fraction(1, 2);

            var fraction2 = new Fraction(1, -1);
            var fraction2Normalized = new Fraction(-1, 1);

            var sum1 = new Fraction(1, 2);
            var sum2 = new Fraction(2, 5);
            var summed = sum1 + sum2;
            var summedShouldBe = new Fraction(9, 10);


            Fraction diff1 = 4;
            Fraction diff2 = new Fraction(33, 7);
            var diffed = diff1 - diff2;
            var diffedShouldBe = new Fraction(-5, 7);

            var multip1 = new Fraction(1, 11);
            Fraction multip2 = 11;
            var multiplied = multip1 * multip2;
            Fraction multipliedShouldBe = 1;

            var division1 = new Fraction(33, 42);
            var division2 = new Fraction(111, 8);
            var division = division1 / division2;
            var divisionShouldBe = new Fraction(44, 777);

            var multi1 = new Fraction(42, 1);
            Fraction zero = 0;
            var zeroMultiplied = multi1 * zero;

            var fractionZero1 = new Fraction(0, 1);
            var fractionZero2 = new Fraction(0, 22);

            var fractionToStringToCheck = new Fraction(11, 5);
            var StringToCheck = "11/5";

            var fractionToStringToCheck2 = new Fraction(22, 11);
            var StringToCheck2 = "2";

            var fractionToStringToCheck3 = new Fraction(22, -11);
            var StringToCheck3 = "-2";

            var intToConvert = 42;
            Fraction fractionConverted = intToConvert;
            var fractionConvertedShouldBe = new Fraction(42, 1);

            var intToConvert2 = 0;
            Fraction fractionConverted2 = intToConvert2;
            Fraction fractionConvertedShouldBe2 = new Fraction(0, 1);

            var fractionToConvert = new Fraction(42, 1);
            var intConverted = (int)fractionToConvert;
            var intConvertedShouldBe = 42;

            var fractionToConvert2 = new Fraction(42, 11);




            Assert.Multiple( ()=> {
            
                Assert.That( ()=> new Fraction(19,0), Throws.InstanceOf<ArgumentException>());  //test per denominatore==0
            
                Assert.That(fraction1.Equals(fraction1Normalized)); //test per normalizzazione

                Assert.That(fraction2.Equals(fraction2Normalized)); //secondo test per la normalizzazione

                Assert.That(summed.Equals(summedShouldBe)); //test per la somma

                Assert.That(diffed.Equals(diffedShouldBe)); //test per la differenza (e per conversione implicita da int a Fraction)

                Assert.That(multiplied.Equals(multipliedShouldBe)); //test per la moltiplicazione (e per la conversione implicita da int a Fraction)

                Assert.That(division.Equals(divisionShouldBe)); //test per la divisione

                Assert.That(zeroMultiplied.Equals(zero));   //test per moltiplicazione per 0 => dia 0

                Assert.That(()=> multi1/zero, Throws.InstanceOf<ArgumentException>());  //test per vedere che una divisione per 0 sollevi un'eccezione

                Assert.That(fractionZero1 == fractionZero2);    //test x vedere che due frazioni con num == 0 e den != 0, siano uguali

                Assert.That(fraction1.Equals(fraction1Normalized)); //test x vedere che due frazioni con la stessa forma normale, siano effettivamente ==

                Assert.That(fractionToStringToCheck.ToString(),Is.EqualTo(StringToCheck));  //test x checkare che il metodo toString() funzioni correttamente
                Assert.That(fractionToStringToCheck2.ToString(), Is.EqualTo(StringToCheck2));
                Assert.That(fractionToStringToCheck3.ToString(), Is.EqualTo(StringToCheck3));

                Assert.That(fractionConverted.Equals(fractionConvertedShouldBe));   //test pr vedere che la conversione implicita funzioni correttamente
                Assert.That(fractionConverted2.Equals(fractionConvertedShouldBe2));

                Assert.That(intConverted == intConvertedShouldBe);  //test per controllare che la conversione esplicita funzioni correttamente
                Assert.That(()=> (int)fractionToConvert2,Throws.InstanceOf<ArgumentException>());




            });
        }
    }
}