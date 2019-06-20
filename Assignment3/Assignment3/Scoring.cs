using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Assignment3
{
	public partial class Scoring : Form
	{
		public Display Display = new Display();
        public TournamentSetting Test = new TournamentSetting();
        
			// dim some variable to store the data
			private int bonus = 0;
			private int play = 1; // this variable is to determint which team is attacking
			private int score1 = 0;
			private int score2 = 0;
            

		public Scoring()
		{
			InitializeComponent();
		}

		// for start a new round, each round need to click this button to reset all score
		private void Startbtn_Click(object sender, EventArgs e)
		{
			bonus = 0;
			play = 1;
			score1 = 0;
			score2 = 0;
			// reset all the score
			
			Display.T1Score.Text = score1+"";
			Display.T2Score.Text = score2+"";
			Display.CBLabel.Text = bonus+"";
			// show the round number
			Display.RoundDisplayLabel.Text = RNBox.Text;
			Display.ALabel.Text = "ATTACKING!";
			Display.ALabel2.Text = "";
		}
			// change team name when the team name box is changed
		private void TNBox1_TextChanged(object sender, EventArgs e)
		{
			Display.TNLabel1.Text = TNBox1.Text;
		}

		private void TNBox2_TextChanged(object sender, EventArgs e)
		{
			Display.TNLabel2.Text = TNBox2.Text;
		}
			// show the display window when load the score window
			private void Scoring_Load(object sender, EventArgs e)
			{
				Display.Show();
                Test.Show();
			}
			// 
			private void TMBox1_TextChanged(object sender, EventArgs e)
			{
				Display.TMLabel1.Text = TMBox1.Text;
			}

			private void TMBox2_TextChanged(object sender, EventArgs e)
			{
				Display.TMLabel2.Text = TMBox2.Text;
			}
			// gain bonus point when click the bonus button
			private void Bonusbtn_Click(object sender, EventArgs e)
			{
				bonus += 1;
				// in order to make sure the bonus not bigger than 3 and can reset the bonus point if error operate happens
				if (bonus > 3)
					bonus = 0;
				Display.CBLabel.Text = bonus+"";
			}
			// for two team the goal button will record the score when goal
			private void Goalbtn_Click(object sender, EventArgs e)
			{
				// if the play is odd, team1 is attcking
				if (play % 2 == 1)
				{
					score1 += 5;
					score1 += bonus;
					Display.ALabel2.Text = "ATTACKING!";
					Display.ALabel.Text = "";
				}
				// if the play is even, team2 is attacking
				if (play % 2 == 0)
				{
					score2 += 5;
					score2 += bonus;
					Display.ALabel.Text = "ATTACKING!";
					Display.ALabel2.Text = "";
				}
				// show the current score and reset the bonus
				Display.T1Score.Text = score1+"";
				Display.T2Score.Text = score2+"";
				bonus = 0;
				Display.CBLabel.Text = bonus+"";
				// another team is attacking now
				play += 1;
			}
			// when the ball is intercepted, the attacking team is changed and the bonus will reset
			private void Interceptedbtn_Click(object sender, EventArgs e)
			{
				bonus = 0;
				Display.CBLabel.Text = bonus+"";
				play += 1;
				if (play % 2 == 1)
				{
					Display.ALabel.Text = "ATTACKING!";
					Display.ALabel2.Text = "";
				}
				if (play % 2 == 0)
				{
					Display.ALabel2.Text = "ATTACKING!";
					Display.ALabel.Text = "";
				}
			}

        private async void TNBox1_Validated(object sender, EventArgs e)
        {
            string result = await ApiHandler.getTeams("1137");
            List<Team> teams = ApiHandler.jsonTo<List<Team>>(result);
            foreach (Team t in teams) {
                if (t.name.Equals(TNBox1.Text)) {
                    result = await ApiHandler.getPlayers(t.id);
                    List<Player> players = ApiHandler.jsonTo<List<Player>>(result);
                    foreach (Player p in players) {
                        TMBox1.Text += p.name + "\t\t\n";
                    }
                }
            }
            
        }

        private async void TNBox2_Validated(object sender, EventArgs e)
        {
            string result = await ApiHandler.getTeams("1137");
            List<Team> teams = ApiHandler.jsonTo<List<Team>>(result);
            foreach (Team t in teams)
            {
                if (t.name.Equals(TNBox2.Text))
                {
                    result = await ApiHandler.getPlayers(t.id);
                    List<Player> players = ApiHandler.jsonTo<List<Player>>(result);
                    foreach (Player p in players)
                    {
                        TMBox2.Text += p.name + "\t\t\n";
                    }
                }
            }

        }
    }

		
	
}
