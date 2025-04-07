using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersRemastered
{
    class Aliens
    {
        public static int alienBulletSpeed = 6;
        public static int playerLives = 3;
        public static int alienSpeed = 1;
        public static int alienBulletX = 1000;
        public static int alienBulletY = 1000;
        public static int alienBulletWidth = 5;
        public static int alienBulletHeight = 15;
        public static int t;
        public static int randomFire;
      

        List<Rectangle> alienRow1 = new List<Rectangle>();
        List<Rectangle> alienRow2 = new List<Rectangle>();
        List<Rectangle> alienRow3 = new List<Rectangle>();
        List<Rectangle> alienRow4 = new List<Rectangle>();

        Random alienBullets = new Random();
        Random alienRow = new Random();

        public void _Aliens()
        {
            randomFire = alienBullets.Next(1, 301);

            //If random fire variable is between 1 and 5 and no alien bullet is on screen 
            if (randomFire < 5)
            {
                AlienAttack();
            }
        }

        public void AlienAttack()
        {
            int _playerX = Player.playerX;
            int _playerY = Player.playerY;
            int _width = Player.width;
            int _height = Player.height;
            int _cannonWidth = Player.cannonWidth;
            int _cannonHeight = Player.cannonHeight;
            int randColumn;
            int alienAttacks;

            Rectangle alienBullet = new Rectangle(alienBulletX, alienBulletY, 5, 15);
            alienBullet.Y = alienBullet.Y + alienBulletSpeed;

            Rectangle playerRec = new Rectangle(_playerX, _playerY, _width, _height);
            Rectangle cannonRec = new Rectangle(_playerX + 15, _playerY - 10, _cannonWidth, _cannonHeight);

            if (alienBullet.IntersectsWith(playerRec) || alienBullet.IntersectsWith(cannonRec))
            {
                playerLives--;
                alienBullet.X = 1000;
                alienBullet.Y = 1000;
            }

            Random alienRow = new Random();
            alienAttacks = alienRow.Next(1, 5);


            if (alienAttacks == 1 && alienRow1.Count() > 0)
            {
                randColumn = alienRow.Next(0, alienRow1.Count());
                alienBullet.X = alienRow1[randColumn].X;
                alienBullet.Y = alienRow1[randColumn].Y;
            }
            else if (alienAttacks == 2 && alienRow2.Count() > 0)
            {
                randColumn = alienRow.Next(0, alienRow2.Count());
                alienBullet.X = alienRow2[randColumn].X;
                alienBullet.Y = alienRow2[randColumn].Y;
            }
            else if (alienAttacks == 3 && alienRow3.Count() > 0)
            {
                randColumn = alienRow.Next(0, alienRow3.Count());
                alienBullet.X = alienRow3[randColumn].X;
                alienBullet.Y = alienRow3[randColumn].Y;
            }
            else if (alienAttacks == 4 && alienRow4.Count() > 0)
            {
                randColumn = alienRow.Next(0, alienRow4.Count());
                alienBullet.X = alienRow4[randColumn].X;
                alienBullet.Y = alienRow4[randColumn].Y;
            }
        }

        public void AlienMovement()
        {
            int endLine = 0;

            //Making aliens bounce back and forth
            for (int i = 0; i < alienRow1.Count; i++)
            {
                if (alienRow1[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow1[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }

            }

            for (int i = 0; i < alienRow2.Count; i++)
            {
                if (alienRow2[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow2[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            for (int i = 0; i < alienRow3.Count; i++)
            {
                if (alienRow3[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow3[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            for (int i = 0; i < alienRow4.Count; i++)
            {
                if (alienRow4[i].X == 780)
                {
                    alienSpeed = -1;
                    endLine++;
                }

                if (alienRow4[i].X == 0)
                {
                    alienSpeed = 1;
                    endLine++;
                }
            }

            //Making aliens move
            for (int i = 0; i < alienRow1.Count(); i++)
            {
                int x = alienRow1[i].X + alienSpeed;
                alienRow1[i] = new Rectangle(x, alienRow1[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow2.Count(); i++)
            {
                int x = alienRow2[i].X + alienSpeed;
                alienRow2[i] = new Rectangle(x, alienRow2[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow3.Count(); i++)
            {
                int x = alienRow3[i].X + alienSpeed;
                alienRow3[i] = new Rectangle(x, alienRow3[i].Y + endLine * 10, 25, 25);
            }

            for (int i = 0; i < alienRow4.Count(); i++)
            {
                int x = alienRow4[i].X + alienSpeed;
                alienRow4[i] = new Rectangle(x, alienRow4[i].Y + endLine * 10, 25, 25);
            }

            //Respawning aliens slightly lower than last time
            if (alienRow1.Count == 0 && alienRow2.Count == 0 && alienRow3.Count == 0 && alienRow4.Count == 0)
            {
                t++;
                Aliens.playerLives++;

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 50 + t * 20, 20, 20);
                    alienRow1.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 90 + t * 20, 20, 20);
                    alienRow2.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 130 + t * 20, 20, 20);
                    alienRow3.Add(alien);
                }

                for (int i = 0; i < 12; i++)
                {
                    Rectangle alien = new Rectangle(10 + i * 40, 170 + t * 20, 20, 20);
                    alienRow4.Add(alien);
                }
            }

            for (int i = 0; i < alienRow1.Count(); i++)
            {
                if (alienRow1[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow2.Count(); i++)
            {
                if (alienRow2[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow3.Count(); i++)
            {
                if (alienRow3[i].Y > 450)
                {
                    Death();
                }
            }

            for (int i = 0; i < alienRow4.Count(); i++)
            {
                if (alienRow4[i].Y > 450)
                {
                    Death();
                }
            }
        }

        public void alienInterception()
        {
            //Checking to see if an alien is hit with a bullet
            for (int i = 0; i < alienRow1.Count; i++)
            {
                if (GameScreen.bullet.IntersectsWith(alienRow1[i]))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow1.RemoveAt(i);
                    player.playerScore = player.playerScore + 40;
                }
            }

            for (int i = 0; i < alienRow2.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow2[i]))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow2.RemoveAt(i);
                    player.playerScore = player.playerScore + 20;
                }
            }

            for (int i = 0; i < alienRow3.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow3[i]))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow3.RemoveAt(i);
                    player.playerScore = player.playerScore + 10;
                }
            }

            for (int i = 0; i < alienRow4.Count; i++)
            {
                if (bullet.IntersectsWith(alienRow4[i]))
                {
                    bullet.X = 0;
                    bullet.Y = -20;
                    alienRow4.RemoveAt(i);
                    player.playerScore = player.playerScore + 10;
                }
            }
        }


    }
}
