
string[] cards = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

List<Card> list = new List<Card>();

foreach (var card in cards)
{
    string[] cardInfo = card.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    try
    {
        Card currentcard = new(cardInfo[0], cardInfo[1]);

        list.Add(currentcard);
    }
    catch(ArgumentException ex) 
    { 
        Console.WriteLine(ex.Message);
    }
}
Console.WriteLine(string.Join(" ",list));
public class Card
{
    private string face;
    private string suit;
    private List<string> validFaces = new List<string>() { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
    private List<string> validSuits = new List<string>() { "S", "H", "D", "C" };

    public Card(string face, string suit)
    {
        this.Face = face;
        this.Suit = suit;
    }

    public string Suit
    {
        get { return suit; }
        set
        {
            if (!validSuits.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            suit = value;
        }
    }

    public string Face
    {
        get { return face; }
        set
        {
            if (!validFaces.Contains(value))
            {
                throw new ArgumentException("Invalid card!");
            }
            face = value;
        }
    }
    public override string ToString()
    {
        string lajna="\u2660";
        switch (suit)
        {
            case "S":
                return $"[{face}\u2660]";
            case "H":
                return $"[{face}\u2665]";
            case "D":
                return $"[{face}\u2666]";
            case "C":
                return $"[{face}\u2663]";
            default:
                return null;

        }
    }

}