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
    }
}
