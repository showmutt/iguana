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
    public class Sprite
    {
        private Texture2D sprite;
        private int numCols;
        private int numRows;
        private int height;//this is for optimal reasons having an additional int is not that much extra memory, and it is faster then havign to calculate the height time. This is the height of  a frame
        private int width;
        private int currentCol=0;
        private int currentRow=0;

        public Sprite(ContentManager content, String imageName, int cols, int rows)
        {
            sprite = content.Load<Texture2D>(imageName);
            width = sprite.Width / cols;
            height = sprite.Width / cols;
            numCols = cols;
            numRows = rows;
        }
        public void update()
        {
            setCurrentCol(currentCol + 1);
            if (currentCol >= numCols)
            {
                currentCol = 0;
            }
        }
        public void setCurrentCol(int pos)
        {
            currentCol = pos;
        }
        public void setCurrentRow(int pos)
        {
            currentRow = pos;
        }
        public void draw(Vector2 pos, SpriteBatch batch)
        {
            //Optimize: we are declaring and initing these rect every draw, thats alot of work we can make it better later
            Rectangle dest = new Rectangle((int)(pos.X), (int)(pos.Y), width, height);
            Rectangle src = new Rectangle(currentCol * width, currentRow * height, width, height);
            batch.Draw(sprite, dest, src, Color.White);
        }
    }
}
