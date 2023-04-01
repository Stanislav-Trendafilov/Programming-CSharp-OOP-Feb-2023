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
    public class SubjectRepository : IRepository<ISubject>      
    {
        private List<ISubject> _subjects=new List<ISubject>();

        public IReadOnlyCollection<ISubject> Models => _subjects.AsReadOnly();

        public void AddModel(ISubject model)
        {
            ISubject subject = null;
            if(model is TechnicalSubject)
            {
                subject = new TechnicalSubject(Models.Count + 1, model.Name);
            }
            else if (model is EconomicalSubject)
            {
                subject = new EconomicalSubject(Models.Count + 1, model.Name);
            }
            else if (model is HumanitySubject)
            {
                subject = new HumanitySubject(Models.Count + 1, model.Name);
            }
            _subjects.Add(subject);
        }

        public ISubject FindById(int id)
        {
            return _subjects.FirstOrDefault(x => x.Id == id);
        }

        public ISubject FindByName(string name)
        {
            return _subjects.FirstOrDefault(x => x.Name == name);
        }
    }
}
