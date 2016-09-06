namespace VariablesHomework
{
    using System;

    /// <summary>
    /// Task 1. Class Size in C#.
    /// Refactor the following code to use proper variable naming and simplified expressions.
    /// </summary>
    public class Size
    {
        /// <summary>
        /// The width and height of the object.
        /// </summary>
        private double width, height;

        /// <summary>
        /// Initializes a new instance of the <see cref="Size"/> class.
        /// </summary>
        /// <param name="width">Width of the size.</param>
        /// <param name="height">Height of the size.</param>
        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Gets the width of the size.
        /// </summary>
        public double Width
        {
            get
            {
                return this.width;
            }
        }

        /// <summary>
        /// Gets the height of the size.
        /// </summary>
        public double Height
        {
            get
            {
                return this.height;
            }
        }

        /// <summary>
        /// Gets new size object with rotated parameters Width and Height by a given angle.
        /// </summary>
        /// <param name="size">The size object which will be rotated.</param>
        /// <param name="angleOfRotation">Angle of rotation in radians.</param>
        /// <returns>A new rotated size object.</returns>
        public static Size GetRotatedSize(Size size, double angleOfRotation)
        {
            double sineOfAngle = Math.Sin(angleOfRotation);
            double cosineOnAngle = Math.Cos(angleOfRotation);

            double newWidth = (Math.Abs(cosineOnAngle) * size.Width) +
                (Math.Abs(sineOfAngle) * size.Height);
            double newHeight = (Math.Abs(sineOfAngle) * size.width) +
                (Math.Abs(cosineOnAngle) * size.height);

            return new Size(newWidth, newHeight);
        }
    }
}
