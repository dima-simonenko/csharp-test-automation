using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Cryptography;

namespace Geometry
{
    [TestClass]
    public class GeometricTests
    {
        [TestMethod]
        public void TestMethodSquare()
        {
            Square s1 = new Square(5);
            Square s2 = new Square(10);
            Square s3 = s1;
           
            s1.Colored = true;

            //Проверка соответствия первоначальном размерам квадарта
            Assert.AreEqual(s1.Size, 5);
            Assert.AreEqual(s2.Size, 10);
            Assert.AreEqual(s3.Size, 5);

            Assert.AreEqual(s1.Colored, true);
            Assert.AreEqual(s2.Colored, false);
            Assert.AreEqual(s3.Colored, true);

            s3.Size = 15;
            s1.Colored = false;

            Assert.AreEqual(s1.Size, 15);
            Assert.AreEqual(s1.Colored, false);
            Assert.AreEqual(s2.Colored, false);
        }

        [TestMethod]
        public void TestMethodCircle()
        {
            Circle c1 = new Circle(5);
            Circle c2 = new Circle(10);
            Circle c3 = c1;

            Assert.AreEqual(c1.Radius, 5);
            Assert.AreEqual(c2.Radius, 10);
            Assert.AreEqual(c3.Radius, 5);

            c3.Radius = 15;
            c1.Colored = true;
            Assert.AreEqual(c1.Radius, 15);
            Assert.AreEqual(c1.Colored, true);
            Assert.AreEqual(c3.Colored, true);
            Assert.AreEqual(c2.Colored, false);
        }
    }
}
