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
		private decimal salary;



		public Person(string firstName, string lastName, int age,decimal salary)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
			this.Salary= salary;
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
        public decimal Salary
        {
            get { return salary; }
            private set { salary = value; }
        }
        public override string ToString()
        {
			return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
		public void IncreaseSalary(decimal percentage)
		{
			decimal increase = salary * percentage / 100;
		    if(age<30)
			{
				increase /= 2;
			}
			Salary += increase;
		}

    }
}
