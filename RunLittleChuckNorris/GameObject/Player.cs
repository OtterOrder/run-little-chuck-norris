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
        private bool isJumping;

        public Player(Game game, String spriteName)
            : base(game)
        {
            collisionManager = new Helper.CollisionManager();
            this.Sprite = new Helper.Sprite("Graphics/Sprites/"+spriteName, this.Game.Content, 4, 4);
            this.Sprite.Loop = true;
            Sprite.Origin = new Vector2(Sprite.Width / 2, Sprite.Height);
            m_speed = 5.0f;
            X = 20.0f;
            Y = 500.0f;
            isJumping = false;
        }

        public void Init()
        {
            m_speed = 5.0f;
            X = 20.0f;
            Y = 500.0f;
            isJumping = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            float speedx = m_speed;
            float speedy = 0;
            Plateforme p;
            // is colliding Plateforme
            p = null;// collisionManager.CollidePlateforme(this);
            if (p != null)
            {
                // under ?
                if (X >= p.X && Y > p.Y)
                {
                    // suppress speedy
                    speedy = 0;
                    // is jump requested
                }
                else
                {
                    // forward ?
                    if (X < p.X && Y > p.Y)
                    {
                        // suppress speedx
                        speedx = 0;
                    }
                    else
                    {
                        if(X >= p.X && Y <= p.Y)
                        {
                            speedy = 0;
                        }
                    }
                }

            }
            // is colliding Obstacle ?
            /*if (collisionManager.collideObstacle(this) != null)
            {
                // dead
                Game.Services.GetService(Helper.IGameOver).GameOver();
            }*/

            // is jumping ?
                // modify speedy
            

            // apply change on player position
            X += speedx;
            Y += speedy;
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

        #endregion

    }
}