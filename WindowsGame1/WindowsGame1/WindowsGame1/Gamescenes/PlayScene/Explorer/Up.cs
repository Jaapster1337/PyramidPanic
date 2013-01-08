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
    public class Up : AnimatedSprite
    {
        //Fields
        private Explorer explorer;

        //Constructor
        public Up(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.angle = (float)Math.PI*3/2;
            
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(0f,  this.explorer.Speed);
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalMalen32 = (int)this.explorer.Position.Y / 32;
                this.explorer.Position = new Vector2( this.explorer.Position.X, ((geheelAantalMalen32 + 1) * 32));
                if (Input.DetectKeyUp(Keys.Up))
                {
                    this.explorer.State = new Idle(this.explorer, -(float)Math.PI/2);
                }
            }
            //blijf op het grid
            if (Input.DetectKeyUp(Keys.Up))
            {
                float modulo = this.explorer.Position.Y % 32;
                if (modulo <= this.explorer.Speed)
                {
                    int geheelAantalMalen32 = (int)this.explorer.Position.Y / 32;
                    this.explorer.Position = new Vector2(this.explorer.Position.X, geheelAantalMalen32 * 32 );
                    this.explorer.State = new Idle(this.explorer, 0f);
                    this.explorer.State = new Idle(this.explorer, -(float)Math.PI/2);
                }
            }
            base.Update(gameTime);
        }
    

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
