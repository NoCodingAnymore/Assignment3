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
        public TournamentSettings Test = new TournamentSettings();
        public string team1ID;
        public string team2ID;
        
			// dim some variable to store the data
		private int bonus = 0;
        private int play = 1; // this variable is to determint which team is attacking
		private int score1 = 0;
		private int score2 = 0;
        private int roundNum = 0;
        private int tie = 0;
        private int team1RoundWin = 0;
        private int team2RoundWin = 0;
        private int team1FinalScore = 0;
        private int team2FinalScore = 0;
        public List<List<string>> matchList = new List<List<string>>();
        
        // for all timer when red card shows
        TimeSpan ts1 = new TimeSpan(0, 0, 3);
        TimeSpan ts2 = new TimeSpan(0, 0, 3);
        TimeSpan ts3 = new TimeSpan(0, 0, 3);
        TimeSpan ts4 = new TimeSpan(0, 0, 3);
        TimeSpan ts5 = new TimeSpan(0, 0, 3);
        TimeSpan ts6 = new TimeSpan(0, 0, 3);
        TimeSpan ts7 = new TimeSpan(0, 0, 3);
        TimeSpan ts8 = new TimeSpan(0, 0, 3);
        TimeSpan ts9 = new TimeSpan(0, 0, 3);
        TimeSpan ts10 = new TimeSpan(0, 0, 3);

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
            roundNum = 1;
            RNumLabel.Text = "1";
            team1RoundWin = 0;
            team2RoundWin = 0;
            tie = 0;
            team1FinalScore = 0;
            team2FinalScore = 0;
            // reset all the score
            // 数据库查找到这两个队，将队员分配到所有的队员的部分
            // Example : T1M1Box

            Display.T1Score.Text = score1+"";
			Display.T2Score.Text = score2+"";
			Display.CBLabel.Text = bonus+"";
			// show the round number
			Display.RoundDisplayLabel.Text = RNumLabel.Text;
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
			Display.T1M1Label.Text = T1M1Box.Text;
		}
        private void T1M2Box_TextChanged(object sender, EventArgs e)
        {
            Display.T1M2Label.Text = T1M2Box.Text;
        }
        private void T1M3Box_TextChanged(object sender, EventArgs e)
        {
            Display.T1M3Label.Text = T1M3Box.Text;
        }
        private void T1M4Box_TextChanged(object sender, EventArgs e)
        {
            Display.T1M4Label.Text = T1M4Box.Text;
        }
        private void T1M5Box_TextChanged(object sender, EventArgs e)
        {
            Display.T1M5Label.Text = T1M5Box.Text;
        }
        private void TMBox2_TextChanged(object sender, EventArgs e)
		{
			Display.T2M1Label.Text = T2M1Box.Text;
		}
        private void T2M2Box_TextChanged(object sender, EventArgs e)
        {
            Display.T2M2Label.Text = T2M2Box.Text;
        }
        private void T2M3Box_TextChanged(object sender, EventArgs e)
        {
            Display.T2M3Label.Text = T2M3Box.Text;
        }
        private void T2M4Box_TextChanged(object sender, EventArgs e)
        {
            Display.T2M4Label.Text = T2M4Box.Text;
        }
        private void T2M5Box_TextChanged(object sender, EventArgs e)
        {
            Display.T2M5Label.Text = T2M5Box.Text;
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
        // when a round is over, tick it to get the result of this round
        private void endRound_Click(object sender, EventArgs e)
        {
            if (roundNum <= 3)
            {
                roundNum++;
                // round 3 is over
                if (roundNum == 4)
                {
                    RNumLabel.Text = 3.ToString();
                    Display.RoundDisplayLabel.Text = 3.ToString();
                }
                else
                {
                    RNumLabel.Text = roundNum.ToString();
                    Display.RoundDisplayLabel.Text = RNumLabel.Text;
                }
                // team1 win this round
                if (score1 > score2)
                {
                    team1RoundWin++;
                    Display.T1RoundWin.Text = team1RoundWin.ToString();
                }
                // team2 win this round
                else if (score1 < score2)
                {
                    team2RoundWin++;
                    Display.T2RoundWin.Text = team2RoundWin.ToString();
                }
                else
                {
                    tie++;
                }
                // data add
                team1FinalScore += score1;
                team2FinalScore += score2;
                bonus = 0;
                play = 1;
                score1 = 0;
                score2 = 0;
                Display.T1Score.Text = score1 + "";
                Display.T2Score.Text = score2 + "";
                Display.CBLabel.Text = bonus + "";
                // show the round number
                //Display.RoundDisplayLabel.Text = RNumLabel.Text;
                Display.ALabel.Text = "ATTACKING!";
                Display.ALabel2.Text = "";
            }            
        }

        private async void endMatch_Click(object sender, EventArgs e)
        {
            //only work when all 3 rounds over
            if (roundNum == 4)
            {
                Match match = new Match("qual", "1");
                await ApiHandler.addTeamToMatch(Test.tournamentID, team1ID, match);
                await ApiHandler.addTeamToMatch(Test.tournamentID, team2ID, match);
                // if team1 win this match
                if (team1RoundWin > team2RoundWin)
                {
                    foreach (DataGridViewRow row in Test.table.board.Rows)
                    {
                        //find the match who win, add win and score
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox1.Text))
                        {
                            row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                            row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) + 2;
                            Score score = new Score(Convert.ToString(row.Cells[5].Value));
                            await ApiHandler.updateScore(Test.tournamentID, team1ID, match.number, score);
                            
                        }
                        //find the match who lose, add lose
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox2.Text))
                        {
                            row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) + 1;
                        }

                    }
                }
                // if team2 wins this match
                else if (team1RoundWin < team2RoundWin)
                {
                    foreach (DataGridViewRow row in Test.table.board.Rows)
                    {
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox2.Text))
                        {
                            row.Cells[2].Value = Convert.ToInt32(row.Cells[2].Value) + 1;
                            row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) + 2;
                            Score score = new Score(Convert.ToString(row.Cells[5].Value));
                            await ApiHandler.updateScore(Test.tournamentID, team2ID, match.number, score);
                        }
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox1.Text))
                        {
                            row.Cells[3].Value = Convert.ToInt32(row.Cells[3].Value) + 1;
                        }
                    }
                }
                else// ties
                {
                    foreach (DataGridViewRow row in Test.table.board.Rows)
                    {
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox1.Text))
                        {
                            row.Cells[4].Value = Convert.ToInt32(row.Cells[4].Value) + 1;
                            row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) + 1;
                            Score score = new Score(Convert.ToString(row.Cells[5].Value));
                            await ApiHandler.updateScore(Test.tournamentID, team2ID, match.number, score);
                        }
                        if (Convert.ToString(row.Cells[1].Value).Equals(TNBox2.Text))
                        {
                            row.Cells[4].Value = Convert.ToInt32(row.Cells[4].Value) + 1;
                            row.Cells[5].Value = Convert.ToInt32(row.Cells[5].Value) + 1;
                            Score score = new Score(Convert.ToString(row.Cells[5].Value));
                            await ApiHandler.updateScore(Test.tournamentID, team2ID, match.number, score);
                        }

                    }
                }
                //add TP to two teams that attend this match
                foreach (DataGridViewRow row in Test.table.board.Rows)
                {
                    if (Convert.ToString(row.Cells[1].Value).Equals(TNBox1.Text))
                    {
                        row.Cells[6].Value = Convert.ToInt32(row.Cells[6].Value) + team1FinalScore;
                        
                    }
                    if (Convert.ToString(row.Cells[1].Value).Equals(TNBox2.Text))
                    {
                        row.Cells[6].Value = Convert.ToInt32(row.Cells[6].Value) + team2FinalScore;
                    }

                }
                // sort the score table base on the score
                Test.table.board.Sort(Test.table.board.Columns[6],ListSortDirection.Descending);
                int rank = 1;
                // give it correct rank
                foreach (DataGridViewRow row in Test.table.board.Rows)
                {               
                    row.Cells[0].Value = rank;                  
                    rank++;

                }
            }
        }

        // all 10 timer for the player who get red card
        private void t1m1R_CheckedChanged(object sender, EventArgs e)
        {
            if (t1m1R.Checked == true)// change its game status and start timer
            {
                Display.T1M1Status.Text = "OUT";
                Display.T1M1Status.ForeColor = Color.Red;
                t1m1timer.Enabled = true;
                t1m1timer_Tick(sender, e);
            }
            else// back to game
            {
                Display.T1M1Status.Text = "IN-PLAY";
                Display.T1M1Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t1m2R_CheckedChanged(object sender, EventArgs e)
        {
            if (t1m2R.Checked == true)
            {
                Display.T1M2Status.Text = "OUT";
                Display.T1M2Status.ForeColor = Color.Red;
                t1m2timer.Enabled = true;
                t1m2timer_Tick(sender, e);
            }
            else
            {
                Display.T1M2Status.Text = "IN-PLAY";
                Display.T1M2Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t1m3R_CheckedChanged(object sender, EventArgs e)
        {
            if (t1m3R.Checked == true)
            {
                Display.T1M3Status.Text = "OUT";
                Display.T1M3Status.ForeColor = Color.Red;
                t1m3timer.Enabled = true;
                t1m3timer_Tick(sender, e);
            }
            else
            {
                Display.T1M3Status.Text = "IN-PLAY";
                Display.T1M3Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t1m4R_CheckedChanged(object sender, EventArgs e)
        {
            if (t1m4R.Checked == true)
            {
                Display.T1M4Status.Text = "OUT";
                Display.T1M4Status.ForeColor = Color.Red;
                t1m4timer.Enabled = true;
                t1m4timer_Tick(sender, e);
            }
            else
            {
                Display.T1M4Status.Text = "IN-PLAY";
                Display.T1M4Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t1m5R_CheckedChanged(object sender, EventArgs e)
        {
            if (t1m5R.Checked == true)
            {
                Display.T1M5Status.Text = "OUT";
                Display.T1M5Status.ForeColor = Color.Red;
                t1m5timer.Enabled = true;
                t1m5timer_Tick(sender, e);
            }
            else
            {
                Display.T1M5Status.Text = "IN-PLAY";
                Display.T1M5Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t2m1R_CheckedChanged(object sender, EventArgs e)
        {
            if (t2m1R.Checked == true)
            {
                Display.T2M1Status.Text = "OUT";
                Display.T2M1Status.ForeColor = Color.Red;
                t2m1timer.Enabled = true;
                t2m1timer_Tick(sender, e);
            }
            else
            {
                Display.T2M1Status.Text = "IN-PLAY";
                Display.T2M1Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t2m2R_CheckedChanged(object sender, EventArgs e)
        {
            if (t2m2R.Checked == true)
            {
                Display.T2M2Status.Text = "OUT";
                Display.T2M2Status.ForeColor = Color.Red;
                t2m2timer.Enabled = true;
                t2m2timer_Tick(sender, e);
            }
            else
            {
                Display.T2M2Status.Text = "IN-PLAY";
                Display.T2M2Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t2m3R_CheckedChanged(object sender, EventArgs e)
        {
            if (t2m3R.Checked == true)
            {
                Display.T2M3Status.Text = "OUT";
                Display.T2M3Status.ForeColor = Color.Red;
                t2m3timer.Enabled = true;
                t2m3timer_Tick(sender, e);
            }
            else
            {
                Display.T2M3Status.Text = "IN-PLAY";
                Display.T2M3Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t2m4R_CheckedChanged(object sender, EventArgs e)
        {
            if (t2m4R.Checked == true)
            {
                Display.T2M4Status.Text = "OUT";
                Display.T2M4Status.ForeColor = Color.Red;
                t2m4timer.Enabled = true;
                t2m4timer_Tick(sender, e);
            }
            else
            {
                Display.T2M4Status.Text = "IN-PLAY";
                Display.T2M4Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t2m5R_CheckedChanged(object sender, EventArgs e)
        {
            if (t2m5R.Checked == true)
            {
                Display.T2M5Status.Text = "OUT";
                Display.T2M5Status.ForeColor = Color.Red;
                t2m5timer.Enabled = true;
                t2m5timer_Tick(sender, e);
            }
            else
            {
                Display.T2M5Status.Text = "IN-PLAY";
                Display.T2M5Status.ForeColor = Color.ForestGreen;
            }
        }

        private void t1m1timer_Tick(object sender, EventArgs e)
        {
            
            Display.t1m1TimeLabel.Text = ts1.Minutes.ToString() + ":" + ts1.Seconds.ToString();
            ts1 = ts1.Subtract(new TimeSpan(0, 0, 1));
            t1m1R.Enabled = false; // the red card checkbox cannot be clicked when you already get a red card
            if (ts1.TotalSeconds < 0.0)//time over
            {
                t1m1timer.Enabled = false;// the red card button can click again
                t1m1R.Enabled = true;
                t1m1R.Checked = false;
                 ts1 = new TimeSpan(0, 0, 3);
            }
        }

        private void t1m2timer_Tick(object sender, EventArgs e)
        {
            Display.t1m2TimeLabel.Text = ts2.Minutes.ToString() + ":" + ts2.Seconds.ToString();
            ts2 = ts2.Subtract(new TimeSpan(0, 0, 1));
            t1m2R.Enabled = false;
            if (ts2.TotalSeconds < 0.0)
            {
                t1m2timer.Enabled = false;
                t1m2R.Enabled = true;
                t1m2R.Checked = false;
                ts2 = new TimeSpan(0, 0, 3);
            }
        }

        private void t1m3timer_Tick(object sender, EventArgs e)
        {
            Display.t1m3TimeLabel.Text = ts3.Minutes.ToString() + ":" + ts3.Seconds.ToString();
            ts3 = ts3.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t1m3R.Enabled = false;
            if (ts3.TotalSeconds < 0.0)//当倒计时完毕
            {
                t1m3timer.Enabled = false;
                t1m3R.Enabled = true;
                t1m3R.Checked = false;
                ts3 = new TimeSpan(0, 0, 3);
            }
        }

        private void t1m4timer_Tick(object sender, EventArgs e)
        {
            Display.t1m4TimeLabel.Text = ts4.Minutes.ToString() + ":" + ts4.Seconds.ToString();//label17用来显示剩余的时间
            ts4 = ts4.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t1m4R.Enabled = false;
            if (ts4.TotalSeconds < 0.0)//当倒计时完毕
            {
                t1m4timer.Enabled = false;
                t1m4R.Enabled = true;
                t1m4R.Checked = false;
                ts4 = new TimeSpan(0, 0, 3);
            }
        }

        private void t1m5timer_Tick(object sender, EventArgs e)
        {
            Display.t1m5TimeLabel.Text = ts5.Minutes.ToString() + ":" + ts5.Seconds.ToString();//label17用来显示剩余的时间
            ts5 = ts5.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t1m5R.Enabled = false;
            if (ts5.TotalSeconds < 0.0)//当倒计时完毕
            {
                t1m5timer.Enabled = false;
                t1m5R.Enabled = true;
                t1m5R.Checked = false;
                ts5 = new TimeSpan(0, 0, 3);
            }
        }

        private void t2m1timer_Tick(object sender, EventArgs e)
        {
            Display.t2m1TimeLabel.Text = ts6.Minutes.ToString() + ":" + ts6.Seconds.ToString();//label17用来显示剩余的时间
            ts6 = ts6.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t2m1R.Enabled = false;
            if (ts6.TotalSeconds < 0.0)//当倒计时完毕
            {
                t2m1timer.Enabled = false;
                t2m1R.Enabled = true;
                t2m1R.Checked = false;
                ts6 = new TimeSpan(0, 0, 3);
            }
        }

        private void t2m2timer_Tick(object sender, EventArgs e)
        {
            Display.t2m2TimeLabel.Text = ts7.Minutes.ToString() + ":" + ts7.Seconds.ToString();//label17用来显示剩余的时间
            ts7 = ts7.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t2m2R.Enabled = false;
            if (ts7.TotalSeconds < 0.0)//当倒计时完毕
            {
                t2m2timer.Enabled = false;
                t2m2R.Enabled = true;
                t2m2R.Checked = false;
                ts7 = new TimeSpan(0, 0, 3);
            }
        }

        private void t2m3timer_Tick(object sender, EventArgs e)
        {
            Display.t2m3TimeLabel.Text = ts8.Minutes.ToString() + ":" + ts8.Seconds.ToString();//label17用来显示剩余的时间
            ts8 = ts8.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t2m3R.Enabled = false;
            if (ts8.TotalSeconds < 0.0)//当倒计时完毕
            {
                t2m3timer.Enabled = false;
                t2m3R.Enabled = true;
                t2m3R.Checked = false;
                ts8 = new TimeSpan(0, 0, 3);
            }
        }

        private void t2m4timer_Tick(object sender, EventArgs e)
        {
            Display.t2m4TimeLabel.Text = ts9.Minutes.ToString() + ":" + ts9.Seconds.ToString();//label17用来显示剩余的时间
            ts9 = ts9.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t2m4R.Enabled = false;
            if (ts9.TotalSeconds < 0.0)//当倒计时完毕
            {
                t2m4timer.Enabled = false;
                t2m4R.Enabled = true;
                t2m4R.Checked = false;
                ts9 = new TimeSpan(0, 0, 3);
            }
        }

        private void t2m5timer_Tick(object sender, EventArgs e)
        {
            Display.t2m5TimeLabel.Text = ts10.Minutes.ToString() + ":" + ts10.Seconds.ToString();//label17用来显示剩余的时间
            ts10 = ts10.Subtract(new TimeSpan(0, 0, 1));//每隔一秒减去一秒
            t2m5R.Enabled = false;
            if (ts10.TotalSeconds < 0.0)//当倒计时完毕
            {
                t2m5timer.Enabled = false;
                t2m5R.Enabled = true;
                t2m5R.Checked = false;
                ts10 = new TimeSpan(0, 0, 3);
            }
            
        }

        private async void TNBox1_Validated(object sender, EventArgs e)
            // once you enter the team that in the tournament, it will auto fill the memebers' name
        {
            int counter = 0;
            Team tmpTeam = new Team();
            TextBox tmp = (TextBox)sender;
            string result = await ApiHandler.getTeams(Test.tournamentID);
            List<Team> teams = ApiHandler.jsonTo<List<Team>>(result);
            foreach (Team t in teams) {
                if (t.name.Equals(TNBox1.Text)) {
                    tmpTeam = t;// get the team we entered in the team name box
                    team1ID = t.id;
                    break;
                }
            }
            result = await ApiHandler.getPlayers(tmpTeam.id);
            List<Player> players = ApiHandler.jsonTo<List<Player>>(result);
            foreach (Control c in tmp.Parent.Controls) {//get all the members' name and auto fill it
                if (c is GroupBox) {
                    if (c.Name.Equals("Team1")) {
                        foreach (Control t in c.Controls) {
                            if (t is TextBox) {
                                t.Text = players[counter].name;
                                counter++;
                            }
                        }
                    }
                }
            }

        }
        // same with team name box 1
        private async void TNBox2_Validated(object sender, EventArgs e)
        {
            int counter = 0;
            Team tmpTeam = new Team();
            TextBox tmp = (TextBox)sender;
            string result = await ApiHandler.getTeams(Test.tournamentID);
            List<Team> teams = ApiHandler.jsonTo<List<Team>>(result);
            foreach (Team t in teams)
            {
                if (t.name.Equals(TNBox2.Text))
                {
                    tmpTeam = t;
                    team2ID = t.id;
                    break;
                }
            }
            result = await ApiHandler.getPlayers(tmpTeam.id);
            List<Player> players = ApiHandler.jsonTo<List<Player>>(result);
            foreach (Control c in tmp.Parent.Controls)
            {
                if (c is GroupBox)
                {
                    if (c.Name.Equals("Team2"))
                    {
                        foreach (Control t in c.Controls)
                        {
                            if (t is TextBox)
                            {
                                t.Text = players[counter].name;
                                counter++;
                            }
                        }
                    }
                }
            }

        }
    }
    
		
	
}
