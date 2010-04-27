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
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;


namespace RunLittleChuckNorris.GameObject
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class Player : GameObject
    {
        private float m_speed;
        private Helper.CollisionManager collisionManager;
        private float currentJumpHeight;
        private float minJumpHeight;
        private float maxJumpHeight;
        private bool isJumping;
        private float m_bestDistance;
        private Helper.IWorldProvider m_worldProvider;

        private float gravity;
        private float speedy;
        private float speedyMax;

        public Player(Game game, String spriteName)
            : base(game)
        {
            collisionManager = new Helper.CollisionManager(game);
            this.Sprite = new Helper.Sprite("Graphics/Sprites/"+spriteName, this.Game.Content, 4, 4);
            this.Sprite.Loop = true;
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height);
            m_speed = 0.0f;
            X = 20.0f;
            Y = 0.0f;
            isJumping = false;
            currentJumpHeight = 0.0f;
            minJumpHeight = 150.0f;
            maxJumpHeight = 300.0f;
            m_bestDistance = 0;
            speedyMax = 30.0f;

            m_worldProvider = (Helper.IWorldProvider)game.Services.GetService(typeof(Helper.IWorldProvider));
        }

        public void Init()
        {
            m_speed = 10.0f;
            X = 20.0f;
            Y = 490.0f;
            isJumping = false;
            currentJumpHeight = 0.0f;
            speedy = speedyMax;
            gravity = 1.0f;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (m_worldProvider.IsFreezed)
                return;

            float speedx = m_speed;

            speedy += gravity;
            if (speedy < -speedyMax)
            {
                speedy = -speedyMax;
            }
            if (speedy > 20)
            {
                speedy = 20;
            }


            // apply change on player position
            X += speedx;
            Y += speedy;

            Plateforme p;
            // is colliding Plateforme
            p = (Plateforme)collisionManager.CollidePlatform(this);

            if (p != null)
            {
                // under ? 
                if (X + Sprite.Width / 2 >= p.X && Y > p.Y && speedy < 0)
                {
                    // suppress speedy
                    //speedy = 0;
                    // is jump requested
                }
                else
                {
                    // forward ?
                    if (X + Sprite.Width / 2 < p.X && Y > p.Y)
                    {
                        // suppress speedx
                        speedx = 0;
                    }
                    else
                    {
                        //over ?
                        if (X + Sprite.Width / 2 >= p.X && Y <= p.Y + p.Height)
                        {
                            Y = p.Y;
                            //jump
                            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                            {
                                speedy = -speedyMax;
                            }
                            //currentJumpHeight = 0.0f;
                           // isJumping = false;
                        }
                    }
                }

            }

            // is colliding Obstacle ?
            if (collisionManager.CollideObstacle(this) != null || Y > 800)
            {
                // dead
                ((Helper.IGameOver)Game.Services.GetService(typeof(Helper.IGameOver))).GameOver();
            }

        }

        #region Properties

        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        public float DistanceParcourue
        {
            get { return X; }
            set { X = value; }
        }

        public float BestDistance
        {
            get { return m_bestDistance; }
            set { m_bestDistance = value; }
        }

        #endregion

    }
}