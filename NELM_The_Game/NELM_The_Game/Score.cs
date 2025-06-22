using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Score: IUpdatable
    {
        private Font font;
        private int scoreQuantity = 0;


        private float actualTime;

        public int ScoreQuantity
        {
            get => scoreQuantity;
            set => scoreQuantity = value;
        }

        public Score() //Constructor
        { 
            ActualScore();
        }

        public void ActualScore() // La puntuacion actual
        {
            font = Engine.LoadFont("assets/fonts/myfont.ttf", 32);
            scoreQuantity = 0;
        }

        private void RaiseScore() // Incrementa puntaje cada 5 segundos.
        {
            actualTime += Time.DeltaTime;

            if (actualTime > 5) 
            {
                scoreQuantity += 10;
                actualTime = 0;
            }
        }

        public void ResetScore() // Resetea el score al reiniciar la partida
        {
            scoreQuantity = 0;
        }

        public void AddPowerUpPoints(int amount) // Método de incremento de puntaje en funcion de accion
        {
            scoreQuantity += amount;
        }

        public int AddPointsChecker(int amount)
        {
            var currentScore = scoreQuantity + amount;
            return currentScore;
        }

        public void Render() //Renderizado del puntaje
        {
            string scoreText = "Score: " + scoreQuantity;
            Engine.DrawText(scoreText, 820,0,0,0,0,font);
        }

        public void Update() //Actualizacion constante del puntaje
        {
            RaiseScore();
        }

    }
}