using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace birdgame
{
    public partial class Form : System.Windows.Forms.Form
    {
        int pipeSpeed = 8; 
        int gravity = 15; 
        int score = 0; 
        
        public Form()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
           
            flappyBird.Top += gravity; 
            pipeBottom.Left -= pipeSpeed;

            pipeTop.Left -= pipeSpeed; 

            scoreText.Text = "Score: " + score; 

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 800;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 950;
                score++;
            }


            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds) || flappyBird.Top < -25
                )
            {
                endGame();
                score = 0;
            }


            if (score > 5)
            {
                pipeSpeed = 15;
            }


        }
         

        private void gamekeyisdown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Space)
            {
                
                gravity = -15;
            }

        }

        private void endGame()
        {
            gameTimer.Stop(); 
            scoreText.Text += " Game over!!! Press 'R' to Restart ";

            

        }

        private void gamekeyisup(object sender, KeyEventArgs e)
        {
            if ( !gameTimer.Enabled && e.KeyCode == Keys.R)
            {
                resetGame();
            }

            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        public void resetGame()
        {
            

            flappyBird.Top = 49 ;
            
            pipeBottom.Left = 800 ;

            pipeTop.Left = 750;

            gameTimer.Start();

            
        }



    }
}
