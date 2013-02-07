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
    public class LevelEditorPanel
    {
        //Fields
        private LevelEditorScene levelEditorScene;
        private Vector2 position;
        private Image background;
        private List<Image> levelEditorButtons, levelEditorAssets;
        private int levelEditorAssetsIndex = 0;
        private SpriteFont Arial;

        //Properties
        public List<Image> LevelEditorAssets
        {
            get { return this.levelEditorAssets; }
        }
        

        //Constructor
        public LevelEditorPanel(LevelEditorScene levelEditorScene, Vector2 position)
        {
            this.levelEditorScene = levelEditorScene;
            this.position = position;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        { 
            this.LoadContent();

        }

        //LoadContent
        private void LoadContent()
        {
            this.Arial = this.levelEditorScene.Game.Content.Load<SpriteFont>(@"PlaySceneAssets\Font\Arial");
            this.levelEditorButtons = new List<Image>();
            this.levelEditorAssets = new List<Image>();
            this.levelEditorButtons.Add(new Image(this.levelEditorScene.Game,
                                                     @"LevelEditorAssets\Left", this.position + new Vector2(2.5f * 32f, 0f)));
            this.levelEditorButtons.Add(new Image(this.levelEditorScene.Game,
                                                     @"LevelEditorAssets\Right", this.position + new Vector2(4.5f * 32f, 0f)));
            this.background = new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Panel", this.position);
            this.levelEditorButtons.Add(new Image(this.levelEditorScene.Game,
                                                     @"LevelEditorAssets\Left", this.position + new Vector2(9f * 32f, 0f)));
            this.levelEditorButtons.Add(new Image(this.levelEditorScene.Game,
                                                     @"LevelEditorAssets\Right", this.position + new Vector2(11f * 32f, 0f)));
            this.levelEditorButtons.Add(new Image(this.levelEditorScene.Game,
                                                     @"LevelEditorAssets\Button_save", this.position + new Vector2(17f * 32f, 0f)));

            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Block", this.position + new Vector2(10f * 32f, 0f)));//0            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Door", this.position + new Vector2(10f * 32f, 0f))); //2
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Wall1", this.position + new Vector2(10f * 32f, 0f)));//1
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Wall2", this.position + new Vector2(10f * 32f, 0f)));//2
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Block_hor", this.position + new Vector2(10f * 32f, 0f)));//3
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Block_vert", this.position + new Vector2(10f * 32f, 0f)));//4
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Lives", this.position + new Vector2(10f * 32f, 0f)));//5
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Potion", this.position + new Vector2(10f * 32f, 0f)));//6
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Scarab", this.position + new Vector2(10f * 32f, 0f)));//7
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Treasure1", this.position + new Vector2(10f * 32f, 0f)));//8
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorPictures\Treasure2", this.position + new Vector2(10f * 32f, 0f)));//9
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Beetle", this.position + new Vector2(10f * 32f, 0f)));//10
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Scorpion", this.position + new Vector2(10f * 32f, 0f)));//11
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\mummy", this.position + new Vector2(10f * 32f, 0f)));//12


            this.background = new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Panel", this.position);
        }

        //Forever Update
        public void Update(GameTime gameTime)
        {
            foreach (Image image in this.levelEditorButtons)
            {
                if (image.Rectangle.Intersects(Input.MouseRectangle()))
                {
                    int indexOfImage = this.levelEditorButtons.IndexOf(image);                    
                    if (Input.MouseEdgeDetectPressLeft())
                    {
                        switch (indexOfImage)
                        {
                            case 0:
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex > 1) ?
                                    this.levelEditorScene.LevelIndex -1 : 1;
                                this.levelEditorScene.LoadLevel();
                                break;
                            case 1:
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex < 9) ?
                                    this.levelEditorScene.LevelIndex + 1 : 9;
                                this.levelEditorScene.LoadLevel();
                                //this.levelEditorScene.Game.Exit();
                                break;
                            case 2:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex > 0) ?
                                    this.levelEditorAssetsIndex - 1 : 0;
                                break;
                            case 3:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex < this.levelEditorAssets.Count -1) ?
                                    this.levelEditorAssetsIndex + 1 : this.levelEditorAssets.Count - 1;
                                break;
                            case 4:
                                this.SaveGame();
                                break;
                            default:
                                break;
                        }
                        
                    }
                                
                }
            }
            if ((Input.MouseEdgeDetectPressLeft() || Input.MouseEdgeDetectPressRight()) &&
                Input.MousePosition().X < 640f &&
                Input.MousePosition().X > 0f &&
                Input.MousePosition().Y < 448f &&
                Input.MousePosition().Y > 0f)
            {
                if (this.levelEditorScene.Level.Explorer.Position != new Vector2(((int)Input.MousePosition().X / 32) * 32f, ((int)Input.MousePosition().Y / 32) * 32f))
                {
                    if (Input.MouseEdgeDetectPressRight())
                    {
                        RemoveAsset();
                    }
                        else
                        {
                            switch (this.levelEditorAssetsIndex)
                            {
                                case 0:
                                    this.PlaceBlock(@"Block", 'w');
                                    break;
                                case 1:
                                    this.PlaceBlock(@"Door", 'z');
                                    break;
                                case 2:
                                    this.PlaceBlock(@"Wall1", 'x');
                                    break;
                                case 3:
                                    this.PlaceBlock(@"Wall2", 'y');
                                    break;
                                case 5:
                                    this.PlaceBlock(@"Transparant", 'E');
                                    this.levelEditorScene.Level.Explorer = new Explorer(this.levelEditorScene.Game,
                                                                                        new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                                    ((int)Input.MousePosition().Y / 32) * 32f),
                                                                                        2.0f);
                                    break;
                                case 6:
                                    this.PlaceBlock(@"Transparant", 'c');
                                    this.levelEditorScene.Level.Treasures.Add(new Treasure('c',
                                                                                           this.levelEditorScene.Game,
                                                                                           @"PlaySceneAssets\Treasures\Potion",
                                                                              new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                          ((int)Input.MousePosition().Y / 32) * 32f)));
                                    break;
                                case 7:
                                    this.PlaceBlock(@"Transparant", 'd');
                                    this.levelEditorScene.Level.Treasures.Add(new Treasure('c',
                                                                                           this.levelEditorScene.Game,
                                                                                           @"PlaySceneAssets\Treasures\Scarab",
                                                                               new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                                                                           ((int)Input.MousePosition().Y / 32) * 32f)));
                                    break;
                                case 8:
                                    this.PlaceBlock(@"Transparant", 'a');
                                    this.levelEditorScene.Level.Treasures.Add(new Treasure('a',
                                                                                           this.levelEditorScene.Game,
                                                                                           @"PlaySceneAssets\Treasures\Treasure1",
                                                                              new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                          ((int)Input.MousePosition().Y / 32) * 32f)));
                                    break;
                                case 9:
                                    this.PlaceBlock(@"Transparant", 'b');
                                    this.levelEditorScene.Level.Treasures.Add(new Treasure('b',
                                                                                           this.levelEditorScene.Game,
                                                                                           @"PlaySceneAssets\Treasures\Treasure2",
                                                                              new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                          ((int)Input.MousePosition().Y / 32) * 32f)));
                                    break;
                                case 10:
                                    this.PlaceBlock(@"Transparant", 'B');
                                    this.levelEditorScene.Level.Beetles.Add(new Beetle(this.levelEditorScene.Game,
                                                                            new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                                                                       ((int)Input.MousePosition().Y / 32) * 32f),
                                                                                       2.0f));
                                    break;
                                case 11:
                                    this.PlaceBlock(@"Transparant", 'S');
                                    this.levelEditorScene.Level.Scorpions.Add(new Scorpion(this.levelEditorScene.Game,
                                                                            new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                                                                       ((int)Input.MousePosition().Y / 32) * 32f),
                                                                                       2.0f));
                                    break;
                            }
                        }
                    }
                }
            }

        private void PlaceBlock(string name, Char charItem)
        {
            this.levelEditorScene.Level.Blocks[(int)Input.MousePosition().X / 32, (int)Input.MousePosition().Y / 32] =
                           new Block(this.levelEditorScene.Game,
                                     name,
                                     new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                 ((int)Input.MousePosition().Y / 32) * 32f),
                                     BlockCollision.NotPassable,
                                     charItem);
        }

        private void AddTreasure(Char charItem, String name)
        { 
            this.levelEditorScene.Level.Treasures.Add(new Treasure(charItem,
                                                                   this.levelEditorScene.Game,
                                                                   name,
                                                                    new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                ((int)Input.MousePosition().Y / 32) * 32f)));
        }

        private void RemoveAsset()
        { 
            foreach (Scorpion scorpion in this.levelEditorScene.Level.Scorpions)
            {
                if (scorpion.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32f,((int)Input.MousePosition().Y / 32) * 32f))
                {
                    this.levelEditorScene.Level.Scorpions.Remove(scorpion);
                    break;
                }          
            }
            foreach (Beetle beetle in this.levelEditorScene.Level.Beetles)
            {
                if (beetle.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32f, ((int)Input.MousePosition().Y / 32) * 32f))
                {
                    this.levelEditorScene.Level.Beetles.Remove(beetle);
                    break;
                }
            }
            foreach (Treasure treasure in this.levelEditorScene.Level.Treasures)
            {
                if (treasure.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32f, ((int)Input.MousePosition().Y / 32) * 32f))
                {
                    this.levelEditorScene.Level.Treasures.Remove(treasure);
                    break;
                }
            }

            for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
            { 
                for(int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
                {
                    if (this.levelEditorScene.Level.Blocks[i, j].Position ==
                        new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                    ((int)Input.MousePosition().Y / 32) * 32f))
                    {
                        this.PlaceBlock("Transparant", '.');
                    }
                }
            }
        }

        private void SaveGame()
        {
            StreamWriter writer = new StreamWriter(new FileStream(this.levelEditorScene.Level.LevelPath,
                                                                  FileMode.Open,
                                                                  FileAccess.Write));
            string line = "";
            List<string> lines;
            lines = new List<string>();
            for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
                {
                    line += this.levelEditorScene.Level.Blocks[i, j].CharItem;
                }
                lines.Add(line);
                writer.WriteLine(line);
                line = "";
            }

            writer.Close();
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            foreach (Image image in this.levelEditorButtons)
            {
                image.Draw(gameTime);
            }
            this.levelEditorAssets[levelEditorAssetsIndex].Draw(gameTime);
            float levelIndexOffset = (levelEditorScene.LevelIndex > 9) ? 3.4f : 3.7f;
            this.levelEditorScene.Game.SpriteBatch.DrawString(this.Arial, this.levelEditorScene.LevelIndex.ToString(), this.position + new Vector2(levelIndexOffset * 32f, -3f),Color.Yellow);
        }
    }
}
