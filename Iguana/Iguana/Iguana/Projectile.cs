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
    public class Projectile: SceneObject
    {
        public int xIncrease = 0;
        public int yIncrease = 0;
        public int damage = 0;
        public int push = 0;
        public Projectile(string imageName, ContentManager content, int c, int r)
        {
            loadSprite(imageName, content, c, r);
        }

        public void update()
        {
            this.pos.X += xIncrease;
            this.pos.Y += yIncrease;
        }
    }
}
