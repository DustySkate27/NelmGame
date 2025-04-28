using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{
    public class GameManager
    {
        
        private static GameManager instance;

        private LevelController levelController;
        public LevelController LevelController => levelController;

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }

        


        public void Update()
        {
            levelController.Update();
        }

        public void Render()
        {
            levelController.Render();
        }

        public void Initialize()
        {
            levelController = new LevelController();
            LevelController.Intialize();
        }




    }
}
