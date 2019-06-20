namespace Assignment3
{
    partial class ScoreBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.board = new System.Windows.Forms.DataGridView();
            this.Rank = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Team = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Wins = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Losses = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ties = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Score = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Member5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.board)).BeginInit();
            this.SuspendLayout();
            // 
            // board
            // 
            this.board.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.board.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Rank,
            this.Team,
            this.Wins,
            this.Losses,
            this.Ties,
            this.Score,
            this.TP,
            this.Member1,
            this.Member2,
            this.Member3,
            this.Member4,
            this.Member5});
            this.board.Location = new System.Drawing.Point(0, 0);
            this.board.Name = "board";
            this.board.Size = new System.Drawing.Size(744, 231);
            this.board.TabIndex = 0;
            this.board.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.board_RowsAdded);
            // 
            // Rank
            // 
            this.Rank.HeaderText = "Rank";
            this.Rank.Name = "Rank";
            // 
            // Team
            // 
            this.Team.HeaderText = "Team";
            this.Team.Name = "Team";
            // 
            // Wins
            // 
            this.Wins.HeaderText = "Wins";
            this.Wins.Name = "Wins";
            // 
            // Losses
            // 
            this.Losses.HeaderText = "Losses";
            this.Losses.Name = "Losses";
            // 
            // Ties
            // 
            this.Ties.HeaderText = "Ties";
            this.Ties.Name = "Ties";
            // 
            // Score
            // 
            this.Score.HeaderText = "Score";
            this.Score.Name = "Score";
            // 
            // TP
            // 
            this.TP.HeaderText = "TP";
            this.TP.Name = "TP";
            // 
            // Member1
            // 
            this.Member1.HeaderText = "Member1";
            this.Member1.Name = "Member1";
            this.Member1.Visible = false;
            // 
            // Member2
            // 
            this.Member2.HeaderText = "Member2";
            this.Member2.Name = "Member2";
            this.Member2.Visible = false;
            // 
            // Member3
            // 
            this.Member3.HeaderText = "Member3";
            this.Member3.Name = "Member3";
            this.Member3.Visible = false;
            // 
            // Member4
            // 
            this.Member4.HeaderText = "Member4";
            this.Member4.Name = "Member4";
            this.Member4.Visible = false;
            // 
            // Member5
            // 
            this.Member5.HeaderText = "Member5";
            this.Member5.Name = "Member5";
            this.Member5.Visible = false;
            // 
            // matchLabel
            // 
            this.matchLabel.AutoSize = true;
            this.matchLabel.Location = new System.Drawing.Point(241, 267);
            this.matchLabel.Name = "matchLabel";
            this.matchLabel.Size = new System.Drawing.Size(76, 13);
            this.matchLabel.TabIndex = 1;
            this.matchLabel.Text = "No MatchNow";
            // 
            // ScoreBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 450);
            this.Controls.Add(this.matchLabel);
            this.Controls.Add(this.board);
            this.Name = "ScoreBoard";
            this.Text = "ScoreBoard";
            ((System.ComponentModel.ISupportInitialize)(this.board)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView board;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rank;
        private System.Windows.Forms.DataGridViewTextBoxColumn Team;
        private System.Windows.Forms.DataGridViewTextBoxColumn Wins;
        private System.Windows.Forms.DataGridViewTextBoxColumn Losses;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Score;
        private System.Windows.Forms.DataGridViewTextBoxColumn TP;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Member5;
        private System.Windows.Forms.Label matchLabel;
    }
}