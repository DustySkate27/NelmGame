using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public class PowerUpInvincibility : GameObject, IPowerUp, IUpdatable //Hereda de GameObject y posee propiedades de la interfaz de los PowerUps
    {
        public event Action OnSpecialGain; //Evento que acumula acciones relacionadas al momento en el que se pickea un Power Up

        private LevelController levelController;

        private int scale = 32;

        public PowerUpInvincibility(float positionX, float positionY, float speedAnimation) //Constructor
        {
            levelController = GameManager.Instance.LevelController;

            transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up

            renderer = new Renderer(transform, "powerup/powerup0", 10, 0.1f, true);

        }

        public void Update()
        {
            renderer.AnimationUpdate();
        }

        public void SpecialPower() //Se activa al colisionar con un Power Up. Provee puntos e invoca al evento.
        {
            levelController.Player1.Renderer.ChangeAnimation("player/player_power1/player_power0", 3, 0.1f);
            levelController.Score.AddPowerUpPoints(30);
            OnSpecialGain?.Invoke();
        }
    }
}