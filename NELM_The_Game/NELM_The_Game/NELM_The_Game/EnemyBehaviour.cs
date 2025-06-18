using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class EnemyBehaviour
    {
        private Transform enemyTransform;

        public float speedX = 0;
        public float speedY = 0;

        public EnemyBehaviour(Transform transform, float speedX, float speedY) 
        { 
            this.speedX = speedX;
            this.speedY = speedY;
            enemyTransform = transform;
        }

        public void Update()
        {
            enemyTransform.Translate(speedX, speedY);
        }

    }
}
