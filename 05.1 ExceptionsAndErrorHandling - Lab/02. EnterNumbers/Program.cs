using System.Xml;

List<int> list = new();

while(list.Count!=10)
{
    try
    {
        int num = int.Parse(Console.ReadLine());

        if (num < 2 || num > 100)
        {
            if (list.Count == 0)
            {
                throw new ArgumentException($"Your number is not in range 1 - 100!");
            }
            else if (num < list.Max())
            {
                throw new ArgumentException($"Your number is not in range {list[list.Count - 1]} - 100!");
            }
        }
        else if(list.Count!=0&&num< list.Max())
        {
            throw new ArgumentException($"Your number is not in range {list[list.Count - 1]} - 100!");
        }
        list.Add(num);
    }
    catch(FormatException ex)
    {
        Console.WriteLine("Invalid Number!");
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
}
Console.WriteLine(string.Join(", ",list));