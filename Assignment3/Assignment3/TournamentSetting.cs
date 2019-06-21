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
    
    public partial class TournamentSettings : Form
    {
        public string tournamentID;
        private string teamID;
        public int teamCount;
        public ScoreBoard table = new ScoreBoard();
        public TournamentSettings()
        {
            InitializeComponent();
            
        }

        private async void btnTournament_Click(object sender, EventArgs e)// create a web tournament first to store all the team and members
        {
            Button tmp = (Button)sender;
            tmp.Enabled = false;// unless you create a tournament, or you are not allow to submit the team and members
            if (String.IsNullOrWhiteSpace(txtTournament.Text))
            {
                MessageBox.Show("Please name a tournament before you add/update it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                Tournament tournament = new Tournament(txtTournament.Text);
                string result = await ApiHandler.addTournament(tournament);
                tournament = ApiHandler.jsonTo<Tournament>(result);
                tournamentID = tournament.id;
            }
            
        }

        private async void btnTeam1_Click(object sender, EventArgs e)// send members and teams to web database
        {
            Button tmpBtn = (Button)sender;
            tmpBtn.Enabled = false;
            if (string.IsNullOrWhiteSpace(txtTournament.Text) || btnTournament.Enabled == true)
            {
                MessageBox.Show("Please name a tournament before you add/update it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tmpBtn.Enabled = true;
            }
            foreach (Control g in tmpBtn.Parent.Controls)// for loop to look all datas
            {
                if (g is GroupBox)
                {
                    int columnCount = 0;
                    DataGridViewRowCollection rows = table.board.Rows;
                    teamCount = Convert.ToInt32(table.board.RowCount) + 1;
                    object[] contains = new object[12];
                    contains[columnCount] = Convert.ToString(teamCount );
                    columnCount++;
                    foreach (Control c in g.Controls)// add all the details to the database and the datagridview in score board
                    {
                        if (c is TextBox)
                        {
                            if (String.IsNullOrWhiteSpace(c.Text))
                            {
                                MessageBox.Show("Please name a team or fill in names of all members.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                tmpBtn.Enabled = true;
                                break;
                            }
                            else
                            {
                                                                                       
                                if (c.Tag.Equals("1"))// if is team name
                                {                                
                                    Team team = new Team(c.Text);
                                    contains[columnCount] = team.name;//add team name to scoreboard
                                    columnCount++;
                                    for(int i = 0; i < 5; i++)// all records set to 0
                                    {
                                        contains[columnCount] = 0;
                                        columnCount++;
                                    }
                                    string result = await ApiHandler.addTeam(tournamentID, team);
                                    team = ApiHandler.jsonTo<Team>(result);
                                    
                                    teamID = team.id;
                                }
                                else
                                {
                                    Player player = new Player(c.Text);// add all players
                                    contains[columnCount] = player.name;
                                    await ApiHandler.addPlayer(teamID, player);
                                }

                            }
                        }
                    }
                    rows.Add(contains);//add to the datagridview
                    
                }
            }
            tmpBtn.Enabled = true;
            btnTournament.Enabled = true;
            table.Show();// show the score board with teams you have
        }

        
    }
}
