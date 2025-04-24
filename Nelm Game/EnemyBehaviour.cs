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
        public EnemyBehaviour(Transform transform) 
        { 
            enemyTransform = transform;
        }

        private float speed = 5;

        public void Update() 
        {

            enemyTransform.Translate(1, 0, speed);

        } 

    }
}
