using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Player
    {
        private PlayerController playerController;
        private Transform playerTransform;
        private Animation currentAnimation;

        public Player(float positionX, float positionY)
        {
            playerTransform = new Transform(positionX, positionY, 64, 64);
            playerController = new PlayerController(playerTransform);

            List<Image> images = new List<Image>();

            for (int i = 0; i < 3; i++)
            {
                Image imagen = Engine.LoadImage($"assets/player/player_idle/player_idle{i}.png");
                images.Add(imagen);
            }

            currentAnimation = new Animation("player_idle", images, 0.1f, true);
        }

        private void CheckCollision()
        {
            for (int i = 0; i < GameManager.Instance.LevelController.EnemyList.Count; i++)
            {
                Enemy enemy = GameManager.Instance.LevelController.EnemyList[i];

                float distanceX = Math.Abs((enemy.EnemyTransform.PosX + enemy.EnemyTransform.ScaleX) - (playerTransform.PosX + playerTransform.ScaleX));
                float distanceY = Math.Abs((enemy.EnemyTransform.PosY + enemy.EnemyTransform.ScaleY) - (playerTransform.PosY + playerTransform.ScaleY));

                float sumHalfWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);
                float sumHeightWidth = (enemy.EnemyTransform.ScaleX / 2) + (playerTransform.ScaleX / 2);

                if (distanceX < sumHalfWidth && distanceY < sumHeightWidth)
                {

                }
            }
        }

        public void Update()
        {
            playerController.Update();

            

            currentAnimation.Update();

            CheckCollision();
        }

        public void Render()
        {
            Engine.Draw(currentAnimation.CurrentImage, playerTransform.PosX, playerTransform.PosY);
        }

    }
}
