using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class UniversityRepository : IRepository<IUniversity>
    {
        private List<IUniversity> universities=new List<IUniversity>();
        public IReadOnlyCollection<IUniversity> Models => universities.AsReadOnly();

        public void AddModel(IUniversity model)
        {
            University university = new University(Models.Count + 1, model.Name, model.Category, model.Capacity, model.RequiredSubjects.ToList());
           universities.Add(university);
        }

        public IUniversity FindById(int id)
        {
           return universities.FirstOrDefault(x => x.Id == id);
        }

        public IUniversity FindByName(string name)
        {
            return universities.FirstOrDefault(x => x.Name == name);
        }
    }
}
