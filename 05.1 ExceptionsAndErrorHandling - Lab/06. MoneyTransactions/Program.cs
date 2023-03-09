

using System.Globalization;
using System.Security.Principal;

string[] accountsInfo = Console.ReadLine()
   .Split(",", StringSplitOptions.RemoveEmptyEntries);

Dictionary<int,double> accounts = new Dictionary<int,double>();

foreach (var account in accountsInfo)
{
    string[] accountInfo = account
        .Split("-", StringSplitOptions.RemoveEmptyEntries);

    int number = int.Parse(accountInfo[0]);
    double balance= double.Parse(accountInfo[1]);

    accounts[number] = balance;
}

string command=string.Empty;

while((command = Console.ReadLine()) !="End")
{
   
    try
    {
        string[] cmdArg = command
       .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        string cmd = cmdArg[0];
        int currentNum = int.Parse(cmdArg[1]);
        double currentBalance = double.Parse(cmdArg[2]);

        if(cmd== "Deposit")
        {
            if(!accounts.ContainsKey(currentNum))
            {
                throw new ArgumentException("Invalid account!");
            }
            else
            {
                accounts[currentNum] +=currentBalance;
                Console.WriteLine($"Account {currentNum} has new balance: {accounts[currentNum]:f2}");
            }
        }
        else if(cmd== "Withdraw")
        {
            if(!accounts.ContainsKey(currentNum))
            {
                throw new ArgumentException("Invalid account!");
            }
            else if (accounts[currentNum]<currentBalance)
            {
                throw new ArgumentException("Insufficient balance!");
            }
            else
            {
                accounts[currentNum] -=currentBalance;
                Console.WriteLine($"Account {currentNum} has new balance: {accounts[currentNum]:f2}");
            }
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");

    }

}