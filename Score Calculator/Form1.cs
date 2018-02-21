using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Score_Calculator
{
    public partial class frmScoreCalculator : Form
    {
        public frmScoreCalculator()
        {
            InitializeComponent();
        }
        List<int> scores = new List<int>();
        private void btnAddScore_Click(object sender, EventArgs e)
        {
            int scoreCount = 0;
            int scoreTotal = 0;
            int scoreAverage = 0;
            try
            {
                if (IsValidData())
                {
                    int score = Convert.ToInt32(txtScore.Text);

                    scores.Add(score);

                    foreach (int s in scores)
                    {
                        scoreCount++;
                        lblScoreCount.Text = scoreCount.ToString();

                        scoreTotal += s;
                        lblScoreTotal.Text = scoreTotal.ToString();

                        scoreAverage = scoreTotal / scoreCount;
                        lblAverage.Text = scoreAverage.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "" + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
            
        }

        public bool IsValidData()
        {
            return
                IsPresent(txtScore, "Test Score") &&
                IsInteger(txtScore, "Test Score") &&
                IsWithinRange(txtScore, "Test Score", 0, 100);
        }

        public bool IsPresent(TextBox textBox, string name)
        {
            if (textBox.Text == "")
            {
                MessageBox.Show(name + " is a required field and cannot be empty.", "Entry Error");
                textBox.Focus();
                return false;
            }
            return true;
        }

        public bool IsInteger(TextBox textBox, String name)
        {
            int number = 0;
            if (int.TryParse(textBox.Text, out number))
            {
                return true;
            }
            else
            {
                MessageBox.Show(name + " must be an integer,", "Entry Error");
                textBox.Focus();
                return false;
            }
        }

        public bool IsWithinRange(TextBox textbox, string name, int min, int max)
        {
            int number = Convert.ToInt16(textbox.Text);
            if (number < min || number > max)
            {
                MessageBox.Show(name + " must be between " + min
                    + " and " + max + ".", "Entry Error");
                textbox.Focus();
                return false;
            }
            return true;
        }


        private void btnDisplayScores_Click(object sender, EventArgs e)
        {
            string scoreList = "";
            foreach (int score in scores)
            {
                scoreList += score.ToString() + "\n";
            }
            MessageBox.Show(scoreList, "Scores");
        }

        private void btnClearScores_Click(object sender, EventArgs e)
        {
            scores.Clear();
            txtScore.Text = "";
            lblScoreTotal.Text = "";
            lblScoreCount.Text = "";
            lblAverage.Text = "";

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
