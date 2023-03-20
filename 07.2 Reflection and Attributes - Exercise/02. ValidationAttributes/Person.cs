using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes.Attributes;

namespace ValidationAttributes
{
    public class Person
    {
        private string fullName;
        private int age;

        public Person(string fullName, int age)
        {
            this.fullName = fullName;
            this.age = age;
        }

        [MyRange(12,90)]
        public int Age
        {
            get { return age; }
            private set { age = value; }
        }

        [MyRequired]
        public string FullName
        {
            get { return fullName; }
            private set { fullName = value; }
        }


    }
}
