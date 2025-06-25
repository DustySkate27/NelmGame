using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController : IUpdatable 
    {

        private LevelController levelController;
        private Transform transform;

        private float reseter = 0;

        private bool invincibility = false;
        private float invincibilityTimer = 0f;
        private float invincibilityDuration = 3f;

        private bool superSpeed = false;
        private float superSpeedTimer = 0f;
        private float superSpeedDuration = 5f;

        private int upperLimit = 70;
        private int lowerLimit = 632;
        private int rightLimit = 850;
        private int leftLimit = 110;

        private int horizontalMovement = 185;
        private int verticalMovement = 140;
        private float movementCooldown = 0.2f;

        private int movementPoints = 3;
        

        public bool Invincibility  
        {
            get => invincibility;
            set => invincibility = value; 
        }

        public float InvincibilityTimer  
        {
            get => invincibilityTimer;
            set => invincibilityTimer = value;
        }

        public bool SuperSpeed
        {
            get => superSpeed;
            set => superSpeed = value;
        }

        public float SuperSpeedTimer
        {
            get => superSpeedTimer;
            set => superSpeedTimer = value;
        }

        public PlayerController(Transform trans)  
        {
            transform = trans;
            levelController = GameManager.Instance.LevelController;
        }

        public void Update() 
        {
            reseter += Time.DeltaTime;  

            if (reseter >= movementCooldown)
            { 
                if (Engine.GetKey(Engine.KEY_D) && transform.PosX + horizontalMovement <= rightLimit)
                {
                    transform.TranslateJump(1, 0, horizontalMovement);
                    reseter = 0;
                    levelController.Score.ScoreQuantity += movementPoints;
                }
                if (Engine.GetKey(Engine.KEY_A) && transform.PosX - horizontalMovement >= leftLimit)
                {
                    transform.TranslateJump(-1, 0, horizontalMovement);
                    reseter = 0;
                    levelController.Score.ScoreQuantity += movementPoints;
                }
                if (Engine.GetKey(Engine.KEY_S) && transform.PosY + verticalMovement <= lowerLimit)
                {
                    transform.TranslateJump(0, 1, verticalMovement);
                    reseter = 0;
                    levelController.Score.ScoreQuantity += movementPoints;
                }
                if (Engine.GetKey(Engine.KEY_W) && transform.PosY - verticalMovement >= upperLimit)
                {
                    transform.TranslateJump(0, -1, verticalMovement);
                    reseter = 0;
                    levelController.Score.ScoreQuantity += movementPoints;
                }
            }

            if (invincibility)  
            {

                invincibilityTimer += Time.DeltaTime;  
                if(invincibilityTimer >= invincibilityDuration)  
                {
                    levelController.Player1.Renderer.ChangeAnimation("player/player_idle/player_idle", 3, 0.1f);
                    invincibility = false;  
                }
            }

            if (superSpeed)
            {
                superSpeedTimer += Time.DeltaTime;
                movementCooldown = 0.1f;
                if (superSpeedTimer >= superSpeedDuration)
                {
                    levelController.Player1.Renderer.ChangeAnimation("player/player_idle/player_idle", 3, 0.1f);
                    superSpeed = false;
                    movementCooldown = 0.2f;
                }
            }

        }
    }
}
