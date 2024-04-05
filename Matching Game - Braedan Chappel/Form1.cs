using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;

namespace Matching_Game___Braedan_Chappel
{
    public partial class Form1 : Form {
        //Braedan Chappel -  Dec 13th 2021

        Label click1 = null;
        bool go = false;
        bool win = false;
        Label click2 = null;
        int countDown = 5;
        int gameTime = 60;
        int pairs = 8;
        int matchs = 0;
        int moves = 0;

        Random random = new Random();
        Random random2 = new Random();
        SoundPlayer MatchSound = new SoundPlayer(Properties.Resources.Match);
        SoundPlayer NoMatchSound = new SoundPlayer(Properties.Resources.NoMatch);


        List<string> icons = new List<string>() //creates a new list of a string data type -- stores text instead of intergers or Images
        {
           "Y", "Y", "N", "N", ",", ",", "k", "k",
           "b", "b", "K", "K", "w", "w", "L", "L"

        };


        public Form1()
        {
            InitializeComponent();
            //set some initial text
            lblCountdown.Text = "";
            lblMatches.Text = "";
            lblMoveCounter.Text = "";
        }

        private void AssignIconsToSquares()
        {
            // The TableLayoutPanel has 16 labels, and the list has 16 items, so an icon is pulled at random from the list and added to each label

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    int randomNumber = random.Next(icons.Count);
                    iconLabel.Text = icons[randomNumber];

                    //System.Threading.Thread.Sleep(500);

                    timer2.Start();

                    icons.RemoveAt(randomNumber);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

            if (go == true) // if go is true then the game is in a playable state
            {
                if (timer1.Enabled == true)
                    return;


                Label clickedLabel = sender as Label;

                if (clickedLabel != null)
                {
                    // If the clicked label is black, the player clicked

                    if (clickedLabel.ForeColor == Color.Black)
                        return;


                    if (click1 == null)
                    {
                        click1 = clickedLabel;
                        click1.ForeColor = Color.Black;

                        return;
                    }

                    click2 = clickedLabel;
                    click2.ForeColor = Color.Black;

                    if (timer2.Enabled == false)
                    {
                        CheckWin();
                    }


                    if (click1.Text == click2.Text)
                    {

                        click1 = null;

                        click2 = null;

                        matchs = matchs += 1;

                        lblMatches.Text = matchs + "/8 Matches Found";
                        MatchSound.Play();
                        return;
                    }

                    moves = moves += 1;

                    lblMoveCounter.Text = moves + " : Incorrect Pairs Selected";
                    NoMatchSound.Play();

                    timer1.Start();

                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Stop the timer
            timer1.Stop();

            // Hide both icons
            click1.ForeColor = click1.BackColor;
            click2.ForeColor = click2.BackColor;

            click1 = null;

            click2 = null;
        }

        private void CheckWin()
        {
            // Go through all of the labels in the TableLayoutPanel, checking each one to see if its icon is matched
            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;

                if (iconLabel != null)
                {
                    if (iconLabel.ForeColor == iconLabel.BackColor)
                    {
                        win = true;



                        return; // If the loop didn’t return it did not find any icons that were unmatched
                    }
                }
            }

            lblWin.Text = "YOU MATCHED ALL 8 PAIRS! IN " + gameTime + " SECONDS!";
            lblWin.Visible = true;

        }

        private void btnScramble_Click(object sender, EventArgs e)
        {
            AssignIconsToSquares();

            btnScramble.Enabled = false;

            lblCountdown.Visible = true;

            gameTimer.Start();

            win = true;

        }

        private void timer2_Tick(object sender, EventArgs e)
        {

            foreach (Control control in tableLayoutPanel1.Controls)
            {
                Label iconLabel = control as Label;
                if (iconLabel != null)
                {
                    iconLabel.ForeColor = iconLabel.BackColor;
                    timer2.Stop();
                    go = true;

                    this.Refresh();
                }

            }

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

            countDown = countDown - 1;
            lblCountdown.Text = countDown + " Seconds To Get Ready!!";



            if (countDown == -1)
            {
                lblCountdown.Visible = false;
            }


            if (go == true)
            {
                lblTimer.Visible = true;
                gameTime = gameTime - 1;
                lblTimer.Text = gameTime + " Seconds To Fully Solve";
            }

            if (gameTime == 0)
            {

                lblLose.Visible = true;
                lblTimer.Visible = false;
                lblLose.Text = "YOU FAILED TO MATCH ALL 8 PAIRS";
                gameTimer.Stop();
                go = false;

            }

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnNumbers_Click(object sender, EventArgs e)
        {
            label1.Font = new Font("Arial", 28);
            label2.Font = new Font("Arial", 28);
            label3.Font = new Font("Arial", 28);
            label4.Font = new Font("Arial", 28);
            label5.Font = new Font("Arial", 28);
            label6.Font = new Font("Arial", 28);
            label7.Font = new Font("Arial", 28);
            label8.Font = new Font("Arial", 28);
            label9.Font = new Font("Arial", 28);
            label10.Font = new Font("Arial", 28);
            label11.Font = new Font("Arial", 28);
            label12.Font = new Font("Arial", 28);
            label13.Font = new Font("Arial", 28);
            label14.Font = new Font("Arial", 28);
            label15.Font = new Font("Arial", 28);
            label16.Font = new Font("Arial", 28);

            btnNumbers.Location = new Point(50000, 500);
            btnUseIcons.Visible = true;


        }

        private void btnUseIcons_Click(object sender, EventArgs e)
        {
            label1.Font = new Font("Webdings", 60);
            label2.Font = new Font("Webdings", 60);
            label3.Font = new Font("Webdings", 60);
            label4.Font = new Font("Webdings", 60);
            label5.Font = new Font("Webdings", 60);
            label6.Font = new Font("Webdings", 60);
            label7.Font = new Font("Webdings", 60);
            label8.Font = new Font("Webdings", 60);
            label9.Font = new Font("Webdings", 60);
            label10.Font = new Font("Webdings", 60);
            label11.Font = new Font("Webdings", 60);
            label12.Font = new Font("Webdings", 60);
            label13.Font = new Font("Webdings", 60);
            label14.Font = new Font("Webdings", 60);
            label15.Font = new Font("Webdings", 60);
            label16.Font = new Font("Webdings", 60);

            btnNumbers.Location = new Point(482, 93);
            btnUseIcons.Visible = false;
        }

        private void btnStartOver_Click(object sender, EventArgs e)
        {
            //AssignIconsToSquares();

            Application.Restart();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}

