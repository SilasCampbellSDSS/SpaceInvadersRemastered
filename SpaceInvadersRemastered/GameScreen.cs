using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace SpaceInvadersRemastered
{
    public partial class GameScreen: UserControl
    {
        //Global Variables

        Player player = new Player();
        Aliens alien = new Aliens();
        
        //MagicBus mothership = new MagicBus();
        //List<Aliens> alienRow1 = new List<Aliens>();
        //List<Aliens> alienRow2 = new List<Aliens>();
        //List<Aliens> alienRow3 = new List<Aliens>();
        //List<Aliens> alienRow4 = new List<Aliens>();

        public static int screenWidth;
        public static int screenHeight;

        
        Rectangle mothership = new Rectangle(-40, -50, 40, 20);

        Rectangle bunker1 = new Rectangle(50, 430, 80, 20);
        Rectangle bunker2 = new Rectangle(250, 430, 80, 20);
        Rectangle bunker3 = new Rectangle(450, 430, 80, 20);
        Rectangle bunker4 = new Rectangle(650, 430, 80, 20);

        Rectangle bunker1Leg1 = new Rectangle(50, 430, 20, 40);
        Rectangle bunker2Leg1 = new Rectangle(250, 430, 20, 40);
        Rectangle bunker3Leg1 = new Rectangle(450, 430, 20, 40);
        Rectangle bunker4Leg1 = new Rectangle(650, 430, 20, 40);

        Rectangle bunker1Leg2 = new Rectangle(110, 430, 20, 40);
        Rectangle bunker2Leg2 = new Rectangle(310, 430, 20, 40);
        Rectangle bunker3Leg2 = new Rectangle(510, 430, 20, 40);
        Rectangle bunker4Leg2 = new Rectangle(710, 430, 20, 40);

        //Gameplay variable
        
        public int mothershipSpeed = 2;
        
        

        //Bunker health
        public int bunker1Health = 16;
        public int bunker2Health = 16;
        public int bunker3Health = 16;
        public int bunker4Health = 16;
        public int bunker1Leg1Health = 12;
        public int bunker1Leg2Health = 12;
        public int bunker2Leg1Health = 12;
        public int bunker2Leg2Health = 12;
        public int bunker3Leg1Health = 12;
        public int bunker3Leg2Health = 12;
        public int bunker4Leg1Health = 12;
        public int bunker4Leg2Health = 12;

        //Key press variables
        bool leftPressed, rightPressed, spacePressed;

      
       

        //Random generators and their variables
        Random mothershipGenerate = new Random();
        Random mothershipValue = new Random();
        

        public int mothershipGenerated, mothershipPoints;

        Rectangle bullet = new Rectangle(-10, -10, 5, 15);

        //Brushes
        SolidBrush greenBrush = new SolidBrush(Color.LawnGreen);
        SolidBrush redBrush = new SolidBrush(Color.Red);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        SolidBrush bunker1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker1Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker1Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker2Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker2Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker2Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker3Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker3Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker3Leg2Brush = new SolidBrush(Color.LawnGreen);

        SolidBrush bunker4Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker4Leg1Brush = new SolidBrush(Color.LawnGreen);
        SolidBrush bunker4Leg2Brush = new SolidBrush(Color.LawnGreen);


        public GameScreen()
        {
            InitializeComponent();
            screenWidth = this.Width;
            screenHeight = this.Height;
        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = false;
                    break;
                case Keys.Right:
                    rightPressed = false;
                    break;
                case Keys.Space:
                    spacePressed = false;
                    break;
            }
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftPressed = true;
                    break;
                case Keys.Right:
                    rightPressed = true;
                    break;
                case Keys.Space:
                    spacePressed = true;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            scoreNumber.Text = $"{player.playerScore}";
            livesNumber.Text = $"{Aliens.playerLives}";

            if (rightPressed == true)
            {
                player.PlayerMove("right");
            }

            if (leftPressed == true)
            {
                player.PlayerMove("left");
            }

            if (spacePressed == true)
            {
                player.PlayerAttack("attack");
            }

            alienMovement();

            alienAttacks();

            alienInterception();

            magicBus();

            bunker1Method();

            bunker2Method();

            bunker3Method();

            bunker4Method();

            Refresh();
        }

        public void alienMovement()
        {
            
        }

        public void alienAttacks()
        {
            //Random variable to make aliens occasionly fire
            

            

            //If alien bullets hit the player reduce players #of lifes
            //if (alienBullet.IntersectsWith(player) || alienBullet.IntersectsWith(playerCannon))
            {
                if (Aliens.playerLives == 0)
                {
                    livesNumber.Text = "0";
                    Death();
                }
            }
        }

        

        public void magicBus()
        {
            //Generating a random value to see if it should spawn a mothership
            mothershipGenerated = mothershipGenerate.Next(1, 2001);

            //Moving the mothership into position
            if (mothershipGenerated == 1 && mothership.Y < 0)
            {
                mothershipPoints = mothershipValue.Next(1, 5);
                mothership = new Rectangle(-40, 50, 40, 20);
            }

            //Assigning points and moving it off screen if you hit it
            if (mothership.IntersectsWith(bullet) && mothershipPoints == 1)
            {
                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 2)
            {
                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 3)
            {
                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            if (mothership.IntersectsWith(bullet) && mothershipPoints == 4)
            {
                playerScore = playerScore + 200;
                mothership.Y = -50;
            }

            //Moving it off screen after it crosses the boundary
            if (mothership.X > 800)
            {
                mothership.Y = -50;
            }

            //Moving the mothership
            mothership.X = mothership.X + mothershipSpeed;
        }

        public void bunker1Method()
        {
            //Intersecting with bunker1
            if (bullet.IntersectsWith(bunker1) && bunker1Health > 0 || alienBullet.IntersectsWith(bunker1) && bunker1Health > 0)
            {
                bunker1Health--;

                if (bullet.IntersectsWith(bunker1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Health <= 5)
                {
                    bunker1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker1's first leg
            if (bullet.IntersectsWith(bunker1Leg1) && bunker1Leg1Health > 0 || alienBullet.IntersectsWith(bunker1Leg1) && bunker1Leg1Health > 0)
            {
                bunker1Leg1Health--;

                if (bullet.IntersectsWith(bunker1Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Leg1Health <= 5)
                {
                    bunker1Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker1's second leg
            if (bullet.IntersectsWith(bunker1Leg2) && bunker1Leg2Health > 0 || alienBullet.IntersectsWith(bunker1Leg2) && bunker1Leg2Health > 0)
            {
                bunker1Leg2Health--;

                if (bullet.IntersectsWith(bunker1Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker1Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker1Leg2Health <= 5)
                {
                    bunker1Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker1
            if (bunker1Health == 0)
            {
                bunker1Brush.Color = Color.Black;
            }

            //"Removing" bunker1's first leg
            if (bunker1Leg1Health == 0)
            {
                bunker1Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker1's second leg
            if (bunker1Leg2Health == 0)
            {
                bunker1Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker2Method()
        {
            //Intersecting with bunker2
            if (bullet.IntersectsWith(bunker2) && bunker2Health > 0 || alienBullet.IntersectsWith(bunker2) && bunker2Health > 0)
            {
                bunker2Health--;

                if (bullet.IntersectsWith(bunker2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Health <= 5)
                {
                    bunker2Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker2's first leg
            if (bullet.IntersectsWith(bunker2Leg1) && bunker2Leg1Health > 0 || alienBullet.IntersectsWith(bunker2Leg1) && bunker2Leg1Health > 0)
            {
                bunker2Leg1Health--;

                if (bullet.IntersectsWith(bunker2Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Leg1Health <= 5)
                {
                    bunker2Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker2's second leg
            if (bullet.IntersectsWith(bunker2Leg2) && bunker2Leg2Health > 0 || alienBullet.IntersectsWith(bunker2Leg2) && bunker2Leg2Health > 0)
            {
                bunker2Leg2Health--;

                if (bullet.IntersectsWith(bunker2Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker2Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker2Leg2Health <= 5)
                {
                    bunker2Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker2
            if (bunker2Health == 0)
            {
                bunker2Brush.Color = Color.Black;
            }

            //"Removing" bunker2's first leg
            if (bunker2Leg1Health == 0)
            {
                bunker2Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker2's second leg
            if (bunker2Leg2Health == 0)
            {
                bunker2Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker3Method()
        {
            //Intersecting with bunker3
            if (bullet.IntersectsWith(bunker3) && bunker3Health > 0 || alienBullet.IntersectsWith(bunker3) && bunker3Health > 0)
            {
                bunker3Health--;

                if (bullet.IntersectsWith(bunker3))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Health <= 5)
                {
                    bunker3Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker3's first leg
            if (bullet.IntersectsWith(bunker3Leg1) && bunker3Leg1Health > 0 || alienBullet.IntersectsWith(bunker3Leg1) && bunker3Leg1Health > 0)
            {
                bunker3Leg1Health--;

                if (bullet.IntersectsWith(bunker3Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Leg1Health <= 5)
                {
                    bunker3Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker3's second leg
            if (bullet.IntersectsWith(bunker3Leg2) && bunker3Leg2Health > 0 || alienBullet.IntersectsWith(bunker3Leg2) && bunker3Leg2Health > 0)
            {
                bunker3Leg2Health--;

                if (bullet.IntersectsWith(bunker3Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker3Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker3Leg2Health <= 5)
                {
                    bunker3Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker3
            if (bunker3Health == 0)
            {
                bunker3Brush.Color = Color.Black;
            }

            //"Removing" bunker3's first leg
            if (bunker3Leg1Health == 0)
            {
                bunker3Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker3's second leg
            if (bunker3Leg2Health == 0)
            {
                bunker3Leg2Brush.Color = Color.Black;
            }
        }

        public void bunker4Method()
        {
            //Intersecting with bunker4
            if (bullet.IntersectsWith(bunker4) && bunker4Health > 0 || alienBullet.IntersectsWith(bunker4) && bunker4Health > 0)
            {
                bunker4Health--;

                if (bullet.IntersectsWith(bunker4))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Health <= 5)
                {
                    bunker4Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker4's first leg
            if (bullet.IntersectsWith(bunker4Leg1) && bunker4Leg1Health > 0 || alienBullet.IntersectsWith(bunker4Leg1) && bunker4Leg1Health > 0)
            {
                bunker4Leg1Health--;

                if (bullet.IntersectsWith(bunker4Leg1))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4Leg1))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Leg1Health <= 5)
                {
                    bunker4Leg1Brush.Color = Color.Red;
                }
            }

            //Intersecting with bunker4's second leg
            if (bullet.IntersectsWith(bunker4Leg2) && bunker4Leg2Health > 0 || alienBullet.IntersectsWith(bunker4Leg2) && bunker4Leg2Health > 0)
            {
                bunker4Leg2Health--;

                if (bullet.IntersectsWith(bunker4Leg2))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                }

                if (alienBullet.IntersectsWith(bunker4Leg2))
                {
                    alienBullet.X = 1000;
                    alienBullet.Y = 1000;
                }

                if (bunker4Leg2Health <= 5)
                {
                    bunker4Leg2Brush.Color = Color.Red;
                }
            }

            //"Removing" bunker4
            if (bunker4Health == 0)
            {
                bunker4Brush.Color = Color.Black;
            }

            //"Removing" bunker4's first leg
            if (bunker4Leg1Health == 0)
            {
                bunker4Leg1Brush.Color = Color.Black;
            }

            //"Removing" bunker4's second leg
            if (bunker4Leg2Health == 0)
            {
                bunker4Leg2Brush.Color = Color.Black;
            }
        }

        public void InitializeGame()
        {
            //Setting variables to original
            playerScore = 0;
            playerLives = 3;


            bunker1Health = 16;
            bunker1Leg1Health = 12;
            bunker1Leg2Health = 12;

            bunker2Health = 16;
            bunker2Leg1Health = 12;
            bunker2Leg2Health = 12;

            bunker3Health = 16;
            bunker3Leg1Health = 12;
            bunker3Leg2Health = 12;

            bunker4Health = 16;
            bunker4Leg1Health = 12;
            bunker4Leg2Health = 12;

            bunker1Brush.Color = Color.LawnGreen;
            bunker1Leg1Brush.Color = Color.LawnGreen;
            bunker1Leg2Brush.Color = Color.LawnGreen;

            bunker2Brush.Color = Color.LawnGreen;
            bunker2Leg1Brush.Color = Color.LawnGreen;
            bunker2Leg2Brush.Color = Color.LawnGreen;

            bunker3Brush.Color = Color.LawnGreen;
            bunker3Leg1Brush.Color = Color.LawnGreen;
            bunker3Leg2Brush.Color = Color.LawnGreen;

            bunker4Brush.Color = Color.LawnGreen;
            bunker4Leg1Brush.Color = Color.LawnGreen;
            bunker4Leg2Brush.Color = Color.LawnGreen;

            alienRow1.Clear();
            alienRow2.Clear();
            alienRow3.Clear();
            alienRow4.Clear();

            //Adding aliens to the screen
            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 50, 20, 20);
                alienRow1.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 90, 20, 20);
                alienRow2.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 130, 20, 20);
                alienRow3.Add(alien);
            }

            for (int i = 0; i < 12; i++)
            {
                Rectangle alien = new Rectangle(10 + i * 40, 170, 20, 20);
                alienRow4.Add(alien);
            }

        }

        public void Death()
        {
            //gameTimer.Stop();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            if (gameTimer.Enabled == true)
            {
                //Making all of the bunkers
                e.Graphics.FillRectangle(greenBrush, Player.playerX, Player.playerY, Player.width, Player.height);
                e.Graphics.FillRectangle(greenBrush, Player.playerX + 15, Player.playerY - 10, Player.cannonWidth, Player.cannonHeight);
                e.Graphics.FillRectangle(redBrush, mothership);

                e.Graphics.FillRectangle(bunker1Brush, bunker1);
                e.Graphics.FillRectangle(bunker2Brush, bunker2);
                e.Graphics.FillRectangle(bunker3Brush, bunker3);
                e.Graphics.FillRectangle(bunker4Brush, bunker4);

                e.Graphics.FillRectangle(bunker1Leg1Brush, bunker1Leg1);
                e.Graphics.FillRectangle(bunker2Leg1Brush, bunker2Leg1);
                e.Graphics.FillRectangle(bunker3Leg1Brush, bunker3Leg1);
                e.Graphics.FillRectangle(bunker4Leg1Brush, bunker4Leg1);

                e.Graphics.FillRectangle(bunker1Leg2Brush, bunker1Leg2);
                e.Graphics.FillRectangle(bunker2Leg2Brush, bunker2Leg2);
                e.Graphics.FillRectangle(bunker3Leg2Brush, bunker3Leg2);
                e.Graphics.FillRectangle(bunker4Leg2Brush, bunker4Leg2);

                e.Graphics.FillRectangle(whiteBrush, bullet);
                e.Graphics.FillRectangle(whiteBrush, Aliens.alienBulletX, Aliens.alienBulletY, Aliens.alienBulletWidth, Aliens.alienBulletHeight);

                //Drawing alien row 1
                for (int i = 0; i < alien.alienRow1.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow1[i]);
                }

                //Drawing alien row 2
                for (int i = 0; i < alienRow2.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow2[i]);
                }

                //Drawing alien row 3
                for (int i = 0; i < alienRow3.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow3[i]);
                }

                //Drawing alien row 4
                for (int i = 0; i < alienRow4.Count(); i++)
                {
                    e.Graphics.FillEllipse(whiteBrush, alienRow4[i]);
                }
            }
        }
    }
}
