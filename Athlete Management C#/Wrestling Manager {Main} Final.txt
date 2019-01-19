using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wrestling_Manager
{
    public partial class WrestlingManger : Form
    {


        Team assembledTeam = new Team();
        string nameOfFile = "";

        OpenFileDialog openFile = new OpenFileDialog();
        SaveFileDialog saveFile = new SaveFileDialog();

        bool isSearchSuccess = false;
        int numOfMembers = 0;


        public WrestlingManger()
        {
            InitializeComponent();

            radioBtnCoach.Checked = false;
            radioBtnWrestler.Checked = false;
            Reset();
            whichCategoryLbl.Enabled = false;
            sortCategorycmbx.Enabled = false;

            sortBtn.Enabled = false;
        }


        public void Reset()
        {
            isSearchSuccess = false;
            firstNametxt.Text = "";
            lastNametxt.Text = "";
            cmbxGender.Text = "";
            schoolTxt.Text = "";
            yearsExperienceTxt.Text = "";
            cmbxCoachType.SelectedIndex = -1;
            birthdateTxt.Text = "";
            weightTxt.Text = "";
            numOfWinstxt.Text = "";
            numOfLossesTxt.Text = "";
            totalPointsTxt.Text = "";
            numOfWinsByPinTxt.Text = "";
            statusComboBox.SelectedIndex = -1;
            uniformSignedOutComboBox.SelectedIndex = -1;
            cmbxGender.SelectedIndex = -1;

            addMemberBtn.Enabled = false;
            searchMemberBtn.Enabled = false;
            updateMemberBtn.Enabled = false;
            removeMemberBtn.Enabled = false;

            firstNametxt.Enabled = false;
            lblFirstName.Enabled = false;

            lastNametxt.Enabled = false;
            lblLastName.Enabled = false;

            cmbxGender.Enabled = false;
            lblGender.Enabled = false;

            schoolTxt.Enabled = false;
            lblSchool.Enabled = false;

            yearsExperienceTxt.Enabled = false;
            lblYearsExperience.Enabled = false;

            coachTypeLbl.Enabled = false;
            cmbxCoachType.Enabled = false;

            birthdateTxt.Enabled = false;
            lblBirthday.Enabled = false;

            weightTxt.Enabled = false;
            lblWeight.Enabled = false;

            lblWins.Enabled = false;
            numOfWinstxt.Enabled = false;

            lblLosses.Enabled = false;
            numOfLossesTxt.Enabled = false;

            totalPointsTxt.Enabled = false;
            lblTotalPoints.Enabled = false;

            numOfWinsByPinTxt.Enabled = false;
            lblNumOfWinsByPin.Enabled = false;

            lblStatus.Enabled = false;
            statusComboBox.Enabled = false;

            lblUniformSignedOut.Enabled = false;
            uniformSignedOutComboBox.Enabled = false;

            lblWeightCategory.Text = "Weight Category:";
            avgPointsPerMatchLbl.Text = "Average points per match:";
            totalNumOfMatchesLbl.Text = "Total number of matches:";
            lossPercentageLbl.Text = "Loss Percentage:";
            winPercentageLbl.Text = "Win Percentage:";
        }

        private void radioBtnCoach_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnCoach.Checked == true)
            {
                Reset();

                lblLastName.Enabled = true;
                lastNametxt.Enabled = true;

                lblFirstName.Enabled = true;
                firstNametxt.Enabled = true;

                lblGender.Enabled = true;
                cmbxGender.Enabled = true;

                lblSchool.Enabled = true;
                schoolTxt.Enabled = true;

                lblYearsExperience.Enabled = true;
                yearsExperienceTxt.Enabled = true;

                coachTypeLbl.Enabled = true;
                cmbxCoachType.Enabled = true;
                cmbxCoachType.SelectedIndex = -1;

                addMemberBtn.Enabled = true;
                searchMemberBtn.Enabled = true;
                updateMemberBtn.Enabled = true;
                removeMemberBtn.Enabled = true;

                sortCategorycmbx.Items.Clear();
                sortCategorycmbx.Enabled = false;
                sortBtn.Enabled = false;
            }
            
        }

        private void radioBtnWrestler_CheckedChanged(object sender, EventArgs e)
        {
            if (radioBtnWrestler.Checked == true)
            {
                Reset();

                firstNametxt.Enabled = true;
                lblFirstName.Enabled = true;

                lastNametxt.Enabled = true;
                lblLastName.Enabled = true;

                cmbxGender.Enabled = true;
                lblGender.Enabled = true;

                schoolTxt.Enabled = true;
                lblSchool.Enabled = true;

                yearsExperienceTxt.Enabled = true;
                lblYearsExperience.Enabled = true;

                birthdateTxt.Enabled = true;
                lblBirthday.Enabled = true;

                weightTxt.Enabled = true;
                lblWeight.Enabled = true;

                lblWins.Enabled = true;
                numOfWinstxt.Enabled = true;

                lblLosses.Enabled = true;
                numOfLossesTxt.Enabled = true;

                totalPointsTxt.Enabled = true;
                lblTotalPoints.Enabled = true;

                numOfWinsByPinTxt.Enabled = true;
                lblNumOfWinsByPin.Enabled = true;

                lblStatus.Enabled = true;
                statusComboBox.Enabled = true;

                lblUniformSignedOut.Enabled = true;
                uniformSignedOutComboBox.Enabled = true;

                addMemberBtn.Enabled = true;
                searchMemberBtn.Enabled = true;
                updateMemberBtn.Enabled = true;
                removeMemberBtn.Enabled = true;

                sortCategorycmbx.Items.Clear();
                sortCategorycmbx.Enabled = false;
                sortBtn.Enabled = false;
            }
        }

        private void comboBoxFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Create
            if (comboBoxFile.SelectedIndex == 0)
            {
                nameOfFile = "";

                saveFile.Filter = "Text files (*.txt)|*.txt";
                saveFile.ShowDialog();

                nameOfFile = saveFile.FileName;

                if (nameOfFile != "")
                {
                    assembledTeam.FileNew(nameOfFile);
                    assembledTeam = new Team(nameOfFile);
                }
            }
            //Load
            else if (comboBoxFile.SelectedIndex == 1)
            {
                nameOfFile = "";

                openFile.ShowDialog();
                nameOfFile = openFile.FileName;

                if (nameOfFile != "")
                {
                    assembledTeam = new Team(nameOfFile);
                }
            }
            //Save
            else if (comboBoxFile.SelectedIndex == 2)
            {
                if (nameOfFile != "")
                {
                    assembledTeam.FileSave(nameOfFile);
                }
            }
        }

        private void addMemberBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnCoach.Checked == true)
                {
                    assembledTeam.SetMember(lastNametxt.Text, firstNametxt.Text, cmbxGender.Text, schoolTxt.Text, Convert.ToInt32(yearsExperienceTxt.Text), cmbxCoachType.Text);
                    numOfMembers++;
                }
                else
                {
                    assembledTeam.SetMember(lastNametxt.Text, firstNametxt.Text, cmbxGender.Text, schoolTxt.Text, Convert.ToInt32(yearsExperienceTxt.Text), birthdateTxt.Text, Convert.ToDouble(weightTxt.Text),
                                            Convert.ToInt32(numOfWinstxt.Text), Convert.ToInt32(numOfLossesTxt.Text), Convert.ToInt32(totalPointsTxt.Text), Convert.ToInt32(numOfWinsByPinTxt.Text),
                                            statusComboBox.Text, Convert.ToBoolean(uniformSignedOutComboBox.Text));
                    numOfMembers++;
                }

                Reset();
                radioBtnCoach.Checked = false;
                radioBtnWrestler.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid Input");
            }

        }

        private void searchMemberBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnWrestler.Checked == true)
                {
                    Wrestlers wrestler;
                    int searchIndex = assembledTeam.GetWrestler(lastNametxt.Text, firstNametxt.Text);

                    if (searchIndex != -1)
                    {
                        wrestler = assembledTeam.GetWrestlers()[searchIndex];

                        lastNametxt.Text = wrestler.GetLastName();
                        firstNametxt.Text = wrestler.GetFirstName();
                        cmbxGender.Text = wrestler.GetGender();
                        schoolTxt.Text = wrestler.GetSchool();
                        yearsExperienceTxt.Text = Convert.ToString(wrestler.GetYearsExperience());
                        birthdateTxt.Text = wrestler.GetBirthdate();
                        weightTxt.Text = Convert.ToString(wrestler.GetWeight());
                        numOfWinstxt.Text = Convert.ToString(wrestler.GetNumOfWins());
                        numOfLossesTxt.Text = Convert.ToString(wrestler.GetNumOfLosses());
                        totalPointsTxt.Text = Convert.ToString(wrestler.GetTotalPoints());
                        numOfWinsByPinTxt.Text = Convert.ToString(wrestler.GetNumOfWinsByPin());

                        lblWeightCategory.Text += " " + Convert.ToString(wrestler.GetWeightCategory());
                        avgPointsPerMatchLbl.Text += " " + Convert.ToString(wrestler.AveragePointsPerGame());
                        totalNumOfMatchesLbl.Text += " " + Convert.ToString(wrestler.TotalNumOfMatches());
                        lossPercentageLbl.Text += " " + Convert.ToString(wrestler.LosePercentage()) + "%";
                        winPercentageLbl.Text += " " + Convert.ToString(wrestler.WinPercentage()) + "%";

                        if (wrestler.GetStatus() == "Active")
                        {
                            statusComboBox.SelectedIndex = 0;
                        }

                        else if (wrestler.GetStatus() == "Injured")
                        {
                            statusComboBox.SelectedIndex = 1;
                        }

                        else
                        {
                            statusComboBox.SelectedIndex = 2;
                        }

                        if (wrestler.GetIsUniformSignedOut() == true)
                        {
                            uniformSignedOutComboBox.SelectedIndex = 0;
                        }

                        else
                        {
                            uniformSignedOutComboBox.SelectedIndex = 1;
                        }

                        updateMemberBtn.Enabled = true;
                        removeMemberBtn.Enabled = true;
                        isSearchSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("The wrestler does not exist");
                    }
                }
                else if (radioBtnCoach.Checked == true)
                {
                    Coaches coach;
                    int searchIndex = assembledTeam.GetCoach(lastNametxt.Text, firstNametxt.Text);

                    if (searchIndex != -1)
                    {
                        coach = assembledTeam.GetCoaches()[searchIndex];

                        lastNametxt.Text = coach.GetLastName();
                        firstNametxt.Text = coach.GetFirstName();
                        cmbxGender.Text = coach.GetGender();
                        schoolTxt.Text = coach.GetSchool();
                        yearsExperienceTxt.Text = Convert.ToString(coach.GetYearsExperience());

                        if (coach.GetCoachType() == "Hands-on")
                        {
                            cmbxCoachType.SelectedIndex = 0;
                        }
                        else if (coach.GetCoachType() == "Support")
                        {
                            cmbxCoachType.SelectedIndex = 1;
                        }

                        updateMemberBtn.Enabled = true;
                        removeMemberBtn.Enabled = true;
                        isSearchSuccess = true;
                    }
                    else
                    {
                        MessageBox.Show("The wrestler does not exist");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            radioBtnCoach.Checked = false;
            radioBtnWrestler.Checked = false;
            lblSortResults.Text = "";
            lblSortResults.Enabled = false;
            sortCategorycmbx.Items.Clear();
            sortCategorycmbx.Enabled = false;
            sortBtn.Enabled = false;

            numOfPeopleOnTeamLbl.Text = "Number of people on Team: ";
            numOfWrestlersLbl.Text = "Number of Wrestlers: ";
            numOfMaleWrestlersLbl.Text = "Number of male Wrestlers: ";
            numOfFemaleWrestlersLbl.Text = "Number of female Wrestlers: ";
            numOfCoachesLbl.Text = "Number of coaches: ";
            numOfHandsOnCoachesLbl.Text = "Number of hands on coaches: ";
            numOfSupportCoachesLbl.Text = "Number of support coaches: ";
            numOfMaleCoachesLbl.Text = "Number of male coaches: ";
            numOfFemaleCoachesLbl.Text = "Number of female coaches: ";
            teamWinsLbl.Text = "Team wins: ";
            teamLossesLbl.Text = "Team losses: ";
            teamWinPercentageLbl.Text = "Team win percentage: ";
            teamLossPercentageLbl.Text = "Team loss percentage: ";
            teamTotalPointsLbl.Text = "Team total points: ";
            teamPinCountLbl.Text = "Team pin count: ";
            teamNumOfMatchesLbl.Text = "# of team matches: ";
            teamAvgPointPerMatchLbl.Text = "Team average points per match: ";
            lblNumOfWrestlerInCategory.Text = "";
            lblNumOfWrestlerInCategory.Enabled = false; ;
            cmbxTypeCategory.SelectedIndex = -1;
            Reset();
        }

        private void removeMemberBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnWrestler.Checked == true)
                {
                    List<Wrestlers> wrestlers = new List<Wrestlers>();
                    int wrestlerLocation = assembledTeam.GetWrestler(lastNametxt.Text, firstNametxt.Text);
                    wrestlers = assembledTeam.GetWrestlers();

                    if (wrestlers != null)
                    {
                        if (wrestlerLocation != -1)
                        {
                            numOfMembers--;
                            wrestlers.RemoveAt(wrestlerLocation);
                            assembledTeam.SetWrestlers(wrestlers);
                        }
                    }
                }
                else
                {
                    List<Coaches> coaches = new List<Coaches>();

                    int coachLocation = assembledTeam.GetCoach(lastNametxt.Text, firstNametxt.Text);
                    coaches = assembledTeam.GetCoaches();

                    if (coaches != null)
                    {
                        if (coachLocation != -1)
                        {
                            numOfMembers--;
                            coaches.RemoveAt(coachLocation);
                            assembledTeam.SetCoaches(coaches);
                        }
                    }
                }

                radioBtnCoach.Checked = false;
                radioBtnWrestler.Checked = false;
                Reset();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void updateMemberBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnWrestler.Checked == true && isSearchSuccess == true)
                {
                    List<Wrestlers> wrestlers = new List<Wrestlers>();
                    Wrestlers newWrestler = new Wrestlers();

                    int wrestlerLocation = assembledTeam.GetWrestler(lastNametxt.Text, firstNametxt.Text);
                    wrestlers = assembledTeam.GetWrestlers();

                    wrestlers.RemoveAt(wrestlerLocation);

                    double newWeightCategory = newWrestler.WeightCategory(Convert.ToDouble(weightTxt.Text), cmbxGender.Text);

                    wrestlers.Add(new Wrestlers(lastNametxt.Text, firstNametxt.Text, cmbxGender.Text, schoolTxt.Text, Convert.ToInt32(yearsExperienceTxt.Text),
                                      birthdateTxt.Text, Convert.ToDouble(weightTxt.Text), newWeightCategory, Convert.ToInt32(numOfWinstxt.Text),
                                      Convert.ToInt32(numOfLossesTxt.Text), Convert.ToInt32(totalPointsTxt.Text), Convert.ToInt32(numOfWinsByPinTxt.Text),
                                      statusComboBox.Text, Convert.ToBoolean(uniformSignedOutComboBox.Text)));

                    assembledTeam.SetWrestlers(wrestlers);
                }
                else if (radioBtnCoach.Checked == true && isSearchSuccess == true)
                {
                    List<Coaches> coaches = new List<Coaches>();

                    int coachLocation = assembledTeam.GetCoach(lastNametxt.Text, firstNametxt.Text);
                    coaches = assembledTeam.GetCoaches();

                    coaches.RemoveAt(coachLocation);

                    coaches.Add(new Coaches(firstNametxt.Text, lastNametxt.Text, cmbxGender.Text, schoolTxt.Text, Convert.ToInt32(yearsExperienceTxt.Text), cmbxCoachType.Text));
                    assembledTeam.SetCoaches(coaches);
                }

                radioBtnCoach.Checked = false;
                radioBtnWrestler.Checked = false;
                Reset();
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid input");
            }
        }

        private void sortCoachRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (sortCoachRadioBtn.Checked == true)
            {
                radioBtnCoach.Checked = false;
                radioBtnWrestler.Checked = false;
                Reset();

                sortCategorycmbx.Items.Clear();
                sortCategorycmbx.Enabled = true;
                whichCategoryLbl.Enabled = true;
                sortCategorycmbx.Items.Add("Last Name");
                sortCategorycmbx.Items.Add("Gender");
                sortCategorycmbx.Items.Add("Type");
            }
        }

        private void sortWrestlerRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (sortWrestlerRadioBtn.Checked == true)
            {
                radioBtnCoach.Checked = false;
                radioBtnWrestler.Checked = false;
                Reset();

                sortCategorycmbx.Items.Clear();
                sortCategorycmbx.Enabled = true;
                whichCategoryLbl.Enabled = true;
                sortCategorycmbx.Items.Add("Last Name");
                sortCategorycmbx.Items.Add("Weight Category");
                sortCategorycmbx.Items.Add("Gender");
                sortCategorycmbx.Items.Add("Wins");
            }
        }

        private void sortBtn_Click(object sender, EventArgs e)
        {
            if (sortCoachRadioBtn.Checked == true)
            {
                if (sortCategorycmbx.SelectedIndex == 0)
                {
                    assembledTeam.SortCoachByLastName();
                    SortingCoaches(assembledTeam.GetCoaches());
                }
                else if (sortCategorycmbx.SelectedIndex == 1)
                {
                    assembledTeam.SortCoachGender();
                    SortingCoaches(assembledTeam.GetCoaches());
                }
                else if (sortCategorycmbx.SelectedIndex == 2)
                {
                    assembledTeam.SortTypeOfCoach();
                    SortingCoaches(assembledTeam.GetCoaches());
                }
            }
            else if (sortWrestlerRadioBtn.Checked == true)
            {
                if (sortCategorycmbx.SelectedIndex == 0)
                {
                    assembledTeam.SortWrestlerLastName();
                    SortingWrestlers(assembledTeam.GetWrestlers());
                }
                else if (sortCategorycmbx.SelectedIndex == 1)
                {
                    assembledTeam.SortWrestlerWeightCategory();
                    SortingWrestlers(assembledTeam.GetWrestlers());
                }
                else if (sortCategorycmbx.SelectedIndex == 2)
                {
                    assembledTeam.SortWrestlerGender();
                    SortingWrestlers(assembledTeam.GetWrestlers());
                }
                else if (sortCategorycmbx.SelectedIndex == 3)
                {
                    assembledTeam.SortWrestlerWins();
                    SortingWrestlers(assembledTeam.GetWrestlers());
                }
            }
        }

        private void SortingCoaches(List<Coaches> coaches)
        {
            lblSortResults.Text = "";

            for (int coachRanking = 0; coachRanking < 3; coachRanking++)
            {
                if (coaches.ElementAtOrDefault(coachRanking) != null)
                {
                    lblSortResults.Text += (coachRanking + 1) + ". " + coaches[coachRanking].GetFirstName() + " " + coaches[coachRanking].GetLastName() + "\n";
                }
            }
        }

        private void SortingWrestlers(List<Wrestlers> wrestlers)
        {
            lblSortResults.Text = "";

            for (int wrestlerRanking = 0; wrestlerRanking < 10; wrestlerRanking++)
            {
                if (wrestlers.ElementAtOrDefault(wrestlerRanking) != null)
                {
                    lblSortResults.Text += (wrestlerRanking + 1) + ". " + wrestlers[wrestlerRanking].GetFirstName() + " " + wrestlers[wrestlerRanking].GetLastName() + "\n";
                }
            }
        }

        private void sortCategorycmbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            sortBtn.Enabled = true;
        }

        private void teamStatisticsBtn_Click(object sender, EventArgs e)
        {
            List<Wrestlers> wrestlers = new List<Wrestlers>();
            List<Coaches> coaches = new List<Coaches>();
            double[] allWeightCategories = new double[17] { 38, 41, 44, 47.5, 51, 54, 57.5, 61, 64, 67.5, 72, 77, 83, 89, 95, 115, 130 };
            double[] maleWeightCategories = new double[16] { 38, 41, 44, 47.5, 51, 54, 57.5, 61, 64, 67.5, 72, 77, 83, 89, 95, 130 };
            double[] femaleWeightCategories = new double[13] { 41, 44, 47.5, 51, 54, 57.5, 61, 64, 67.5, 72, 77, 83, 115 };
            wrestlers = assembledTeam.GetWrestlers();
            coaches = assembledTeam.GetCoaches();
            

            if ((coaches != null || wrestlers != null) && cmbxTypeCategory.SelectedIndex != -1 && (numOfMembers > 0 || nameOfFile != "")) 
            {
                string[] teamStats = new string[17];
                teamStats = assembledTeam.TransferTeamStats();

                numOfPeopleOnTeamLbl.Text = "Number of people on Team: " + teamStats[0];
                numOfWrestlersLbl.Text = "Number of Wrestlers: " + teamStats[1];
                numOfMaleWrestlersLbl.Text = "Number of male Wrestlers: " + teamStats[2];
                numOfFemaleWrestlersLbl.Text = "Number of female Wrestlers: " + teamStats[3];
                numOfCoachesLbl.Text = "Number of coaches: " + teamStats[4];
                numOfHandsOnCoachesLbl.Text = "Number of hands on coaches: " + teamStats[5];
                numOfSupportCoachesLbl.Text = "Number of support coaches: " + teamStats[6];
                numOfMaleCoachesLbl.Text = "Number of male coaches: " + teamStats[7];
                numOfFemaleCoachesLbl.Text = "Number of female coaches: " + teamStats[8];
                teamWinsLbl.Text = "Team wins: " + teamStats[9];
                teamLossesLbl.Text = "Team losses: " + teamStats[10];
                teamWinPercentageLbl.Text = "Team win percentage: " + teamStats[11] + "%";
                teamLossPercentageLbl.Text = "Team loss percentage: " + teamStats[12] + "%";
                teamTotalPointsLbl.Text = "Team total points: " + teamStats[13];
                teamPinCountLbl.Text = "Team pin count: " + teamStats[14];
                teamNumOfMatchesLbl.Text = "# of team matches: " + teamStats[15];
                teamAvgPointPerMatchLbl.Text = "Team average points per match: " + teamStats[16];
                lblNumOfWrestlerInCategory.Text = "";
                lblNumOfWrestlerInCategory.Enabled = true;

                if (cmbxTypeCategory.SelectedIndex == 0)
                {
                    string[] allWrestlerCategories = new string[17];
                    allWrestlerCategories = assembledTeam.TransferNumOfWrestlersCategory();

                    for (int currentCategory = 0; currentCategory < 17; currentCategory++)
                    {
                        lblNumOfWrestlerInCategory.Text += (currentCategory + 1) + ". " + allWeightCategories[currentCategory] + "Kg:  " + allWrestlerCategories[currentCategory] + " wrestler(s)\n";
                    }
                }
                else if (cmbxTypeCategory.SelectedIndex == 1)
                {
                    string[] femaleWrestlerCategories = new string[13];
                    femaleWrestlerCategories = assembledTeam.TransferNumOfFemaleWrestlersCategory();

                    for (int currentCategory = 0; currentCategory < 13; currentCategory++)
                    {
                        lblNumOfWrestlerInCategory.Text += (currentCategory + 1) + ". " + femaleWeightCategories[currentCategory] + "Kg:  " + femaleWrestlerCategories[currentCategory] + " wrestler(s)\n";
                    }
                }
                else if (cmbxTypeCategory.SelectedIndex == 2)
                {
                    string[] maleWrestlerCategories = new string[16];
                    maleWrestlerCategories = assembledTeam.TransferNumOfMaleWrestlersCategory();

                    for (int currentCategory = 0; currentCategory < 16; currentCategory++)
                    {
                        lblNumOfWrestlerInCategory.Text += (currentCategory + 1) + ". " + maleWeightCategories[currentCategory] + "Kg:  " + maleWrestlerCategories[currentCategory] + " wrestler(s)\n";
                    }
                }
            }

        }

        private void cmbxTypeCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void WrestlingManger_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Please create or load a new file in the 'file options' box to save progress");
        }
           

    }
}
