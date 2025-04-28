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
        public EnemyBehaviour(Transform transform, float speedX, float speedY) 
        { 
            this.speedX = speedX;
            this.speedY = speedY;
            enemyTransform = transform;
        }

        private float speedX = 5;
        private float speedY = 5;


        public void Update() 
        {

            enemyTransform.Translate(speedX, speedY);

        } 

    }
}
