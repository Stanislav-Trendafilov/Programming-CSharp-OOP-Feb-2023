namespace BirthdayCelebrations;

public class StartUp
{
    static void Main(string[] args)
    {
        string command=string.Empty;

        IBirthable ibirthable;
        List<IBirthable> list=new List<IBirthable>();

        while((command=Console.ReadLine()) != "End") 
        {
            string[] cmdArg = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            if (cmdArg[0]=="Pet")
            {
                ibirthable = new Pet(cmdArg[1], cmdArg[2]);
                list.Add(ibirthable);
            }
            else if (cmdArg[0]=="Citizen")
            {
                ibirthable = new Person(cmdArg[1], int.Parse(cmdArg[2]), cmdArg[3], cmdArg[4]);
                list.Add(ibirthable);
            }
        }

        string lastNums=Console.ReadLine();

        foreach (var ibirth in list)
        {
            if(ibirth.Birthdate.EndsWith(lastNums))
            {
                Console.WriteLine(ibirth.Birthdate);
            }
        }
    }
}