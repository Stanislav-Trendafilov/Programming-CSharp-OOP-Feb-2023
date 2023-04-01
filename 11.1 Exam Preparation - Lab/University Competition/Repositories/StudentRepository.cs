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
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students = new List<IStudent>();

        public IReadOnlyCollection<IStudent> Models => students.AsReadOnly();

        private int IdCounter = 0;
        public void AddModel(IStudent model)
        {
            Student student = new Student(Models.Count + 1, model.FirstName, model.LastName);
            students.Add(student);
        }

        public IStudent FindById(int id)
        {
            return students.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] fullName = name.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            string firstName = fullName[0];
            string lastName = fullName[1];

            return students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);

        }
    }
}
