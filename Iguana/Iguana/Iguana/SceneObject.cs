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
    public class SceneObject
    {
        public Sprite sprite;
        public Vector2 pos;

        public SceneObject()
        {

        }
        public SceneObject(string imageName, ContentManager content, int c, int r)
        {
            loadSprite(imageName, content, c, r);
        }

        public void loadSprite(String imageName, ContentManager content, int c, int r)
        {
            sprite = new Sprite(content, imageName, c, r);
        }

        public virtual void update()
        {
            sprite.update();
        }

        public virtual void draw(SpriteBatch sb)
        {
            sprite.draw(pos, sb);
        }
    }
}
