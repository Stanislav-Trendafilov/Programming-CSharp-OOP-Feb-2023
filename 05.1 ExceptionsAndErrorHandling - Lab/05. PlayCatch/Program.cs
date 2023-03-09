
List<int> list = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int exceptionCount = 0;

while(exceptionCount!=3)
{
    string[] cmdArg = Console.ReadLine().Split(" ");
    string command= cmdArg[0];
 
    if (command == "Replace")
    {
        try
        {
            int index = int.Parse(cmdArg[1]);
            list[index] = int.Parse(cmdArg[2]);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionCount++;
            Console.WriteLine("The index does not exist!");
        }
        catch (FormatException)
        {
            exceptionCount++;
            Console.WriteLine("The variable is not in the correct format!");
        }
    }
    else if(command=="Print")
    {
        try
        {
            int index = int.Parse(cmdArg[1]);
            if(index<0|| int.Parse(cmdArg[2]) >= list.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
            List<int> subList = list.GetRange(index, int.Parse(cmdArg[2])-index+1);
            Console.WriteLine(string.Join(", ",subList));
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionCount++;
            Console.WriteLine("The index does not exist!");
        }
        catch (FormatException)
        {
            exceptionCount++;
            Console.WriteLine("The variable is not in the correct format!");
        }
    }
    else
    {
        try
        {
            int index = int.Parse(cmdArg[1]);
            Console.WriteLine(list[index]);
        }
        catch (ArgumentOutOfRangeException)
        {
            exceptionCount++;
            Console.WriteLine("The index does not exist!");
        }
        catch(FormatException) 
        {
            exceptionCount++;
            Console.WriteLine("The variable is not in the correct format!");
        }

    }    
}
Console.WriteLine(string.Join(", ",list));