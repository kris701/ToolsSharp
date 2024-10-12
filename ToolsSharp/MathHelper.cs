using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolsSharp
{
    /// <summary>
    /// A helper class with various different mathematical helper methods
    /// </summary>
    public static class MathHelper
    {
        #region EuclideanDistance

        /// <summary>
        /// Get the Euclidean distance between two points in 1D space
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Euclidean_distance"/></remarks>
        /// <returns>The Euclidean distance between two values</returns>
        public static double EuclideanDistance1D(double v1, double v2)
        {
            return Math.Sqrt(Math.Pow(v2 - v1, 2));
        }

        /// <summary>
        /// Get the Euclidean distance between two <seealso cref="Point"/>s in 2D space.
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Euclidean_distance"/></remarks>
        /// <returns>The Euclidean distance between <paramref name="a"/> and <paramref name="b"/></returns>
        public static double EuclideanDistance2D(Point a, Point b) => EuclideanDistance2D(a.X, a.Y, b.X, b.Y);

        /// <summary>
        /// Get the Euclidean distance between two points in 2D space
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Euclidean_distance"/></remarks>
        /// <returns>The Euclidean distance between two points</returns>
        public static double EuclideanDistance2D(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        /// <summary>
        /// Get the Euclidean distance between two points in 3D space
        /// </summary>
        /// <remarks><see href="https://en.wikipedia.org/wiki/Euclidean_distance"/></remarks>
        /// <returns>The Euclidean distance between two points</returns>
        public static double EuclideanDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
        }

        #endregion EuclideanDistance
    }
}