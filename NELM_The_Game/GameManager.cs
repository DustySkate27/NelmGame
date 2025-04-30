using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGame
{

    public enum GameState //Se crean instancias de juego
    {
        Menu, Game, Win, Lose
    }

    public class GameManager
    {
        public GameState gameStage = GameState.Menu;

        private Score score;

        

        private static GameManager instance;

        private readonly Animation menu;
        private readonly Animation win;
        private readonly Animation lose;



        private LevelController levelController;
        public LevelController LevelController => levelController;

        public static GameManager Instance //Singleton
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

        public GameManager() //Constructor
        {
            List<Image> menuFrames = new List<Image>(); //Lista de frames de Menu

            for (int i= 1; i < 3; i++) //Se cargan los frames de Menu
            {
                Image image = Engine.LoadImage($"assets/Screens/f{i}Menu.png");
                menuFrames.Add(image);
            }

            menu = new Animation(menuFrames, 0.5f, true); //Se llama una nueva animacion compuesta por los frames añadidos

            List<Image> winFrames = new List<Image>(); //Lista de frames de Win

            for (int i = 1; i < 3; i++) //Se cargan los frames de Win
            {
                Image image = Engine.LoadImage($"assets/Screens/f{i}Win.png");
                winFrames.Add(image);
            }

            win = new Animation(winFrames, 0.5f, true); //Se llama una nueva animacion compuesta por los frames añadidos

            List<Image> loseFrames = new List<Image>(); //Lista de frames de Lose

            for (int i = 1; i < 3; i++) //Se cargan los frames de Lose
            {
                Image image = Engine.LoadImage($"assets/Screens/f{i}Lose.png");
                loseFrames.Add(image);
            }

            lose = new Animation(loseFrames, 0.5f, true); //Se llama una nueva animacion compuesta por los frames añadidos

        } 
        


        public void Update()
        {
            
            switch (gameStage) //Variable que determina el instante del programa
            {
                case GameState.Menu:
                    {
                        if (Engine.GetKey(Engine.KEY_ESP))
                        {
                            gameStage = GameState.Game;
                            
                        }
                        break;
                    }
                case GameState.Game:
                    {
                        levelController.Update();
                        break;
                    }
                case GameState.Win:
                    {
                        if (Engine.GetKey(Engine.KEY_R))
                        {
                            RestartLevel();
                        }
                        break;
                    }
                case GameState.Lose:
                    {
                        if (Engine.GetKey(Engine.KEY_R))
                        {
                            RestartLevel();
                            score.ResetScore();
                        }
                        break;
                    }

            }


            
        }

        public void Render()
        {
            Engine.Clear();

            switch (gameStage) //Variable que determina el instante del programa
            {
                case GameState.Menu:
                    {
                        menu.Update();
                        Engine.Draw(menu.CurrentImage, 0, 0);
                        break;
                    }
                case GameState.Game:
                    {
                        levelController.Render();
                        break;
                    }
                case GameState.Win:
                    {
                        win.Update();
                        Engine.Draw(win.CurrentImage, 0, 0);
                        break;
                    }
                case GameState.Lose:
                    {
                        lose.Update();
                        Engine.Draw(lose.CurrentImage, 0, 0);
                        break;
                    }

            }

            Engine.Show();
 
        }

        public void Initialize()
        {
            levelController = new LevelController();
            levelController.Initialize();

            score = new Score();
        }

        public void RestartLevel()
        {
            levelController = new LevelController();
            levelController.Initialize();
            gameStage = GameState.Game;
        }


    }
}
