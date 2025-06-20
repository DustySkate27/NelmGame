﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController: IUpdatable
    {

        private LevelController levelController;
        private Transform transform;

        private float reseter = 0;

        //Variables de invencibilidad
        private bool invincibility = false;
        private float invincibilityTimer = 0f;
        private float invincibilityDuration = 3f;

        //Variables de super velocidad
        private bool superSpeed = false;
        private float superSpeedTimer = 0f;
        private float superSpeedDuration = 5f;

        //Limites de movimieto del jugador
        private int upperLimit = 70;
        private int lowerLimit = 632;
        private int rightLimit = 850;
        private int leftLimit = 110;

        //Valores de movimiento del jugador
        private int horizontalMovement = 185;
        private int verticalMovement = 140;
        private float movementCooldown = 0.2f;

        //puntos por movimiento/colision
        private int movementPoints = 3;
        

        public bool Invincibility //Invencibilidad
        {
            get => invincibility;
            set => invincibility = value; 
        }

        public float InvincibilityTimer //Duracion invencibilidad
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

        public PlayerController(Transform trans) //Constructor
        {
            transform = trans;
            levelController = GameManager.Instance.LevelController;
        }

        public void Update() 
        {
            reseter += Time.DeltaTime; //Cooldown entre paso y paso

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

            if (invincibility) //Si es invencible
            {

                invincibilityTimer += Time.DeltaTime; //Se activa un timer
                if(invincibilityTimer >= invincibilityDuration) //Duracion limitada
                {
                    levelController.Player1.Renderer.ChangeAnimation("player/player_idle/player_idle", 3, 0.1f);
                    invincibility = false; //Ya no es invencible
                    Engine.Debug("Invencibilidad desactivada");
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
                    Engine.Debug("Super velocidad desactivada");
                }
            }

        }
    }
}
