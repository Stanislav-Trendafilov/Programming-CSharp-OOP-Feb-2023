using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {

        private int id;
        private string firstName;
        private string lastName;
        public Student(int studentId, string firstName, string lastName)
        {
            Id= studentId;
            FirstName = firstName;
            LastName= lastName;
            coveredExam=new List<int>();

        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }
        public string FirstName
        {
            get
            {
                return firstName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }

                lastName = value;
            }
        }

        private List<int> coveredExam;

        public IReadOnlyCollection<int> CoveredExams => coveredExam.AsReadOnly();

        public IUniversity University { get; private set; }
            

        public void CoverExam(ISubject subject)
        {
            coveredExam.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            University=university;
        }
    }
}
