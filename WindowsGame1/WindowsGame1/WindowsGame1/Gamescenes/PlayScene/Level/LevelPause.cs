using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class LevelPause : ILevel
    {

        //fields
        private Level level;
        private Image overlay;
        private int pauseTimeOver = 3;
        private float timer = 0;
        private int removeIndex;
        private string removeType;

        //properties
        public int RemoveIndex
        {
            set { this.removeIndex = value; }
        }

        public LevelPause(Level level)
        {
            this.level = level;
            this.overlay = new Image(level.Game, @"PlaySceneAssets\Overlay\overlay2", Vector2.Zero);
        }

        public string RemoveType
        {
            set { this.removeType = value; }
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                switch (this.removeType)
                {
                    case "Scorpion":
                        level.Scorpions.RemoveAt(this.removeIndex);
                        break;

                    case "Beetles":
                        level.Beetles.RemoveAt(this.removeIndex);
                        break;
                    default :
                        break;
                }
                
                this.removeIndex = -1;
                this.level.LevelState = level.LevelPlay;
                this.timer = 0f;
                level.Explorer.Position = new Vector2(288f, 192f);
                level.Explorer.State = new Idle(level.Explorer);
            }

        }

        public void Draw(GameTime gameTime)
        {
            this.overlay.Draw(gameTime);

        }
    }
}
