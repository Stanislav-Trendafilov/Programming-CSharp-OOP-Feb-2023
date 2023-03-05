namespace BorderControl;

public class StartUp
{
    static void Main(string[] args)
    {
        string command = string.Empty;
        IIdentifable identifable;
        List<IIdentifable> list = new List<IIdentifable>();
        while ((command = Console.ReadLine()) != "End")
        {
            string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            if (cmdArg.Length == 3)
            {
                identifable = new Person(cmdArg[0], int.Parse(cmdArg[1]), cmdArg[2]);
                list.Add(identifable);
            }
            else
            {
                identifable = new Robot(cmdArg[0], cmdArg[1]);
                list.Add(identifable);
            }
        }
        string lastNums = Console.ReadLine();
        foreach (var identifiable in list)
        {
            if (identifiable.Id.EndsWith(lastNums))
            {
                Console.WriteLine(identifiable.Id);
            }
        }
    }
}