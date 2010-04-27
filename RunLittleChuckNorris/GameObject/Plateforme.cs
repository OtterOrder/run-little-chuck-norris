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
    public class Plateforme : Obstacle
    {
        #region Private members

        float m_height = 2;
        float m_width = 10;

        #endregion

        public Plateforme(Game game)
            : base(game)
        {
            Sprite = new Helper.Sprite("Graphics/Sprites/Plateforme", game.Content);

            Helper.IWorldProvider worldProvider = (Helper.IWorldProvider)Game.Services.GetService(typeof(Helper.IWorldProvider));
            worldProvider.Plateformes.Add(this);
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        #region Properties

        public float Height
        {
            get { return m_height; }
            set 
            { 
                m_height = value;
                Sprite.Scale = new Vector2(m_width, m_height);
            }
        }

        public float Width
        {
            get { return m_width; }
            set 
            { 
                m_width = value;
                Sprite.Scale = new Vector2(m_width, m_height);
            }
        }

        #endregion
    }
}