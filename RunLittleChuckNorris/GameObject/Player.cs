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
        private float m_distance;

        public Player(Game game, String spriteName)
            : base(game)
        {
            this.Sprite = new Helper.Sprite("Player", this.Game.Content, 4, 4);
            this.Sprite.Loop = true;
            m_speed = 5.0f;
            m_distance = 0.0f;
            X = 20.0f;
            Y = 500.0f;
        }

        #region Properties

        public float Speed
        {
            get { return m_speed; }
            set { m_speed = value; }
        }

        public float DistanceParcourue
        {
            get { return m_distance; }
            set { m_distance = value; }
        }

        #endregion

    }
}