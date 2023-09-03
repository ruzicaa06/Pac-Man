using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Pac_Man
{
    public partial class Game : Form
    {
        bool goUp, goDown, goLeft, goRight;
        bool isGameOver;
        int score;
        int pacmanSpeed;
        int greenGhostSpeed, pinkGhostSpeed, blueGhostSpeed, pinkGhostSpeed2, greenGhostSpeed2;

        private void pictureBox19_Click(object sender, EventArgs e)
        {

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            lblScore.Text = "Score: " + score;
            if (goLeft == true)
            {
                pacman.Left -= pacmanSpeed;
                pacman.Image = Properties.Resources.pacmanLeft;
            }
            if (goRight == true)
            {
                pacman.Left += pacmanSpeed;
                pacman.Image = Properties.Resources.pacmanRight;
            }
            if (goDown == true)
            {
                pacman.Top += pacmanSpeed;
                pacman.Image = Properties.Resources.pacmanDown;
            }
            if (goUp == true)
            {
                pacman.Top -= pacmanSpeed;
                pacman.Image = Properties.Resources.pacmanUp;
            }

            if (pacman.Left < -1)
            {
                pacman.Left = 1420;

            }
            if (pacman.Left > 1420)
            {
                pacman.Left = -1;

            }

            if (score == 313)
            {
                gameTimer.Stop();
                lblGameOver.Visible = true;
                lblGameOver.Text = "You WON!!";
            }

            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "coin" && x.Visible == true)
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        score += 1;
                        x.Visible = false;
                    }

                }

                if ((string)x.Tag == "obstacle")
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        if (goLeft == true)
                        {
                            pacman.Left += pacmanSpeed;
                        }
                        if (goRight == true)
                        {
                            pacman.Left -= pacmanSpeed;
                        }
                        if (goDown == true)
                        {
                            pacman.Top -= pacmanSpeed;
                        }
                        if (goUp == true)
                        {
                            pacman.Top += pacmanSpeed;
                        }
                    }
                }

                if ((string)x.Tag == "ghost")
                {
                    if (pacman.Bounds.IntersectsWith(x.Bounds))
                    {
                        gameTimer.Stop();
                        lblGameOver.Visible = true;
                        lblGameOver.Text = "Game OVER";


                    }
                }

            }

            pinkGhost.Top += pinkGhostSpeed;
            greenGhost.Left += greenGhostSpeed;
            blueGhost.Left += blueGhostSpeed;
            greenGhost2.Top += greenGhostSpeed2;
            pinkGhost2.Left += pinkGhostSpeed2;


            foreach (Control x in this.Controls)
            {
                if ((string)x.Tag == "obstacle")
                {
                    if (pinkGhost.Bounds.IntersectsWith(x.Bounds))
                    {
                        pinkGhostSpeed = -pinkGhostSpeed;
                    }
                    if (blueGhost.Bounds.IntersectsWith(x.Bounds))
                    {
                        blueGhostSpeed = -blueGhostSpeed;
                    }
                    if (greenGhost.Bounds.IntersectsWith(x.Bounds))
                    {
                        greenGhostSpeed = -greenGhostSpeed;
                    }
                    if (greenGhost2.Bounds.IntersectsWith(x.Bounds))
                    {
                        greenGhostSpeed2 = -greenGhostSpeed2;
                    }
                    if (pinkGhost2.Bounds.IntersectsWith(x.Bounds))
                    {
                        pinkGhostSpeed2 = -pinkGhostSpeed2;
                    }
                }
            }
        }
       

        private void Game_Load(object sender, EventArgs e)
        {

        }

        public Game()
        {
            InitializeComponent();
            resetGame();
        }

       

        private void keyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = false;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = false;
            }
            if (isGameOver == true)
            {
                resetGame();
            }
        }

        private void keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                goUp = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                goDown = true;
            }
            if (e.KeyCode == Keys.Left)
            {
                goLeft = true;
            }
            if (e.KeyCode == Keys.Right)
            {
                goRight = true;
            }
        }

        private void resetGame()
        {
            isGameOver = false;
            score = 0;

            pinkGhostSpeed = 4;
            blueGhostSpeed = 4;
            greenGhostSpeed = 4;
            pinkGhostSpeed2 = 4;
            greenGhostSpeed2 = 4;
            pacmanSpeed = 8;


            foreach (Control x in this.Controls)
            {
                if (x is PictureBox)
                {
                    x.Visible = true;
                }
            }
            gameTimer.Start();

        }
    }
}
