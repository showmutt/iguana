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
        public PlayerIndex gamePadIndex=0;
        public KeyboardState ks = Keyboard.GetState();
        public GamePadState gps = GamePad.GetState(0);
        public KeyboardState pks = Keyboard.GetState();
        public GamePadState pgps = GamePad.GetState(0);
        public bool useKeyBoard=false;
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
            this.pos.X--;
        }
        public void moveRight()
        {
            this.pos.X++;
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
        public void update()
        {

            base.update();
            punchMode = false;
            pks=ks;
            pgps=gps;
            ks=Keyboard.GetState();
            gps=GamePad.GetState(this.gamePadIndex);
            if (isAsleep)
            {
                loseFatigue(.25f);
                count++;
            }
            else if (useKeyBoard)
            {
                if (ks.IsKeyDown(Keys.Right))
                {
                        moveRight();
                }
                if (ks.IsKeyDown(Keys.Left))
                {
                    moveLeft();
                }
                if (ks.IsKeyDown(Keys.F))
                {
                    this.gainFatigue(.01f);

                    punch();
                }
            }
            else
            {
            }

        }
    }
}
