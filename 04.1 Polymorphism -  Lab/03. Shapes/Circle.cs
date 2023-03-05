using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Radius = radius;
        }

        public double Radius { get; set; }

        public override double CalculateArea()
            =>Math.PI * Math.Pow(Radius,2);

        public override double CalculatePerimeter()
            => 2 * Radius * Math.PI;

        public override string Draw()
            => "Drawing Circle";
    }
}
