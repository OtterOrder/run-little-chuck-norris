using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Coeur
{
    public class Background
    {
        #region Private Members

        private Texture2D   _mBg = null;

        private Vector2     _mScale = new Vector2(1.0f, 1.0f);
        private float       _mDepth = 1.0f;

        private Vector2     _mSpeed = Vector2.Zero;
        private Vector2     _mPosition = Vector2.Zero;

        #endregion

        #region Constructor

        //-------------------------------------------------------------------------
        public Background(string _FileName, ContentManager _ContentManager)
        {
            _mBg = _ContentManager.Load<Texture2D>(_FileName);
        }

        #endregion

        #region Public Properties
        //-------------------------------------------------------------------------
        public int Height
        {
            get { return _mBg.Height; }
        }

        public int Width
        {
            get { return _mBg.Width; }
        }

        public float Depth
        {
            get { return _mDepth; }
            set { _mDepth = value; SceneManager.Singleton.SortBackgrounds(); }
        }

        public Vector2 Scale
        {
            get { return _mScale; }
            set { _mScale = value; }
        }

        public Vector2 Speed
        {
            get { return _mSpeed; }
            set { _mSpeed = value; }
        }

        #endregion

        #region Public Methods
        //-------------------------------------------------------------------------
        public void Update(float _Dt)  // MilliSeconds
        {
            _mPosition += _mSpeed * _Dt;
        }

        //-------------------------------------------------------------------------
        public void Draw(SpriteBatch _SprBatch)
        {
            Rectangle Rect = new Rectangle((int)_mPosition.X, (int)_mPosition.Y, CoeurGame.mBackBufferWidth, CoeurGame.mBackBufferHeight);

            _SprBatch.Draw(_mBg, Vector2.Zero, Rect, Color.White, 0, Vector2.Zero, _mScale, SpriteEffects.None, _mDepth);
        }
        #endregion
    }
}