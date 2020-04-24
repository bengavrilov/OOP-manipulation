using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrestling_Manager
{
    class Team
    {

        List<Wrestlers> wrestlers = new List<Wrestlers>();
        List<Coaches> coaches = new List<Coaches>();
        List<string> input = new List<string>();
        FileIO fileInfo = new FileIO();

        public class Comparision : IComparer<Member>
        {

            public int Compare(Member mem1, Member mem2)
            {
                if (mem1.GetLastName() == mem2.GetLastName())
                {
                    return mem1.GetFirstName().CompareTo(mem2.GetFirstName());
                }
                else
                {
                    return mem1.GetLastName().CompareTo(mem2.GetLastName());
                }
            }

        }

        public Team()
        {

        }

        public List<Coaches> GetCoaches()
        {
            return coaches;
        }

        public List<Wrestlers> GetWrestlers()
        {
            return wrestlers;
        }

        public void SetCoaches(List<Coaches> coaches)
        {
            this.coaches = coaches;
        }

        public void SetWrestlers(List<Wrestlers> wrestlers)
        {
            this.wrestlers = wrestlers;
        }

        //Read Files
        public Team(string locationOfFile)
        {
            input = fileInfo.ReadFile(locationOfFile);

            for (int infoCounter = 0; infoCounter < input.Count; infoCounter++)
            {
                string[] infoStorage = input[infoCounter].Split(',');

                if (infoStorage.First() == "Coach")
                {
                    coaches.Add(new Coaches(infoStorage[1], infoStorage[2], infoStorage[3], infoStorage[4], Convert.ToInt32(infoStorage[5]), infoStorage[6]));
                }
                else if (infoStorage.First() == "Wrestler")
                {
                    wrestlers.Add(new Wrestlers(infoStorage[1], infoStorage[2], infoStorage[3], infoStorage[4], Convert.ToInt32(infoStorage[5]), infoStorage[6],
                        Convert.ToDouble(infoStorage[7]), Convert.ToDouble(infoStorage[8]), Convert.ToInt32(infoStorage[9]), Convert.ToInt32(infoStorage[10]),
                        Convert.ToInt32(infoStorage[11]), Convert.ToInt32(infoStorage[12]), infoStorage[13], Convert.ToBoolean(infoStorage[14])));
                }
                else
                {

                }

                Array.Clear(infoStorage, 0, infoStorage.Length);

            }
        }

        //Save member
        public void FileSave(string locationOfFile)
        {
            List<string> outgoingData = new List<string>();

            outgoingData.Clear();

            for (int coachCounter = 0; coachCounter < coaches.Count; coachCounter++)
            {
                outgoingData.Add("Coach,");
                outgoingData[coachCounter] += coaches[coachCounter].GetLastName() + ",";
                outgoingData[coachCounter] += coaches[coachCounter].GetFirstName() + ",";
                outgoingData[coachCounter] += coaches[coachCounter].GetGender() + ",";
                outgoingData[coachCounter] += coaches[coachCounter].GetSchool() + ",";
                outgoingData[coachCounter] += coaches[coachCounter].GetYearsExperience() + ",";
                outgoingData[coachCounter] += coaches[coachCounter].GetCoachType();
            }

            for (int wrestlerCounter = 0; wrestlerCounter < wrestlers.Count; wrestlerCounter++)
            {
                outgoingData.Add("Wrestler,");
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetLastName() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetFirstName() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetGender() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetSchool() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetYearsExperience() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetBirthdate() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetWeight() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetWeightCategory() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetNumOfWins() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetNumOfLosses() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetTotalPoints() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetNumOfWinsByPin() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetStatus() + ",";
                outgoingData[coaches.Count + wrestlerCounter] += wrestlers[wrestlerCounter].GetIsUniformSignedOut();
            }

            fileInfo.UpdateFile(outgoingData, locationOfFile);
        }

        //create file
        public void FileNew(string locationOfFile)
        {
            fileInfo.CreateFile(locationOfFile);
        }

        //Calc stats
        public string[] TransferTeamStats()
        {

            TeamStatistics storedStats = new TeamStatistics(wrestlers, coaches);
            string[] teamStats = new string[17];

            teamStats[0] = Convert.ToString(storedStats.NumOfPeopleOnTeam());
            teamStats[1] = Convert.ToString(storedStats.NumOfWrestlers());
            teamStats[2] = Convert.ToString(storedStats.NumOfMaleWrestlers());
            teamStats[3] = Convert.ToString(storedStats.NumOfFemaleWrestlers());
            teamStats[4] = Convert.ToString(storedStats.NumOfCoaches());
            teamStats[5] = Convert.ToString(storedStats.NumOfHandsOnCoaches());
            teamStats[6] = Convert.ToString(storedStats.NumOfSupportCoaches());
            teamStats[7] = Convert.ToString(storedStats.NumOfMaleCoaches());
            teamStats[8] = Convert.ToString(storedStats.NumOfFemaleCoaches());
            teamStats[9] = Convert.ToString(storedStats.TotalTeamWins());
            teamStats[10] = Convert.ToString(storedStats.TotalTeamLosses());
            teamStats[11] = Convert.ToString(storedStats.TeamWinPercentage());
            teamStats[12] = Convert.ToString(storedStats.TeamLossPercentage());
            teamStats[13] = Convert.ToString(storedStats.TeamPointCount());
            teamStats[14] = Convert.ToString(storedStats.NumOfPins());
            teamStats[15] = Convert.ToString(storedStats.TeamMatches());
            teamStats[16] = Convert.ToString(storedStats.AvgPointsPerGame());

            return teamStats;
        }

        //calc weightstats
        public string[] TransferNumOfWrestlersCategory()
        {

            TeamStatistics storedNumOfAllPeople = new TeamStatistics(wrestlers, coaches);
            string[] teamNumOfAllPeople = new string[17];

            teamNumOfAllPeople = storedNumOfAllPeople.WrestlersPerCategory();
            return teamNumOfAllPeople;
        }

        //calc male weightstats
        public string[] TransferNumOfMaleWrestlersCategory()
        {

            TeamStatistics storedNumOfAllPeople = new TeamStatistics(wrestlers, coaches);
            string[] teamNumOfAllPeople = new string[16];

            teamNumOfAllPeople = storedNumOfAllPeople.MaleWrestlersPerCategory();
            return teamNumOfAllPeople;
        }

        //calc female weightstats
        public string[] TransferNumOfFemaleWrestlersCategory()
        {

            TeamStatistics storedNumOfAllPeople = new TeamStatistics(wrestlers, coaches);
            string[] teamNumOfAllPeople = new string[13];

            teamNumOfAllPeople = storedNumOfAllPeople.FemaleWrestlersPerCategory();
            return teamNumOfAllPeople;
        }

        //Add Coach
        public void SetMember(string lastName, string firstName, string gender, string school, int yearsExperience, string coachType)
        {
            coaches.Add(new Coaches(lastName, firstName, gender, school, yearsExperience, coachType));
        }

        //Add wrestler
        public void SetMember(string lastName, string firstName, string gender, string school, int yearsExperience, string birthdate, double weight, int numOfWins, int numOfLosses,  int totalPoints,
                              int numOfWinsByPin, string status, bool isUniformSignedOut)
        {
            Wrestlers newWrestler = new Wrestlers();

            double weightCategory = newWrestler.WeightCategory(weight, gender);

            wrestlers.Add(new Wrestlers(lastName, firstName, gender, school, yearsExperience, birthdate, weight, weightCategory, numOfWins, numOfLosses, totalPoints, numOfWinsByPin, status, 
                          isUniformSignedOut));

        }

        // FINDING A WRESTLER-edit
        public int GetWrestler(string lastName, string firstName)
        {
            return wrestlers.FindIndex(wrestler => wrestler.GetLastName() == lastName && wrestler.GetFirstName() == firstName);

        }

        // FINDING A COACH
        public int GetCoach(string lastName, string firstName)
        {
            return coaches.FindIndex(coach => coach.GetFirstName() == firstName && coach.GetLastName() == lastName);
        }

        //sorting
        public void SortTypeOfCoach()
        {
            coaches.Sort((coach1, coach2) => (coach1.GetCoachType()).CompareTo(coach2.GetCoachType()));
        }

        public void SortCoachGender()
        {
            coaches.Sort((coach1, coach2) => (coach1.GetGender()).CompareTo(coach2.GetGender()));
        }

        public void SortCoachByLastName()
        {
            coaches.Sort(new Comparision());
        }

        public void SortWrestlerLastName()
        {
            wrestlers.Sort(new Comparision());
        }

        public void SortWrestlerWeightCategory()
        {
            wrestlers.Sort((wrestler1, wrestler2) => (wrestler1.GetWeightCategory()).CompareTo(wrestler2.GetWeightCategory()));
        }

        public void SortWrestlerGender()
        {
            wrestlers.Sort((wrestler1, wrestler2) => (wrestler1.GetGender()).CompareTo(wrestler2.GetGender()));
        }

        public void SortWrestlerWins()
        {
            wrestlers.Sort((wrestler1, wrestler2) => (wrestler1.GetNumOfWins()).CompareTo(wrestler2.GetNumOfWins()));
        }
    }
}
