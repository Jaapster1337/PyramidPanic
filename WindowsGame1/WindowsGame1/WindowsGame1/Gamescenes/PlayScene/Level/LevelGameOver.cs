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
    public class LevelGameOver : ILevel
    {
        //fields
        private Level level;
        private Image GameOver;
        private int pauseTimeOver = 2;
        private float timer = 0;


        //constructor
        public LevelGameOver(Level level)
        {
            this.level = level;
            this.GameOver = GameOver = new Image(level.Game, @"PlaySceneAssets\Overlay\overlay", Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                level.Game.GameState = new StartScene(level.Game);
                this.timer = 0;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.GameOver.Draw(gameTime);
        }
    }
}
