using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy : GameObject
    {
        private EnemyBehaviour enemyBehaviour;

        public Transform EnemyTransform => transform;
        public EnemyBehaviour EnemyBehaviour => enemyBehaviour;

        public Enemy(float positionX, float positionY, float speedX, float speedY) 
        {
            transform = new Transform(positionX, positionY, 64, 64); 
            enemyBehaviour = new EnemyBehaviour(transform, speedX, speedY); 
            renderer = new Renderer(transform, "enemy/enemy_idle/enemy_idle", 1, 0.1f, true);
            
        }

        public void Update()
        {
            enemyBehaviour.Update(); 

            renderer.AnimationUpdate();

            if (transform.PosX > 1024)
            {
                NonDynamicPool pool = GameManager.Instance.LevelController.NonDynamical;
                pool.RecycleEnemy(this);
                GameManager.Instance.LevelController.EnemyList.Remove(this);
            }

            if (transform.PosY > 768)
            {
                NonDynamicPool pool = GameManager.Instance.LevelController.NonDynamical;
                pool.RecycleEnemy(this);
                GameManager.Instance.LevelController.EnemyList.Remove(this);
            }
        }
    }
}
