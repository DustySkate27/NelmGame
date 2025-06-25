using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class Score : IUpdatable
    {
        private Font font;
        private int scoreQuantity = 0;


        private float actualTime;

        public int ScoreQuantity
        {
            get => scoreQuantity;
            set => scoreQuantity = value;
        }

        public Score()  
        { 
            InitialScore();
        }

        public void InitialScore()  
        {
            font = Engine.LoadFont("assets/fonts/myfont.ttf", 32);
            scoreQuantity = 0;
        }


        private void RaiseScore()  
        {
            actualTime += Time.DeltaTime;

            if (actualTime > 5) 
            {
                scoreQuantity += 10;
                actualTime = 0;
            }
        }

        public void AddPowerUpPoints(int amount)  
        {
            scoreQuantity += amount;
        }

        public void Render()  
        {
            string scoreText = "Score: " + scoreQuantity;
            Engine.DrawText(scoreText, 820,0,0,0,0,font);
        }

        public void Update()  
        {
            RaiseScore();
        }

    }
}