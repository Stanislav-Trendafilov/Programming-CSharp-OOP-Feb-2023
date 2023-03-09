string[] sequence = Console.ReadLine().Split();

int suma = 0;

foreach (var element in sequence)
{
    try
    {
        int num=int.Parse(element);
        suma += num;
    }
    catch(FormatException ex)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch(OverflowException ex) 
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {suma}");
    }
}

Console.WriteLine($"The total sum of all integers is: {suma}");