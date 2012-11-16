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


        //Constructor wordt eenmaal aangeroepen
        static Input()
        {
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

        public static bool MouseEdgeDetectPressRight()
        {
            return (ms.RightButton == ButtonState.Pressed && oms.RightButton == ButtonState.Released);
        }

    }
}
