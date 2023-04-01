namespace UniversityCompetition
{
    using UniversityCompetition.Core;
    using UniversityCompetition.Core.Contracts;
    using UniversityCompetition.Models;
    using UniversityCompetition.Repositories;

    public class StartUp
    {
        static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
