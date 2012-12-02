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
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class BattleScene : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public List<Fighter> fighters = new List<Fighter>();
        public Stage stage;
        public List<Projectile> projectiles = new List<Projectile>();
        Texture2D barBorder;         // empty white graphic with border
        Texture2D barFill;          // bar fill graphic, modified by Color class to be the appropriate color
        Projectile flags;
        public int h;
        public int w;
        //Projectile 

        public BattleScene()
        {

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Fighter f = new Fighter(@"images/square", Content, 1, 1, "fighter one");
            Fighter f2 = new Fighter(@"images/square2", Content, 1, 1, "fighter two");
            fighters.Add(f);
            fighters.Add(f2);
            //load projectile base;
            stage = new Stage(@"images/CurtainsPix1", Content);

            barBorder = Content.Load<Texture2D>(@"images/barBorder");
            barFill = Content.Load<Texture2D>(@"images/barFill");

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                //this.Exit();
            }
            h=GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            w=GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].update();
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                for (int j = 0; j < fighters.Count; j++)
                {
                    if(collision(projectiles[i],fighters[j]))
                    {
                        fighters[j].takeDamage(projectiles[i].damage);
                        //do push back
                    }
                }
            }
            for (int i = 0; i < this.fighters.Count; i++)
            {
                for (int j = 0; j < this.fighters.Count; j++)
                {
                    if (collision(fighters[i], fighters[j]))
                    {
                        if (i != j)
                        {
                            if (this.fighters[i].punchMode)
                            {
                                this.fighters[j].takeDamage(this.fighters[i].power);
                            }
                            if (this.fighters[i].specailOn)
                            {
                                if (fighters[i].specail == "Bearception")
                                {
                                    fighters[i].power ++;
                                }
                                if (fighters[i].specail == "Polish Freedom")
                                {
                                    Random r = new Random();
                                    for (int f = 0; f < 15; f++)
                                    {
                                        Projectile t = flags;
                                        t.pos.X = r.Next(0, w);
                                        t.pos.Y = r.Next(0, h);
                                        t.yIncrease = -7;
                                        projectiles.Add(t);
                                    }
                                }
                            }
                            if (this.fighters[i].rightLeftOn)
                            {
                                //right
                            }
                            if (this.fighters[i].downOn)
                            {
                                if (fighters[i].down == "Guitar Smash")
                                {
                                    fighters[j].takeDamage(7);
                                }
                                if (fighters[i].down == "Guitar Smash")
                                {
                                    Random r = new Random();
                                    for (int f = 0; f < 5; f++)
                                    {
                                        Projectile t = flags;
                                        t.pos.X = r.Next(0, w);
                                        t.pos.Y = r.Next(0, h);
                                        t.yIncrease = 3;
                                        projectiles.Add(t);
                                    }
                                }
                            }
                            if (this.fighters[i].upOn)
                            {
                                if (fighters[i].up == "Peer Scanner")
                                {
                                    this.fighters[i].upOn = false;
                                    fighters[i].up=fighters[j].up;
                                }
                                if (fighters[i].up == "Primal Scream")
                                {
                                    fighters[i].takeDamage(2);
                                    fighters[i].gainFatigue(3);
                                }
                            }
                        }
                    }
                }
            }
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            stage.draw(spriteBatch);
            float lowX;
            float highX;
            float lowY;
            float highY;

            lowX = fighters[0].pos.X;
            highX = fighters[0].pos.X;
            lowY = fighters[0].pos.Y;
            highY = fighters[0].pos.Y;
            for (int i = 0; i < fighters.Count; i++)
            {
                if (lowX > fighters[i].pos.X)
                {
                    lowX = fighters[i].pos.X;
                }
                if (highX > fighters[i].pos.X)
                {
                    lowX = fighters[i].pos.X;
                }
                if (lowY > fighters[i].pos.Y)
                {
                    lowY = fighters[i].pos.Y;
                }
                if (highY > fighters[i].pos.Y)
                {
                    lowY = fighters[i].pos.Y;
                }
            }

            for (int i = 0; i < projectiles.Count; i++)
            {
            }

            for (int i = 0; i < fighters.Count; i++)
            { 
            drawBar(i * 200, 0, Color.Red, Color.Wheat, fighters[i].health);
            fighters[i].draw(spriteBatch);
            }
            for (int i = 0; i < projectiles.Count; i++)
            {
                projectiles[i].draw(spriteBatch);
            }
            
            spriteBatch.End();
            base.Draw(gameTime);
        }
        public bool collision(SceneObject obj1, SceneObject obj2)
        {
            Rectangle r1 = obj1.sprite.getCollisionBox(obj1.pos);
            Rectangle r2 = obj2.sprite.getCollisionBox(obj2.pos);
            return r1.Contains(r2);
        }
        public void drawBar(int x, int y, Color healthColor, Color fatigueColor, double value)
        {
            Rectangle border;                 // Rectangle that controls the border
            Rectangle healthRect;             // Rectangle that controls how much of the health bar is filled
            Rectangle fatigueRect;            // Rectangle that controls how much of the fatigue bar is filled
            float barValue;

            barValue = (float)(value / 100);

            border = new Rectangle(x, y, 200, 50);
            healthRect = new Rectangle(x + 2, y + 2, (int)(value * 2), 46);
            fatigueRect = new Rectangle(x + 2, y + 23, (40 * 2), 25);

            
            spriteBatch.Draw(barFill, healthRect, healthColor);
            spriteBatch.Draw(barFill, fatigueRect, fatigueColor);
            
        }




    }
}
