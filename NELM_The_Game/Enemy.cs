using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy
    {
        private Image enemyIdle = Engine.LoadImage("assets/enemy/enemy_idle/enemy_idle0.png");

        private EnemyBehaviour enemyBehaviour;
        private Transform enemyTransform;

        private Animation enemyIdleAnim;

        public int speed = 5;

        public Transform EnemyTransform => enemyTransform;

        public Enemy(float positionX, float positionY, float speedX, float speedY)
        {
            enemyTransform = new Transform(positionX, positionY, 64, 64);
            enemyBehaviour = new EnemyBehaviour(enemyTransform, speedX, speedY);
        }

        public void Update()
        {
            enemyBehaviour.Update();
        }

        public void Render()
        {
            Engine.Draw(enemyIdle, enemyTransform.PosX, enemyTransform.PosY);
        }
    }
}
