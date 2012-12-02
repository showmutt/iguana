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
    public class Fighter : SceneObject
    {
        private String Name;
        public double health = 100.00f;
        public double fatigue = 0.00f;
        public bool isAsleep = false;
        public bool ko = false;
        public int power = 1;
        public int basicPush = 1;
        public int hold = 10;
        public int count = 0;
        public KeyboardState pks = Keyboard.GetState();
        public GamePadState pgps = GamePad.GetState(0);
        public int groundLevel;
        public bool punchMode = false;
        public string specail = "";
        public bool specailOn = false;
        public string up = "";
        public bool upOn = false;
        public string down = "";
        public bool downOn = false;
        public string rightLeft = "";
        public bool rightLeftOn = false;

        public Fighter()
        {
        }
        public Fighter(string imageName, ContentManager content, int c, int r, string name)
        {
            
            loadSprite(imageName, content, c, r);
        }
        public void takeDamage(double power)
        {
            health -= power;
            if (health <= 0.0000000f)
            {
                ko = false;
            }
        }


        public void gainFatigue(double amount)
        {
            fatigue += amount;
            if (fatigue >= 100.00f)
            {
                isAsleep = true;
            }
        }
        public void loseFatigue(double amount)
        {
            fatigue -= amount;
            if (fatigue <= 50.0f)
            {
                isAsleep = false;
            }
        }
        public void moveLeft()
        {
        }
        public void moveRight()
        {
        }
        public void jump()
        {
            pos.Y += 10;
        }
        public void punch()
        {
            punchMode = true;
        }
        public bool isOnGround()
        {
            if (pos.Y > groundLevel)
            {
                pos.Y++;
                return false;
            }
            else
            {
                return true;
            }
        }
        public bool isOnPlatform()
        {
            return false;//modify or remove later just a place holder for now
        }
        public void update(KeyboardState ks)
        {
            base.update();
            punchMode = false;
            if (pos.Y > groundLevel)
            {
                pos.Y++;
            }
            if (isAsleep)
            {
                loseFatigue(.25f);
            }
            else
            {
                if (ks.IsKeyDown(Keys.Right))
                {
                    if (pks.IsKeyDown(Keys.Right))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        moveRight();
                    }
                }
                else if (ks.IsKeyDown(Keys.Left))
                {
                    if (pks.IsKeyDown(Keys.Left))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        moveLeft();
                    }
                }
                else if (ks.IsKeyDown(Keys.Up))
                {
                    if (pks.IsKeyDown(Keys.Up))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        jump();
                    }
                }
                else if (ks.IsKeyDown(Keys.F))
                {
                    if (pks.IsKeyDown(Keys.F))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        punch();
                    }
                }
                //if (ks.IsKeyDown(Keys.
            }
            pks = ks;
        }
        public void update(GamePadState gps)
        {
            base.update();
            punchMode = false;
            if (pos.Y > groundLevel)
            {
                pos.Y++;
            }
            if (isAsleep)
            {
                loseFatigue(.25f);
            }
            else
            {
                if (gps.DPad.Right == ButtonState.Pressed)
                {
                    if (pgps.DPad.Right == ButtonState.Pressed)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        moveRight();
                    }
                }
                else if (gps.DPad.Left == ButtonState.Pressed)
                {
                    if (pgps.DPad.Left == ButtonState.Pressed)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        moveLeft();
                    }
                }
                else if (gps.DPad.Up == ButtonState.Pressed)
                {
                    if (gps.DPad.Up == ButtonState.Pressed)
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        jump();
                    }
                }
                else if (gps.IsButtonDown(Buttons.X))
                {
                    if (pgps.IsButtonDown(Buttons.X))
                    {
                        count++;
                    }
                    else
                    {
                        count = 0;
                    }
                    if (count <= hold)
                    {
                        punch();
                    }
                }
                //if (ks.IsKeyDown(Keys.
            }
            pgps = gps;
        }
    }
}
