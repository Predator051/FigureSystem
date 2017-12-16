using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FigureSystem;

namespace UTFigureSystem
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestShape()
        {
            Shape shape = new Shape();

            Assert.IsNull(shape.GetVertex());
        }

        [TestMethod]
        public void TestCircle()
        {
            Circle shape = new Circle(5, new Vector(0,0));

            Assert.AreEqual(shape.Perimeter(), 5 * 2 * Math.PI);
            Assert.AreEqual(shape.Area(), 5 * 5 * Math.PI);

            shape.Scale(new Vector(0, 0), 0.5);
            Assert.AreEqual(shape.Perimeter(), 2.5 * 2 * Math.PI);
            Assert.AreEqual(shape.Area(), 2.5 * 2.5 * Math.PI);
        }

        [TestMethod]
        public void TestRectangle()
        {
            Rectangle shape = new Rectangle(10,10, new Vector(0,0), 0);

            Assert.AreEqual(shape.Perimeter(), 40);
            Assert.AreEqual(shape.Area(), 100);

            shape.Scale(new Vector(0, 0), 0.5);
            Assert.AreEqual(20, shape.Perimeter());
            Assert.AreEqual(25, shape.Area());
        }
    }
}
