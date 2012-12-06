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
   public class Stage
    {
        private Texture2D stageImage;
        

        public Stage(string imageName, ContentManager content)
        {
            stageImage = content.Load<Texture2D> (imageName);
        }

        public void draw(SpriteBatch create, int xR, int yR, int xO, int yO)
        {
            //Rectangle src = new Rectangle(0, 0, this.stageImage.Height, stageImage.Width);
            Rectangle dest = new Rectangle(0 -xO, 0 - yO, xR*1000, yR*1000);
            //dest=new Rectangle(0-xR,0-yR,stageImage.
            create.Draw(stageImage, dest, Color.White);
        }
    }
}
