using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrestling_Manager
{
    class Coaches : Member
    {
        private string coachType;

        public Coaches() : base()
        {
            coachType = "";
        }

        public Coaches(string firstName, string lastName, string gender, string school, int yearsExperience, string coachType) : base(firstName, lastName, gender, school, yearsExperience)
        {
            this.coachType = coachType;
        }

        public string GetCoachType()
        {
            return coachType;
        }

        public void SetCoachType(string coachType)
        {
            this.coachType = coachType;
        }
    }
}

