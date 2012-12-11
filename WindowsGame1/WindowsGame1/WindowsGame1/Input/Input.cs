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
    public static class Input
    {
        //Fields
        private static KeyboardState ks, oks;
        private static MouseState ms, oms;
        private static Rectangle mouseRectangle; 


        //Constructor wordt eenmaal aangeroepen
        static Input()
        {
            mouseRectangle = new Rectangle(0, 0, 1, 1);
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
            oks = ks;
            oms = ms;
        }
        //Update method
        public static void Update()
        {
            oks = ks;
            oms = ms;
            ks = Keyboard.GetState();
            ms = Mouse.GetState();
        }

        //Leveldetector voor voor het toetsenbord
        public static bool DetectKeyDown(Keys key)
        {
            return ks.IsKeyDown(key);
        }

        //leveldetector voor het loslaten van de toetsen
        public static bool DetectKeyUp(Keys key)
        {
            return ks.IsKeyUp(key);
        }

        //Edgedetectfor voor de toetsenbordknoppen
        public static bool EdgeDetectKeyDown(Keys key)
        {
            return (ks.IsKeyDown(key) && oks.IsKeyUp(key));
        }
        
        //Edgedetector voor linksklik van muis
        public static bool MouseEdgeDetectPressLeft()
        {
            return (ms.LeftButton == ButtonState.Pressed && oms.LeftButton == ButtonState.Released);
        }
        //Edgedetector voor rechtsklik van muis
        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }
        //Positie van de muis
        public static Vector2 MousePosition()
        {
            return new Vector2(ms.X, ms.Y);
        }

        //positie van de rectangle
        public static Rectangle MouseRectangle()
        {
            mouseRectangle.X = ms.X;
            mouseRectangle.Y = ms.Y;
            return mouseRectangle;
        }
    }
}
