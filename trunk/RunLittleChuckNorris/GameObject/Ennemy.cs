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
    public class Ennemy : Obstacle
    {
        private float m_fireRate;
        private float m_timeSinceLastShot;
        private Helper.IWorldProvider m_worldProvider;

        public Ennemy(Game game)
            : base(game)
        {
            Sprite = new Helper.Sprite("Graphics/Sprites/Enemy", Game.Content, 2, 4);
            Sprite.Loop = false;
            Sprite.Play = false;
            Sprite.Origin = new Vector2(Sprite.Width/2, Sprite.Height);
            m_fireRate = 1200.0f;
            m_timeSinceLastShot = 0.0f;

            m_worldProvider = (Helper.IWorldProvider)game.Services.GetService(typeof(Helper.IWorldProvider));

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            if (m_worldProvider.IsFreezed)
                return;

            m_timeSinceLastShot += gameTime.ElapsedGameTime.Milliseconds;
            if(m_timeSinceLastShot >= m_fireRate)
            {
                Sprite.Play = true;
                Sprite.Restart();
                m_timeSinceLastShot = 0.0f;

                Bullet b = new Bullet(Game);
                b.X = this.X;
                b.Y = this.Y - (Sprite.Height - b.Sprite.Height) / 2;
            }
        }
        
        #region Properties

        public float FireRate
        {
            get { return m_fireRate; }
            set { m_fireRate = value; }
        }

        #endregion
    }
}