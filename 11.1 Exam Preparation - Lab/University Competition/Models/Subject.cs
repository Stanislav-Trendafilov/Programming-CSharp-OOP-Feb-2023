using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public abstract class Subject : ISubject
    {
        private int id;
        private double rate;
        private string name;

        protected Subject(int subjectId, string subjectName, double subjectRate)
        {
            Id = subjectId;
            Name = subjectName;
            Rate = subjectRate;

        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                name = value;
            }
        }

        public double Rate
        {
            get { return rate; }
            private set { rate = value; }
        }

    }
}
