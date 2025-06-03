using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class NonDynamicPool
    {
        private List<Enemy> enemyAvailable = new List<Enemy>();
        private List <Enemy> enemyInUse = new List<Enemy>();
        
        public NonDynamicPool(int quantity)
        {
            for (int i = 0; i < quantity; i++)
            {
                Enemy enemy = new Enemy(0,0,0,0);
                enemyAvailable.Add(enemy);
            }
        }

        public Enemy GetEnemy(float posX, float posY, float speedX, float speedY)
        {
            Enemy enemy = null;

            if (enemyAvailable.Count > 0)
            {
                enemy = enemyAvailable[0];
                enemy.EnemyTransform.PosX = posX;
                enemy.EnemyTransform.PosY = posY;
                enemy.EnemyBehaviour.speedX = speedX;
                enemy.EnemyBehaviour.speedY = speedY;
                enemyAvailable.RemoveAt(0);
                enemyInUse.Add(enemy);
            }

            Engine.Debug(enemyAvailable.Count.ToString());
            return enemy;
        }

        public void RecycleEnemy(Enemy enemy)
        {
            enemyInUse.Remove(enemy);
            enemyAvailable.Add(enemy);
        }

    }
}
