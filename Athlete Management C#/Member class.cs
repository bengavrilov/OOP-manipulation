using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrestling_Manager
{
    class Member
    {
        //Universal Attributes
        protected string lastName;
        protected string firstName;
        protected string gender;
        protected string school;
        protected int yearsExperience;

        //Default Constructor
        public Member()
        {
            lastName = "";
            firstName = "";
            gender = "";
            school = "";
            yearsExperience = 0;
        }

        //Overloaded Constructor
        public Member(string lastName, string firstName, string gender, string school, int yearsExperience)
        {
            this.lastName = lastName;
            this.firstName = firstName;
            this.gender = gender;
            this.school = school;
            this.yearsExperience = yearsExperience;
        }

        //Obtaining Statistics
        public string GetFirstName()
        {
            return firstName;
        }

        public string GetLastName()
        {
            return lastName;
        }

        public string GetGender()
        {
            return gender;
        }

        public string GetSchool()
        {
            return school;
        }

        public int GetYearsExperience()
        {
            return yearsExperience;
        }

        //Setting Statistics
        public void SetFirstName(string firstName)
        {
            this.firstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public void SetGender(string gender)
        {
            this.gender = gender;
        }

        public void SetSchool(string school)
        {
            this.school = school;
        }

        public void SetYearsExperience(int yearsExperience)
        {
            this.yearsExperience = yearsExperience;
        }

    }
}
