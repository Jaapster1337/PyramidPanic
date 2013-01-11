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
    public class Beetle : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture;
        private Vector2 position;
        private Rectangle rectangle, collisionRectangle;
        private IBeetle state;
        private float speed;
        private float top, bottom;

        //Properties
        public float Bottom
        {
            set { this.bottom = value; }
            get { return this.bottom; }
        }

        public float Top
        {
            set { this.top = value; }
            get { return this.top; }
        }

        public float Speed
        {
            get { return this.speed; }
        }

        public Vector2 Position
        {
            get { return this.position; }
            set 
            {
                this.position = value;
                this.rectangle.X = (int)this.position.X+16;
                this.rectangle.Y = (int)this.position.Y+16;
                this.collisionRectangle.X = (int)this.position.X;
                this.collisionRectangle.Y = (int)this.position.Y;
            } 
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Texture2D Texture
        {                           

            get { return this.texture; }
        }

        public Rectangle Rectangle
        {
           get { return this.rectangle; }
        }

        public IBeetle State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        public Rectangle CollisionRectangle
        {
            get { return this.collisionRectangle; }
            set { this.collisionRectangle = value; }
        }
        
        //Constructor
        public Beetle(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Beetles\Beetle");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width/4, this.texture.Height);
            this.collisionRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.state = new WalkUp(this);
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
