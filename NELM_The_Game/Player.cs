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

    public class Player
    {
        private PlayerController playerController;
        private Transform playerTransform;
        private Animation playerAnim;
        private PowerUp powerUp;
        private LevelController levelController;
        //private OnCollision onCollision;

        private int ogPosX = 480;
        private int ogPosY = 352;

        public int OGPosX => ogPosX;
        public int OGPosY => ogPosY;

        public PlayerController PlayerController
        {
            get => playerController;
        }

        public bool Invincibility
        {
            get => Invincibility;
            set => Invincibility = value;
        }

        public Player(float positionX, float positionY)
        {
            playerTransform = new Transform(positionX, positionY, 64, 64); //Donde aparece
            playerController = new PlayerController(playerTransform); //Hacia donde se mueve
            levelController = GameManager.Instance.LevelController;

            List<Image> images = new List<Image>(); //Lista de frames

            for (int i = 0; i < 3; i++) //Se cargan los frames
            {
                Image imagen = Engine.LoadImage($"assets/player/player_idle/player_idle{i}.png");
                images.Add(imagen);
            }

            //onCollision += Death;

            playerAnim = new Animation(images, 0.1f, true); //Animacion de player
        }

        private void CheckCollision()
        {
            for (int i = 0; i < levelController.EnemyList.Count; i++)
            {
                Enemy enemy = levelController.EnemyList[i];

                float distanceX = Math.Abs((enemy.EnemyTransform.PosX + enemy.EnemyTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float distanceY = Math.Abs((enemy.EnemyTransform.PosY + enemy.EnemyTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumHalfWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumHeightWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);

                if (!playerController.Invincibility && distanceX < sumHalfWidth && distanceY < sumHeightWidth)
                {

                    //onCollision.Invoke();
                    Death();
                }
            }

            if (levelController.PowerUp != null) 
            {
                PowerUp powerUp = levelController.PowerUp;

                float powerUpDistanceX = Math.Abs((powerUp.PowerUpTransform.PosX + powerUp.PowerUpTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float powerUpDistanceY = Math.Abs((powerUp.PowerUpTransform.PosY + powerUp.PowerUpTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumPowerUpDistanceX = (powerUp.PowerUpTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumPowerUpDistanceY = (powerUp.PowerUpTransform.ScaleY / 2) + (playerTransform.ScaleY / 2);

                if (powerUpDistanceX < sumPowerUpDistanceX && powerUpDistanceY < sumPowerUpDistanceY)
                {
                    powerUp.GainInvincibility();
                }
            }
        }

        public void Update()
        {
            playerController.Update();

            playerAnim.Update();

            CheckCollision();
        }

        public void Render()
        {
            Engine.Draw(playerAnim.CurrentImage, playerTransform.PosX, playerTransform.PosY);
        }

        public void Death()
        {
            GameManager.Instance.gameStage = GameState.Lose;
            Engine.Debug("CRITICAL HIT");
        }


    }
}
