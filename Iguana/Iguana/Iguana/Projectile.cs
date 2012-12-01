using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iguana
{
    public class Projectile: SceneObject
    {
        public int xIncrease = 0;
        public int yIncrease = 0;
        public int damage = 0;
        public int push = 0;
        public void update()
        {
            this.pos.X += xIncrease;
            this.pos.Y += yIncrease;
        }
    }
}
