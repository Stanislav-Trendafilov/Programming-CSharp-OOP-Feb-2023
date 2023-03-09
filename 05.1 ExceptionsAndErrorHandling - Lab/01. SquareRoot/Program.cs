// 
try
{
    int number = int.Parse(Console.ReadLine());
    if (number < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    Console.WriteLine(Math.Sqrt(number));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}