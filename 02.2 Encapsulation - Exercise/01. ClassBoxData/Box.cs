using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBoxData
{
    public class Box
    {

        private double length;
        private double height;
        private double width;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Height = height;
            this.Width = width;
        }

        public double Width
        {
            get { return width; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"Width cannot be zero or negative.");
                }
                width = value;
            }
        }
        public double Height
        {
            get { return height; }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine($"Height cannot be zero or negative.");
                }
                height = value;
            }
        }
        public double Length
        {
            get { return length; }
            private set
            {
                if (value < 0)
                {
                    Console.WriteLine($"Length cannot be zero or negative.");
                }
                length = value;
            }
        }

        public double SurfaceArea()
        {
            double surfaceArea = 2 * (height * width + height * length + length * width);
            return surfaceArea;
        }
        public double LateralSurfaceArea()
        {
            return 2 * height * (width + length);
        }
        public double Volume()
        {
            return width * length * height;
        }

    }
}
