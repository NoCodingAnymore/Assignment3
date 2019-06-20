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
    
    public partial class TournamentSetting : Form
    {
        public string tournamentID { get; set; }
        private string teamID;
        public TournamentSetting()
        {
            InitializeComponent();
            
        }

        private async void btnTournament_Click(object sender, EventArgs e)
        {
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

        private async void btnTeam1_Click(object sender, EventArgs e)
        {
            Button tmpBtn = (Button)sender;
            if (string.IsNullOrWhiteSpace(txtTournament.Text))
            {
                MessageBox.Show("Please name a tournament before you add/update it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            foreach (Control g in tmpBtn.Parent.Controls) {
                if (g is GroupBox) {
                    foreach (Control c in g.Controls) {
                        if (c is TextBox)
                        {
                            if (String.IsNullOrWhiteSpace(c.Text))
                            {
                                MessageBox.Show("Please name a team or fill in names of all members.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                break;
                            }
                            else
                            {
                                if (c.Tag.Equals("1"))
                                {
                                    
                                    Team team = new Team(c.Text);
                                    string result = await ApiHandler.addTeam(tournamentID, team);
                                    team = ApiHandler.jsonTo<Team>(result);
                                    teamID = team.id;
                                }
                                else
                                {
                                    Player player = new Player(c.Text);
                                    await ApiHandler.addPlayer(teamID, player);
                                }
                            
                            }
                        }
                    }
                }
            }
            
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string result = await ApiHandler.getPlayers("3022");
            List<Player> players = ApiHandler.jsonTo<List<Player>>(result);

            Console.WriteLine(players.Count());
            
        }
    }
}
