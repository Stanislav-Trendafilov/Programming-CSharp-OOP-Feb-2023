using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
		private string firstName;
		private string lastName;
		private int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public int Age
		{
			get { return age; }
			private set { age = value; }
		}
		public string LastName
		{
			get { return lastName; }
			private set { lastName = value; }
		}
		public string FirstName
		{
			get { return firstName; }
			private set { firstName = value; }
		}
        public override string ToString()
        {
			return $"{this.FirstName} {this.LastName} is {this.Age} years old.";
        }

    }
}
