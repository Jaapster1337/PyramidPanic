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
    public class Explorer : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle;
        private float speed;

        //State variabele is de parentclass van de toestandsklasse
        AnimatedSprite state;

        //Properties
        public Vector2 Position
        {
            get { return this.position; }
            set
            {
                this.position = value;
                this.rectangle.X = (int)this.position.X+16;
                this.rectangle.Y = (int)this.position.Y+16;
            }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Rectangle Rectangle
        { 
            get { return this.rectangle; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
        }
        //Constructor
        public Explorer(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\Explorer");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X , 
                                           (int)this.position.Y , 
                                           this.texture.Width/4, 
                                           this.texture.Height);
            this.state = new Right(this);
            
        }

        


        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }


        //Draw
        public void Draw(GameTime gameTime)
        {
             this.state.Draw(gameTime);
        }
    }
}
