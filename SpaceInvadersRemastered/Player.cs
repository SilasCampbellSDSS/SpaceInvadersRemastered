using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvadersRemastered
{
    class Player
    {
        public int playerSpeed = 5;
        public int bulletSpeed = 12;
        public static int playerX = GameScreen.screenWidth/2  - 25;
        public static int playerCannonX = GameScreen.screenWidth/2 - 25;
        public static int playerY = 500;
        public static int playerCannonY = 530;

        public static int width = 50;
        public static int height = 20;
        public static int cannonWidth = 20;
        public static int cannonHeight = 10;

        public int playerScore = 0;

        public void PlayerMove(string direction)
        {

            if (direction == "right" && playerX <= GameScreen.screenWidth - width)
            {
                playerX += playerSpeed;
                playerCannonX = playerCannonX - playerSpeed;
            }

            if (direction == "left" && playerX >= 0)
            {
                playerX -= playerSpeed;
                playerCannonX = playerCannonX + playerSpeed;
            }  
        }

        public void PlayerAttack(string direction)
        {
            
        }

        
        
        
    }

}
