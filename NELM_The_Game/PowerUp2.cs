using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    //public class PowerUp2 : GameObject, IPowerUp
    //{
    //    public event Action OnSpecialGain;

    //    private LevelController levelController;
    //    public Transform PowerUpTransform => transform;

    //    private int scale = 32;

    //    public PowerUp2(float positionX, float positionY) //Constructor
    //    {
    //        levelController = GameManager.Instance.LevelController;

    //        transform = new Transform(positionX, positionY, scale, scale); //Se llama a la posición del Power Up

    //        renderer = new Renderer(transform, "powerup/powerup0", 10, 0.1f, true);

    //    }

    //    public void Update()
    //    {
    //        renderer.AnimationUpdate(); //Actualizacion de animacion
    //    }

    //    public void SpecialPower()
    //    {
    //        levelController.Score.AddPowerUpPoints(30);
    //        OnSpecialGain?.Invoke();
    //    }

    //}
}
