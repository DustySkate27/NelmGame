﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class PlayerController
    {

        private Transform transform;

        private int horizontalJump = 185;
        private int verticalJump = 140;

        private float movementCooldown = 0.2f;
        private float reseter = 0;

        private bool invincibility = false;
        private float invincibilityTimer = 0f;
        private float invincibilityDuration = 3f;

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

        public PlayerController(Transform trans) //Constructor
        {
            transform = trans;
        }

        public void Update() 
        {
            reseter += Time.DeltaTime; //Cooldown entre paso y paso

            if (reseter >= movementCooldown)
            { 
                if (Engine.GetKey(Engine.KEY_D) && transform.PosX + horizontalJump <= 850)
                {
                    transform.TranslateJump(1, 0, 185);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_A) && transform.PosX - horizontalJump >= 110)
                {
                    transform.TranslateJump(-1, 0, 185);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_S) && transform.PosY + verticalJump <= 632)
                {
                    transform.TranslateJump(0, 1, 140);
                    reseter = 0;
                }
                if (Engine.GetKey(Engine.KEY_W) && transform.PosY - verticalJump >= 70)
                {
                    transform.TranslateJump(0, -1, 140);
                    reseter = 0;
                }
            }

            if (invincibility) //Si es invencible
            {
                invincibilityTimer += Time.DeltaTime; //Se activa un timer
                if(invincibilityTimer >= invincibilityDuration) //Duracion limitada
                {
                    invincibility = false; //Ya no es invencible
                    Engine.Debug("Invencibilidad desactivada");
                }
            }

        }
    }
}
