﻿using System;
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
    public class Left : AnimatedSprite
    {
        //Fields
        private Explorer explorer;

        //Constructor
        public Left(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.angle = (float)Math.PI;
            
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position -= new Vector2(this.explorer.Speed, 0f);
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalMalen32 = (int)this.explorer.Position.X / 32;
                this.explorer.Position = new Vector2((geheelAantalMalen32 + 1) * 32, this.explorer.Position.Y);
                if (Input.DetectKeyUp(Keys.Left))
                {
                    this.explorer.State = new Idle(this.explorer, (float)Math.PI);
                }
            }
            //blijf op het grid
            if (Input.DetectKeyUp(Keys.Left))
            {
                float modulo = (this.explorer.Position.X >= 0) ?
                                this.explorer.Position.X % 32 :
                                32 + this.explorer.Position.X % 32;
                if (modulo <= this.explorer.Speed)
                {
                    int geheelAantalMalen32 = (int)this.explorer.Position.X / 32;
                    this.explorer.Position = new Vector2((geheelAantalMalen32) * 32, this.explorer.Position.Y);
                    this.explorer.State = new Idle(this.explorer, (float)Math.PI);                   
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
