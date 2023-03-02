using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cars
{
    internal class Tesla : ICar, IElectricCar
    {
        public Tesla(string color, string model,int battery)
        {
            Battery = battery;
            Model = model;
            Color = color;
        }

        public int Battery { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }
        public override string ToString()
        {
            StringBuilder sb= new StringBuilder();
            sb.AppendLine(Start());
            sb.AppendLine(Stop());
            sb.AppendLine($"{Color} Tesla {Model} with {Battery} Batteries");
            return sb.ToString().Trim();
        }
    }
}
