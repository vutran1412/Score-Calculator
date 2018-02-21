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
    }
}
