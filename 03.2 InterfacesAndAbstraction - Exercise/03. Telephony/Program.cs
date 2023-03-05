namespace Telephony
{
    public class StartUp
    {
        static void Main()
        {
            string[] phones = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();

            foreach (var phoneNum in phones)
            {
                if (phoneNum.Length == 10)
                {
                    Console.WriteLine(smartphone.Call(phoneNum));
                }
                else if(phoneNum.Length == 7) 
                {
                    Console.WriteLine(stationaryPhone.Call(phoneNum)); 
                }

            }
            foreach (var url in urls)
            {
                Console.WriteLine(smartphone.Browse(url));
            }
        }
    }
}