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

namespace Iguana
{
    class Stage
    {
        private Texture2D stageImage;
        

        public Stage(string imageName, ContentManager content)
        {
            stageImage = content.Load<Texture2D> (imageName);
        }

        public void draw(SpriteBatch create)
        {
            create.Draw(stageImage, Vector2.Zero, Color.White);
        }
    }
}
