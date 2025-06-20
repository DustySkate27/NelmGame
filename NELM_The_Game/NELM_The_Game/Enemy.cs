﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Enemy : GameObject, IUpdatable //Hereda de GameObject
    {
        private EnemyBehaviour enemyBehaviour;

        public Transform EnemyTransform => transform;
        public EnemyBehaviour EnemyBehaviour => enemyBehaviour;

        public Enemy(float positionX, float positionY, float speedX, float speedY) //Constructor
        {
            transform = new Transform(positionX, positionY, 64, 64); //Donde aparece
            enemyBehaviour = new EnemyBehaviour(transform, speedX, speedY); //Hacia donde se mueve
            renderer = new Renderer(transform, "enemy/enemy_idle/enemy_idle", 1, 0.1f, true);
            
        }

        public void Update()
        {
            enemyBehaviour.Update(); //Actualiza su posicion

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
