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
    public class HelpScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        private Image background;
        private Texture2D text;
        private Rectangle rectangle1, rectangle2;
        private Vector2 position;

        //Constructor
        public HelpScene(PyramidPanic game)
        {
            this.game = game;
            this.background = new Image(this.game, @"PlaySceneAssets/background/Background2", Vector2.Zero);
            this.text = game.Content.Load<Texture2D>(@"PlaySceneAssets/Helper/help");
            this.rectangle1 = new Rectangle(300, 0, 40, 40);
            this.rectangle2 = new Rectangle(295, 420, 40, 40);
            this.position = Vector2.Zero;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //Loadcontent
        public void LoadContent()
        {

        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (this.position.Y >= 0)
            {
                this.position.Y = 0;
            }
            if (this.position.Y <= -300)
            {
                this.position.Y = -300;
            }
            if (Input.MouseRectangle().Intersects(rectangle1))
            {
                this.position.Y += 2;
            }

            if (Input.MouseRectangle().Intersects(rectangle2))
            {
                this.position.Y -= 2;
            }
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.HotPink);
            this.background.Draw(gameTime);
            this.game.SpriteBatch.Draw(text, position, Color.White); 
        }
    }
}

