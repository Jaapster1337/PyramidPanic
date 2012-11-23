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
    public class Panel
    {
        //fields
        private PyramidPanic game;
        private Vector2 position;
        private SpriteFont font;
        private List<Image> images;


        //constructor
        public Panel(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.Initialize();
        }

        private void Initialize()
        {
            this.font = this.game.Content.Load<SpriteFont>(@"PlaySceneAssets\Font\Arial");
            this.images = new List<Image>();
            this.LoadContent();
        }

        private void LoadContent()
        {
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Panel\Panel", this.position));
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Panel\lives", this.position 
                                + new Vector2(2.5f*32f,0f)));
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Scarab", this.position
                               + new Vector2(7.5f * 32f, 1f)));

        }

        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.images)
            {
                image.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.font,
                                             "3",
                                             this.position + new Vector2(3.8f * 32f, -2.5f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font,
                                             "0",
                                             this.position + new Vector2(8.5f * 32f, -2.5f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font,
                                             "0",
                                             this.position + new Vector2(16.5f * 32f, -2.5f),
                                             Color.Yellow);
        }
    }
}
