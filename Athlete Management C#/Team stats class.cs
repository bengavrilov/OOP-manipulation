using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrestling_Manager
{
    class TeamStatistics
    {
        public List<Wrestlers> wrestlers = new List<Wrestlers>();
        public List<Coaches> coaches = new List<Coaches>();
        const int FULL_RATIO = 100;

        double[] weightCategories = new double[17] { 38, 41, 44, 47.5, 51, 54, 57.5, 61, 64, 67.5, 72, 77, 83, 89, 95, 115, 130 };

        public TeamStatistics(List<Wrestlers> wrestlers, List<Coaches> coaches)
        {
            this.wrestlers = wrestlers;
            this.coaches = coaches;

        }

        //Number of people on team
        public int NumOfPeopleOnTeam()
        {
            return (wrestlers.Count + coaches.Count);
        }

        //Number of wrestlers
        public int NumOfWrestlers()
        {
            return wrestlers.Count;
        }

        //Number of male wrestlers
        public int NumOfMaleWrestlers()
        {
            return wrestlers.Count(wrestler => wrestler.GetGender() == "Male");
        }

        //Number of female wrestlers
        public int NumOfFemaleWrestlers()
        {
            return (wrestlers.Count - NumOfMaleWrestlers());
        }

        //Number of coaches
        public int NumOfCoaches()
        {
            return coaches.Count;
        }

        //Number of hands on coaches
        public int NumOfHandsOnCoaches()
        {
            return coaches.Count(coach => coach.GetCoachType() == "Hands-on");
        }

        //Number of support coaches
        public int NumOfSupportCoaches()
        {
            return coaches.Count(coach => coach.GetCoachType() == "Support");
        }

        //Number of male coaches
        public int NumOfMaleCoaches()
        {
            return coaches.Count(coach => coach.GetGender() == "Male");
        }

        //Number of female coaches
        public int NumOfFemaleCoaches()
        {
            return (coaches.Count - NumOfMaleCoaches());
        }

        //Number of total team wins
        public int TotalTeamWins()
        {
            return wrestlers.Sum(wrestler => wrestler.GetNumOfWins());
        }

        //Number of total team losses
        public int TotalTeamLosses()
        {
            return wrestlers.Sum(wrestler => wrestler.GetNumOfLosses());
        }

        //Number of team matches
        public int TeamMatches()
        {
            return TotalTeamLosses() + TotalTeamWins();
        }

        //Win percentage
        public double TeamWinPercentage()
        {
            return Math.Round(((Convert.ToDouble(TotalTeamWins()) / Convert.ToDouble(TeamMatches())) * 100.0), 2);
        }

        //Loss percentage
        public double TeamLossPercentage()
        {
            return Math.Round(FULL_RATIO - TeamWinPercentage(), 2);
        }

        //Team point count
        public int TeamPointCount()
        {
            return wrestlers.Sum(wrestler => wrestler.GetTotalPoints());
        }

        //Number of pins
        public int NumOfPins()
        {
            return wrestlers.Sum(wrestler => wrestler.GetNumOfWinsByPin());
        }

        //Average points per game
        public int AvgPointsPerGame()
        {
            return Convert.ToInt32(TeamPointCount() / TeamMatches());
        }

        //Wrestlers per category
        public string[] WrestlersPerCategory()
        {
            string[] wrestlersInCategory = new string[17];

            for (int currentCategory = 0; currentCategory < 17; currentCategory++)
            {
                wrestlersInCategory[currentCategory] = Convert.ToString(wrestlers.Count(wrestler => wrestler.GetWeightCategory() == weightCategories[currentCategory]));
            }

            return wrestlersInCategory;
        }

        //Male wrestlers per category
        public string[] MaleWrestlersPerCategory()
        {
            string[] maleWrestlersPerCategory = new string[16];

            for (int currentCategory = 0; currentCategory < 16; currentCategory++)
            {
                maleWrestlersPerCategory[currentCategory] = Convert.ToString(wrestlers.Count(wrestler => wrestler.GetWeightCategory() == weightCategories[currentCategory] && wrestler.GetGender() == "Male"));
            }

            return maleWrestlersPerCategory;

        }
		
		//female wrestlers per category
        public string[] FemaleWrestlersPerCategory()
        {
            string[] femaleWrestlersPerCategory = new string[13];

            for (int currentCategory = 0; currentCategory < 13; currentCategory++)
            {
                femaleWrestlersPerCategory[currentCategory] = Convert.ToString(wrestlers.Count(wrestler => wrestler.GetWeightCategory() == weightCategories[currentCategory] && wrestler.GetGender() == "Female"));
            }

            return femaleWrestlersPerCategory;

        }
    }
}
