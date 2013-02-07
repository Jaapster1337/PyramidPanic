using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
namespace PyramidPanic
{
    public class PlayScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        private Level level;
        private static int levelNumber = 1;
        private static int endLevel = 9;

        //Constructor
        public PlayScene(PyramidPanic game)
        {
            this.game = game;
            if (levelNumber == 0 || Score.isDead())
            {
                levelNumber = 1;
                Score.Initialize();
            }
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        public static int LevelNumber
        {
            get { return levelNumber; }
            set { levelNumber = value; }
        }

        //Loadcontent
        public void LoadContent()
        {
            this.level = new Level(this.game, levelNumber);
        }
        
        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }

            if (Input.MouseEdgeDetectPressLeft())
            {
                this.game.Exit();
            }
            this.level.Update(gameTime);

            if (Score.isDead())
            {
                this.level.LevelState = level.LevelGameOver;
            }

            if (ExplorerManager.WalkOutOfLevel())
            {
                Score.DoorsAreClosed = true;
                levelNumber += 1;
                Console.WriteLine(levelNumber);
                this.level.Explorer.Position = new Vector2(100f, 100f);
                if (levelNumber == endLevel)
                {
                    this.level.LevelState = new LevelEndGame(this.level);
                    levelNumber = 1;
                }
                else
                {
                    this.level.LevelState = level.LevelNextLevel;
                }
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Purple);
            this.level.Draw(gameTime);
        }
    }
}
