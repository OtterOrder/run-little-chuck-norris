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
    public class GameObject : Microsoft.Xna.Framework.DrawableGameComponent
    {

        // Private members
        Helper.Sprite m_sprite;
        int m_x;
        int m_y;


        public GameObject(Game game)
            : base(game)
        {
            m_sprite = new Helper.Sprite();
            m_x = 0;
            m_y = 0;
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

        int X
        {
            get { return m_x; }
            set { m_x = value; }
        }

        int Y
        {
            get { return m_y; }
            set { m_y = value; }
        }

        Helper.Sprite Sprite
        {
            get { return m_sprite; }
        }

        #endregion
    }
}