using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing_Lab3;


namespace UnitTests_Triangle
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void B_Is_Negative()
        {
            Assert.AreEqual(new Triangle().IsTriangle(2,-4,5), false);
        }
        [TestMethod]
        public void A_Is_Negative()
        {
            Assert.AreEqual(new Triangle().IsTriangle(-2, 4, 5), false);
        }
        [TestMethod]
        public void C_Is_Negative()
        {
            Assert.AreEqual(new Triangle().IsTriangle(2, 4, -5), false);
        }
        [TestMethod]
        public void Sides_Are_Equal()
        {
            Assert.AreEqual(new Triangle().IsTriangle(4.25f, 4.25f, 4.25f), true);
        }
        [TestMethod]
        public void B_Is_Less_Them_Sum_Other_Sides()
        {
            Assert.AreEqual(new Triangle().IsTriangle(8, 3, 10),true);
        }
        [TestMethod]
        public void  A_Plus_B_Equal_C()
        {
            Assert.AreEqual(new Triangle().IsTriangle(2, 4, 6), false);
        }
        [TestMethod]
        public void A_Is_More_Then_Sum_Other_Sides()
        {
            Assert.AreEqual(new Triangle().IsTriangle(17.56f, 4.13f, 10), false);
        }
        [TestMethod]
        public void B_Is_More_Then_Sum_Other_Sides()
        {
            Assert.AreEqual(new Triangle().IsTriangle(3, 10, 2.7f), false);
        }
        [TestMethod]
        public void C_Is_More_Then_Sum_Other_Sides()
        {
            Assert.AreEqual(new Triangle().IsTriangle(3.5f, 10, 27), false);
        }
        [TestMethod]
        public void All_Sides_Are_Negative()
        {
            Assert.AreEqual(new Triangle().IsTriangle(-4, -6, -9), false);
        }
    }
}
