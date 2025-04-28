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

        private Random randomEnemyPos = new Random();
        private float enemyCD = 5f;
        private float timeSinceLastEnemyY = 0f;
        private float timeSinceLastEnemyX = 0f;

        public List<Enemy> EnemyList => enemyList;

        public void Update()
        {

            player1.Update();

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Update();
            }

            timeSinceLastEnemyY += Program.DeltaTime;
            timeSinceLastEnemyX += Program.DeltaTime;

            EnemySpawner();
        }

        public void Render()
        {
            Engine.Clear();
            Engine.Draw(background, 0, 0);

            player1.Render();

            for (int i = 0; i < enemyList.Count; i++)
            {
                enemyList[i].Render();
            }

            Engine.Show();
        }

        private void EnemySpawner()
        {
            int[] enemyPosY = { 70, 210, 350, 490, 630 };
            int[] enemyPosX = { 70, 210, 350, 490, 630 };

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

        public void Intialize()
        {
            player1 = new Player(480, 352);
        }
    }
}
