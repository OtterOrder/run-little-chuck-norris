using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RunLittleChuckNorris.Helper
{
    public class Background
    {
        public static SpriteBatch SprBatch = null;
        public static int BackBufferWidth = 0;
        public static int BackBufferHeight = 0;

        private Texture2D _mBg = null;

        public Vector2 Scale = new Vector2(1.0f, 1.0f);
        private float _mDepth = 1.0f;

        public Vector2 Speed = Vector2.Zero;
        private Vector2 _mPosition = Vector2.Zero;

        //-------------------------------------------------------------------------
        public Background(string _FileName, ContentManager _ContentManager)
        {
            _mBg = _ContentManager.Load<Texture2D>(_FileName);
        }

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
            set { _mDepth = value; }
        }

        //-------------------------------------------------------------------------
        public void Update(float _Dt)  // MilliSeconds
        {
            _mPosition += Speed * _Dt;
        }

        //-------------------------------------------------------------------------
        public void Draw()
        {
            Rectangle Rect = new Rectangle((int)_mPosition.X, (int)_mPosition.Y, BackBufferWidth, BackBufferHeight);

            SprBatch.Draw(_mBg, Vector2.Zero, Rect, Color.White, 0, Vector2.Zero, Scale, SpriteEffects.None, _mDepth);
        }
    }
}