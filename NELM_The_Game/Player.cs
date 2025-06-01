using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    //public delegate void OnCollision();

    public class Player : GameObject
    {
        private PlayerController playerController;
        private LevelController levelController;
        //private OnCollision onCollision;

        private int ogPosX = 480;
        private int ogPosY = 352;

        private int scale = 64;

        public PlayerController PlayerController
        {
            get => playerController;
        }

        public Player()
        {
            float positionX = ogPosX;
            float positionY = ogPosY;
            transform = new Transform(positionX, positionY, scale, scale); //Donde aparece
            renderer = new Renderer(transform, "player/player_idle/player_idle", 3, 0.1f, true);
            playerController = new PlayerController(transform); //Hacia donde se mueve
            levelController = GameManager.Instance.LevelController;

            //onCollision += Death;
        }

        private void CheckCollision()
        {
            for (int i = 0; i < levelController.EnemyList.Count; i++)
            {
                Enemy enemy = levelController.EnemyList[i];

                float distanceX = Math.Abs((enemy.EnemyTransform.PosX + enemy.EnemyTransform.ScaleX) - (transform.PosX + transform.ScaleX));
                float distanceY = Math.Abs((enemy.EnemyTransform.PosY + enemy.EnemyTransform.ScaleY) - (transform.PosY + transform.ScaleY));

                float sumHalfWidth = (enemy.EnemyTransform.ScaleX / 2) + (transform.ScaleX / 2);
                float sumHeightWidth = (enemy.EnemyTransform.ScaleX / 2) + (transform.ScaleX / 2);

                if (!playerController.Invincibility && distanceX < sumHalfWidth && distanceY < sumHeightWidth)
                {

                    //onCollision.Invoke();
                    Death();
                }
            }

            if (levelController.PowerUp != null) 
            {
                PowerUp powerUp = levelController.PowerUp;

                //collider.CheckCollision(transform, powerup);

                float powerUpDistanceX = Math.Abs((powerUp.PowerUpTransform.PosX + powerUp.PowerUpTransform.ScaleX) - (transform.PosX + transform.ScaleX));
                float powerUpDistanceY = Math.Abs((powerUp.PowerUpTransform.PosY + powerUp.PowerUpTransform.ScaleY) - (transform.PosY + transform.ScaleY));

                float sumPowerUpDistanceX = (powerUp.PowerUpTransform.ScaleX / 2) + (transform.ScaleX / 2);
                float sumPowerUpDistanceY = (powerUp.PowerUpTransform.ScaleY / 2) + (transform.ScaleY / 2);

                if (powerUpDistanceX < sumPowerUpDistanceX && powerUpDistanceY < sumPowerUpDistanceY)
                {
                    powerUp.GainInvincibility();

                }
            }
        }

        public void Update()
        {
            playerController.Update();

            renderer.AnimationUpdate();

            CheckCollision();
        }

        public void Death()
        {
            GameManager.Instance.gameStage = GameState.Lose;
            Engine.Debug("CRITICAL HIT");
        }


    }
}
