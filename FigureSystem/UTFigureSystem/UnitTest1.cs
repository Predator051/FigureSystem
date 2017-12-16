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

        [TestMethod]
        public void TestRightTriangle()
        {
            RightTriangle shape = new RightTriangle(10, 10, new Vector(0, 0), 0);

            Assert.AreEqual(20 + Math.Sqrt(200), shape.Perimeter());
            Assert.AreEqual(50, shape.Area());

            shape.Scale(new Vector(0, 0), 0.5);
            Assert.AreEqual(10 + Math.Sqrt(50), shape.Perimeter());
            Assert.AreEqual(25/2.0, shape.Area());
        }

        [TestMethod]
        public void TestSquare()
        {
            Square shape = new Square(10, new Vector(0, 0), 0);

            Assert.AreEqual(40, shape.Perimeter());
            Assert.AreEqual(100, shape.Area());

            shape.Scale(new Vector(0, 0), 0.5);
            Assert.AreEqual(20, shape.Perimeter());
            Assert.AreEqual(25, shape.Area());
        }

        [TestMethod]
        public void TestRegularPolygon()
        {
            RegularPolygon shape = new RegularPolygon(0, 5, new Vector(0, 0), 5);

            double side = 5/(Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 10.0);
            double sArea = (Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 4.0)*side*side;
            Assert.AreEqual(Math.Round(side*5, 2), Math.Round(shape.Perimeter(), 2));
            Assert.AreEqual(Math.Round(sArea, 2), Math.Round(shape.Area(), 2));

            shape.Scale(new Vector(0, 0), 0.5);

            side = 2.5 / (Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 10.0);
            sArea = (Math.Sqrt(25 + 10 * Math.Sqrt(5)) / 4.0) * side * side;
            Assert.AreEqual(Math.Round(side * 5, 2), Math.Round(shape.Perimeter(), 2));
            Assert.AreEqual(Math.Round(sArea, 2), Math.Round(shape.Area(), 2));
        }

    }
}
