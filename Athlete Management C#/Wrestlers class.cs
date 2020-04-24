using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wrestling_Manager
{
    class Wrestlers : Member
    {

        private string birthdate;
        private double weight;
        private double weightCategory;
        private int numOfWins = 0;
        private int numOfLosses = 0;
        private int totalPoints = 0;
        private int numOfWinsByPin = 0;
        private string status;
        private bool isUniformSignedOut = false;

        public Wrestlers() : base()
        {
            birthdate = "";
            weight = 0;
            weightCategory = 0;
            numOfWins = 0;
            numOfLosses = 0;
            totalPoints = 0;
            numOfWinsByPin = 0;
            status = "";
            isUniformSignedOut = false;
        }

        public Wrestlers(string firstName, string lastName, string gender, string school, int yearsExperience,
                         string birthdate, double weight, double weightCategory, int numOfWins, int numOfLosses, int totalPoints, int numOfWinsByPin, string status,
                         bool isUniformSignedOut)
            : base(firstName, lastName, gender, school, yearsExperience)
        {
            this.birthdate = birthdate;
            this.weight = weight;
            this.weightCategory = weightCategory;
            this.numOfWins = numOfWins;
            this.numOfLosses = numOfLosses;
            this.totalPoints = totalPoints;
            this.numOfWinsByPin = numOfWinsByPin;
            this.status = status;
            this.isUniformSignedOut = isUniformSignedOut;
        }

        public string GetBirthdate()
        {
            return birthdate;
        }

        public double GetWeight()
        {
            return weight;
        }

        public double GetWeightCategory()
        {
            return weightCategory;
        }

        public int GetNumOfWins()
        {
            return numOfWins;
        }

        public int GetNumOfLosses()
        {
            return numOfLosses;
        }

        public int GetTotalPoints()
        {
            return totalPoints;
        }

        public int GetNumOfWinsByPin()
        {
            return numOfWinsByPin;
        }

        public string GetStatus()
        {
            return status;
        }

        public bool GetIsUniformSignedOut()
        {
            return isUniformSignedOut;
        }

        public void SetBirthdate(string birthdate)
        {
            this.birthdate = birthdate;
        }

        public void SetWeight(double weight)
        {
            this.weight = weight;
        }

        public void SetWeightCategory(double weightCategory)
        {
            this.weightCategory = weightCategory;
        }

        public void SetNumOfWins(int numOfWins)
        {
            this.numOfWins = numOfWins;
        }

        public void SetNumOfLosses(int numOfLosses)
        {
            this.numOfLosses = numOfLosses;
        }

        public void SetTotalPoints(int totalPoints)
        {
            this.totalPoints = totalPoints;
        }

        public void SetNumOfWinsByPin(int numOfWinsByPin)
        {
            this.numOfWinsByPin = numOfWinsByPin;
        }

        public void SetStatus(string status)
        {
            this.status = status;
        }

        public void SetIsUniformSignedOut(bool isUniformSignedOut)
        {
            this.isUniformSignedOut = isUniformSignedOut;
        }


        //Behaviours
        public int TotalNumOfMatches()
        {
            return numOfWins + numOfLosses;
        }

        public double WinPercentage()
        {
            return Math.Round((Convert.ToDouble(numOfWins) / Convert.ToDouble(TotalNumOfMatches())) * 100.0, 2);
        }

        public double LosePercentage()
        {
            return Math.Round(100 - WinPercentage(), 2);
        }
        public int AveragePointsPerGame()
        {
            return Convert.ToInt32(totalPoints / TotalNumOfMatches());
        }

        public double WeightCategory(double weight, string gender)
        {

            if (weight >= 33 && weight <= 130)
            {
                if (weight <= 38 && gender == "Female")
                {
                    return 38;
                }
                else if (weight <= 41)
                {
                    return 41;
                }
                else if (weight <= 44)
                {
                    return 44;
                }
                else if (weight <= 47.5)
                {
                    return 47.5;
                }
                else if (weight <= 51)
                {
                    return 51;
                }
                else if (weight <= 54)
                {
                    return 54;
                }
                else if (weight <= 57.5)
                {
                    return 57.5;
                }
                else if (weight <= 61)
                {
                    return 61;
                }
                else if (weight <= 64)
                {
                    return 64;
                }
                else if (weight <= 67.5)
                {
                    return 67.5;
                }
                else if (weight <= 72)
                {
                    return 72;
                }
                else if (weight <= 77)
                {
                    return 77;
                }
                else if (weight <= 83)
                {
                    return 83;
                }
                else if (weight <= 115 && gender == "Female")
                {
                    return 115;
                }
                else if (weight <= 89)
                {
                    return 89;
                }
                else if (weight <= 95)
                {
                    return 95;
                }
                else if (weight <= 130 && gender == "Male")
                {
                    return 130;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }
    }
}
