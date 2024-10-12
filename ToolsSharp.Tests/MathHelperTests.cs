using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSharp.Tests
{
    [TestClass]
    public class MathHelperTests
    {
        #region EuclideanDistance

        [TestMethod]
        [DataRow(1, 2, 1)]
        [DataRow(1, 10, 9)]
        [DataRow(1, -5, 6)]
        public void EuclideanDistance1D_Is_Correct(double v1, double v2, double expected)
        {
            Assert.AreEqual(expected, MathHelper.EuclideanDistance1D(v1, v2));
        }

        [TestMethod]
        [DataRow(0, 0, 10, 10, 14)]
        [DataRow(-50, 10, 532, 10, 582)]
        public void EuclideanDistance2D_Is_Correct(double x1, double y1, double x2, double y2, double expected)
        {
            Assert.AreEqual(expected, Math.Floor(MathHelper.EuclideanDistance2D(x1, y1, x2, y2)));
        }

        [TestMethod]
        [DataRow(0, 0, 10, 10, 14)]
        [DataRow(-50, 10, 532, 10, 582)]
        public void EuclideanDistance2D_Points_Is_Correct(int x1, int y1, int x2, int y2, double expected)
        {
            Assert.AreEqual(expected, Math.Floor(MathHelper.EuclideanDistance2D(new Point(x1, y1), new Point(x2, y2))));
        }

        [TestMethod]
        [DataRow(0, 0, 0, 10, 10, 10, 17)]
        [DataRow(-50, 10, 61, 532, 10, -52, 592)]
        public void EuclideanDistance3D_Is_Correct(double x1, double y1, double z1, double x2, double y2, double z2, double expected)
        {
            Assert.AreEqual(expected, Math.Floor(MathHelper.EuclideanDistance3D(x1, y1, z1, x2, y2, z2)));
        }

        #endregion EuclideanDistance
    }
}