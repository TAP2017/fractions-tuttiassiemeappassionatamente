/*using FractionImplementation;

namespace TestLab1Tap {
    public class Tests {
        private Fraction ris = new Fraction();
        [SetUp]
        public void Setup() {
        }
*/
        /*
         * I TestCase hanno come attributi:
         * AD ALTERNARE N VOLTE:
         *                  il numeratore
         *                  il denomnatore
         * la stringa di ritorno del ToString
         *  (quando il test dovrebbe ritornare un errore la stringa di controllo sarà vuota)
         */
/*        [TestCase(10, 0, "")]
        [TestCase(2, 4, "1/2")]
        [TestCase(1,-1,"-1")]
        public void TestCostructor(int x, int y, String str) {
            try {
                Fraction receiver = new Fraction(x, y);
                Assert.That(receiver.ToString(), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[COSTRx01]{e}"); // Per far passare il test quando ritorna un errore, bisogna inserire nella condizione la stringa esatta del throw che ritorna quell'errore
                else Assert.Fail($"[ERROR-COSTR]{e}");
            }
        }

*/
        /* I commenti delle righe 10-17 e della riga 26 valgono per tutti i Test */

/*
        [TestCase(1,2,2,5,"9/10")]
        public void TestAdd(int x1, int y1, int x2, int y2, String str) {
            try {
                Fraction a = new Fraction(x1, y1);
                Fraction b = new Fraction(x2, y2);
                Assert.That(ris.Add(a, b), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Invalid first argument") Assert.Pass($"[ADDx01]{e}");
                if (e.Message == "Invalid second argument") Assert.Pass($"[ADDx02]{e}");
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[ADDx03]{e}");
                else Assert.Fail($"[ERROR-ADD]{e}");
            }
        }

        [TestCase(4, 1, 33, 7, "-5/7")]
        public void TestDiff(int x1, int y1, int x2, int y2, String str) {
            try {
                Fraction a = new Fraction(x1, y1);
                Fraction b = new Fraction(x2, y2);
                Assert.That(ris.Subtraction(a, b), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Invalid first argument") Assert.Pass($"[DIFx01]{e}");
                if (e.Message == "Invalid second argument") Assert.Pass($"[DIFx02]{e}");
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[DIFx03]{e}");
                else Assert.Fail($"[ERROR-DIF]{e}");
            }
        }

        [TestCase(42, 1, 0, 1, "0")]
        [TestCase(1, 11, 11, 1, "1")]
        public void TestMolt(int x1, int y1, int x2, int y2, String str) {
            try {
                Fraction a = new Fraction(x1, y1);
                Fraction b = new Fraction(x2, y2);
                Assert.That(ris.Multiplication(a, b), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Invalid first argument") Assert.Pass($"[MOLx01]{e}");
                if (e.Message == "Invalid second argument") Assert.Pass($"[MOLx02]{e}");
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[MOLx03]{e}");
                else Assert.Fail($"[ERROR-MOL]{e}");
            }
        }

        [TestCase(33, 42, 111, 8, "44/777")]
        [TestCase(42, 1, 0, 1, "")]
        public void TestDiv(int x1, int y1, int x2, int y2, String str) {
            try {
                Fraction a = new Fraction(x1, y1);
                Fraction b = new Fraction(x2, y2);
                Assert.That(ris.Divisor(a, b), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Invalid first argument") Assert.Pass($"[DIVx01]{e}");
                if (e.Message == "Invalid second argument") Assert.Pass($"[DIVx02]{e}");
                if (e.Message == "Invalid numerator of second argument") Assert.Pass($"[DIVx03]{e}");
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[DIVx04]{e}");
                else Assert.Fail($"[ERROR-DIV]\n{e}");
            }
        }

        [TestCase(0, 1, 0, 22)]
        [TestCase(1, 2, 2, 4)]
        public void TestEquals(int x1, int y1, int x2, int y2) {
            try {
                Fraction a = new Fraction(x1, y1);
                Fraction b = new Fraction(x2, y2);
                Assert.That(a.Equals(b), Is.EqualTo(true));
            } catch (Exception e) {
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[EQUALx01]{e}");
                if (e.Message == "Invalid Equals argument") Assert.Pass($"[EQUALx02]{e}");
                else Assert.Fail($"[ERROR-EQUALS]\n{e}");
            }
        }

        [TestCase(11, 5, "11/5")]
        [TestCase(22, 11, "2")]
        [TestCase(22, -11, "-2")]
        public void TestString(int x1, int y1, String str) {
            try {
                Fraction a = new Fraction(x1, y1);
                Assert.That(a.ToString(), Is.EqualTo(str));
            } catch (Exception e) {
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[STRINGx01]{e}");
                else Assert.Fail($"[ERROR-STRING]\n{e}");
            }
        }
*/
        /*
         * Solo in questo TestCase gli attributi sono:
         * -il numeratore
         * -la stringa di verifica
         */
/*
[TestCase(42, "42/1")]
        [TestCase(0, "0/1")]
        public void TestImplicit(int x, String str) {
            try {
                Assert.That(ris.ImplicitConv(x), Is.EqualTo(str));
            } catch (Exception e) {
                Assert.Fail($"[ERROR-IMPLICIT]\n{e}");
            }
        }

        [TestCase(42, 1, "42")]
        [TestCase(42, 11, "")]
        public void TestEsplicit(int x, int y, String str) {
            try {
                Fraction f = new Fraction(x, y);
                Assert.That(ris.EsplicitConv(f), Is.EqualTo(str));
            } catch (Exception e) { 
                if (e.Message == "Denominator mustn't be zero") Assert.Pass($"[ESPLICITx01]{e}");
                if (e.Message == "The denominator mustn't be 1") Assert.Pass($"[ESPLICITx02]{e}");
                else Assert.Fail($"[ERROR-ESPLICIT]\n{e}");
            }
        }
    }
}*/