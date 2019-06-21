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
    public partial class ScoreBoard : Form
    {
        public List<String> teamList = new List<String>();
        public List<List<string>> matchList = new List<List<string>>();
        public ScoreBoard()
        {
            InitializeComponent();
        }

        private void board_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)// creat the match schedule
        {
            teamList.Clear();
            matchList.Clear();
            matchLabel.Text = "No Match";
            String matchmessage = "";
            foreach (DataGridViewRow G in board.Rows)// all temas in the data grid view
            {   
                if (!G.Cells[1].Equals(""))
                {
                    teamList.Add(Convert.ToString(G.Cells[1].Value));//add all teams to the list
                }
                
            }
            if (teamList.Count == 5)// if only have 5 teams
            {
                matchList.Add(new List<String> { teamList[0], teamList[1] });// add the match to a list
                matchList.Add(new List<String> { teamList[0], teamList[2] });
                matchList.Add(new List<String> { teamList[0], teamList[3] });
                matchList.Add(new List<String> { teamList[0], teamList[4] });
                matchList.Add(new List<String> { teamList[1], teamList[2] });
                matchList.Add(new List<String> { teamList[1], teamList[3] });
                matchList.Add(new List<String> { teamList[1], teamList[4] });
                matchList.Add(new List<String> { teamList[2], teamList[3] });
                matchList.Add(new List<String> { teamList[2], teamList[4] });
                matchList.Add(new List<String> { teamList[3], Convert.ToString(teamList[4])});
                foreach(List<String> match in matchList)// print all the match 
                {
                    matchmessage += match[0] + " VS " + match[1] + "\n";
                }
                matchLabel.Text = matchmessage;
            }
            else if(teamList.Count == 6)// if all six teams
            {
                matchList.Add(new List<String> { Convert.ToString(teamList[0]), Convert.ToString(teamList[1])});
                matchList.Add(new List<String> { Convert.ToString(teamList[0]), Convert.ToString(teamList[2])});
                matchList.Add(new List<String> { Convert.ToString(teamList[0]), Convert.ToString(teamList[3])});
                matchList.Add(new List<String> { Convert.ToString(teamList[0]), Convert.ToString(teamList[4])});
                matchList.Add(new List<String> { Convert.ToString(teamList[0]), Convert.ToString(teamList[5])});
                matchList.Add(new List<String> { Convert.ToString(teamList[1]), Convert.ToString(teamList[2])});
                matchList.Add(new List<String> { Convert.ToString(teamList[1]), Convert.ToString(teamList[3])});
                matchList.Add(new List<String> { Convert.ToString(teamList[1]), Convert.ToString(teamList[4])});
                matchList.Add(new List<String> { Convert.ToString(teamList[1]), Convert.ToString(teamList[5])});
                matchList.Add(new List<String> { Convert.ToString(teamList[2]), Convert.ToString(teamList[3])});
                matchList.Add(new List<String> { Convert.ToString(teamList[2]), Convert.ToString(teamList[4])});
                matchList.Add(new List<String> { Convert.ToString(teamList[2]), Convert.ToString(teamList[5])});
                matchList.Add(new List<String> { Convert.ToString(teamList[3]), Convert.ToString(teamList[4])});
                matchList.Add(new List<String> { Convert.ToString(teamList[3]), Convert.ToString(teamList[5])});
                matchList.Add(new List<String> { Convert.ToString(teamList[4]), Convert.ToString(teamList[5])});
                foreach (List<String> match in matchList)
                {
                    matchmessage += match[0] + " VS " + match[1] + "\n";
                }
                matchLabel.Text = matchmessage;
            }
            else
            {
                foreach (List<String> match in matchList)
                {
                    matchmessage += match[0] + " VS " + match[1] + "\n";
                }
                matchLabel.Text = matchmessage;
            }

        }
    }
}
