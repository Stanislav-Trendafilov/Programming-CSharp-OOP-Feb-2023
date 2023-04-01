using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;
        public Controller()
        {
            subjects = new SubjectRepository();
            students = new StudentRepository();
            universities = new UniversityRepository();
        }
        private string[] availableSubjectType = new string[] { "EconomicalSubject", "HumanitySubject", "TechnicalSubject" };
        public string AddStudent(string firstName, string lastName)
        {
            if (students.Models.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                return String.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            Student student = new Student(0, firstName, lastName);

            students.AddModel(student);

            return String.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, "StudentRepository");

        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjects.FindByName(subjectName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else if (!availableSubjectType.Contains(subjectType))
            {
                return String.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else
            {
                ISubject subject;
                if (subjectType == "EconomicalSubject")
                {
                    subject = new EconomicalSubject(0, subjectName);
                }
                else if (subjectType == "HumanitySubject")
                {
                    subject = new HumanitySubject(0, subjectName);
                }
                else
                {
                    subject = new TechnicalSubject(0, subjectName);
                }
                subjects.AddModel(subject);
                return String.Format(OutputMessages.SubjectAddedSuccessfully, subject.GetType().Name, subjectName, "SubjectRepository");

            }

        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (universities.FindByName(universityName) != null)
            {
                return String.Format(OutputMessages.AlreadyAddedUniversity, universityName);
            }
            List<int> requiredSubjAsInt = requiredSubjects.Select(x => subjects.FindByName(x).Id).ToList();

            University university = new University(0, universityName, category, capacity, requiredSubjAsInt);

            universities.AddModel(university);

            return String.Format(OutputMessages.UniversityAddedSuccessfully, universityName, "UniversityRepository");
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] studentFullName = studentName
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string firstName = studentFullName[0];
            string lastName = studentFullName[1];

            if (!students.Models.Any(x => x.FirstName == firstName && x.LastName == lastName))
            {
                return String.Format(OutputMessages.StudentNotRegitered, firstName, lastName);
            }
            if (universities.FindByName(universityName) == null)
            {
                return String.Format(OutputMessages.UniversityNotRegitered, universityName);
            }

            IStudent student = students.FindByName(studentName);
            IUniversity university = universities.FindByName(universityName);

            foreach (var requiredExam in university.RequiredSubjects)
            {
                if (!student.CoveredExams.Contains(requiredExam))
                {
                    return String.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
                }
            }

            if (students.FindByName(studentName).University == universities.FindByName(universityName))
            {
                return String.Format(OutputMessages.StudentAlreadyJoined, firstName, lastName, universityName);
            }

            students.FindByName(studentName).JoinUniversity(universities.FindByName(universityName));


            return String.Format(OutputMessages.StudentSuccessfullyJoined, firstName, lastName, universityName);
        }

        public string TakeExam(int studentId, int subjectId)
        {
            if (students.FindById(studentId) == null)
            {
                return OutputMessages.InvalidStudentId;
            }
            else if (subjects.FindById(subjectId) == null)
            {
                return OutputMessages.InvalidSubjectId;
            }
            if (students.FindById(studentId).CoveredExams.Any(x => x == subjectId))
            {
                Student st = (Student)students.FindById(studentId);

                return String.Format(OutputMessages.StudentAlreadyCoveredThatExam, st.FirstName, st.LastName, subjects.FindById(subjectId).Name);
            }
            Student student = (Student)students.FindById(studentId);
            Subject subject = (Subject)subjects.FindById(subjectId);

            students.FindById(studentId).CoverExam(subject);

            return String.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subjects.FindById(subjectId).Name);
        }

        public string UniversityReport(int universityId)
        {
            IUniversity university = universities.FindById(universityId);

            int counter = 0;
            foreach (var student in students.Models)
            {
                if (student.University == university)
                {
                    counter++;
                }
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {counter}");
            sb.AppendLine($"University vacancy: {university.Capacity-counter}");

            return sb.ToString().Trim();
        }
    }
}
