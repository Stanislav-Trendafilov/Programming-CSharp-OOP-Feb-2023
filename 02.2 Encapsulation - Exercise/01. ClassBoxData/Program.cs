namespace ClassBoxData
{
    public class StartUp
    {
        static void Main()
        {

            double length = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            Box box = new Box(length, height, width);
            if (length <0||height<0||width<0)
            {
                return;
            }
            double surfaceArea = box.SurfaceArea();
            double lateralSurfaceArea = box.LateralSurfaceArea();
            double volume = box.Volume();
            Console.WriteLine($"Surface Area - {surfaceArea:f2}");
            Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:f2}");
            Console.WriteLine($"Volume - {volume:f2}");
        }
    }
}