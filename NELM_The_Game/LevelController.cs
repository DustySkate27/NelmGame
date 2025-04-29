using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class LevelController
    {
        private Image background = Engine.LoadImage("assets/background.png");

        private List<Enemy> enemyList = new List<Enemy>();
        private Player player1;
        private Score score;
        private PowerUp powerUp;

        private float actualTime;

        private Random randomEnemyPos = new Random();
        private float enemyCD = 2f;
        private float timeSinceLastEnemyY = 0f;
        private float timeSinceLastEnemyX = 0f;

        public List<Enemy> EnemyList => enemyList;
        public PowerUp PowerUp
        {
            get { return powerUp; }
            set { powerUp = value; }
        }

        public Score Score
        {
            get { return score; }
            set { score = value; }
        }

        public void Update()
        {

            player1.Update();

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update();
            }

            timeSinceLastEnemyY += Time.DeltaTime;
            timeSinceLastEnemyX += Time.DeltaTime;
            actualTime += Time.DeltaTime;
            Engine.Debug($"tiempo: {actualTime}");

            EnemySpawner();
            PowerUpSpawner();

            score.Update();

            if (powerUp != null )
            { 
                powerUp.Update(); 
            }
        }

        public void Render()
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0);
            score.Render();
            player1.Render();

            if (powerUp != null)
            {
                powerUp.Render();
            }

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Render();
            }

            Engine.Show();
        }

        private void EnemySpawner()
        {
            int[] enemyPosY = { 70, 210, 350, 490, 630 };
            int[] enemyPosX = { 110, 295, 480, 665, 850 };

            if (timeSinceLastEnemyY >= enemyCD)
            {
                int randomIndexY = randomEnemyPos.Next(enemyPosY.Length);
                int randomY = enemyPosY[randomIndexY];

                enemyList.Add(new Enemy(-64, randomY, 5, 0));
                timeSinceLastEnemyY = 0f;
            }
            if (timeSinceLastEnemyX >= enemyCD)
            {
                int randomIndexX = randomEnemyPos.Next(enemyPosX.Length);
                int randomX = enemyPosX[randomIndexX];

                enemyList.Add(new Enemy(randomX, -64, 0, 5));
                timeSinceLastEnemyX = 0f;
            }
        }

        private void PowerUpSpawner()
        {
            int[] powerUpPosX = { 70, 210, 350, 490, 630 };
            int[] powerUpPosY = { 110, 295, 480, 665, 850 };

            if (powerUp == null && actualTime > 10)
            {
                int randomIndexY = randomEnemyPos.Next(powerUpPosX.Length);
                int randomY = powerUpPosX[randomIndexY];

                int randomIndexX = randomEnemyPos.Next(powerUpPosY.Length);
                int randomX = powerUpPosY[randomIndexX];

                powerUp = new PowerUp(randomX, randomY);
                actualTime = 0;
            }
        }

        public void Initialize()
        {
            player1 = new Player(480, 350);
            player1.controller.Invincibility = false;
            player1.controller.InvincibilityTimer = 0f;

            score = new Score();
            powerUp = null;
            actualTime = 0;
        }
    }
}
