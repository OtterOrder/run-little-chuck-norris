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
        float m_x;
        float m_y;


        public GameObject(Game game) : base(game)
        {
            m_x = 0;
            m_y = 0;

            UpdateOrder = int.Parse(Properties.Resources.GAMEOBJECT_PRIORITY);
            game.Components.Add(this);
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
            if (Sprite != null)
            {
                Sprite.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
            }

            // remove the gameobject when the camera has passed by
            if (GameComponents.LevelManager.GetCurrentCam().MinX > (X + (Sprite.Width * Sprite.Scale.X)))
            {
                Game.Components.Remove(this);
                this.Dispose();
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);

            if (Sprite != null)
            {
                // ask the sprite to be drawed based on camera properties
                Sprite.Draw();
            }
        }

        #region Private Methods

        void UpdateSprite()
        {
            if (Sprite != null)
            {
                m_sprite.Position = new Vector2(m_x, m_y);
            }
        }

        #endregion 

        #region Properties

        public float X
        {
            get { return m_x; }
            set 
            { 
                m_x = value;
                UpdateSprite();
            }
        }

        public float Y
        {
            get { return m_y; }
            set 
            { 
                m_y = value;
                UpdateSprite();
            }
        }

        public Helper.Sprite Sprite
        {
            get { return m_sprite; }
            set 
            { 
                m_sprite = value;
                UpdateSprite();
            }
        }

        #endregion
    }
}