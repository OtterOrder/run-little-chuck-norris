﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RunLittleChuckNorris.Helper
{
    public class Sprite
    {
        //
        private Texture2D       _mSpr = null;
        private int             _mWidth;

        private Vector2         _mPosition = Vector2.Zero;
        private Vector2         _mOrigin = Vector2.Zero;
        private Vector2         _mScale = new Vector2(1.0f, 1.0f);
        private float           _mDepth = 1.0f;
        public SpriteEffects    Flip = SpriteEffects.None;

        public bool             Visible = true;

        // Animation
        private UInt32          _mNbFrames = 0;

        private float           _mFps = 0.0f;
        private float           _mTime = 0.0f;

        private float           _mSpeed = 1.0f;
        private int             _mState = (int)Sprite.AnimState.Play;

        private int             _mCurrentFrame = 0;

        private bool            _mAnimated = false;

        enum AnimState
        {
            Play = 1,
            Loop = 1 << 1,
            AtEnd = 1 << 2
        }

        public Sprite(string _FileName, ContentManager _ContentManager)
        {
            _mSpr = _ContentManager.Load<Texture2D>(_FileName);
            _mWidth = _mSpr.Width;
        }

        public Sprite(string _FileName, ContentManager _ContentManager, UInt32 _NbFrames, float _Fps)
        {
            _mSpr = _ContentManager.Load<Texture2D>(_FileName);

            _mNbFrames = _NbFrames;
            _mFps = _Fps;

            if (_mFps == 0)
                _mState = 0;

            _mWidth = _mSpr.Width / (int)_mNbFrames;

            if (_mNbFrames > 0)
                _mAnimated = true;
        }

        public Vector2 Position
        {
            get { return _mPosition; }
            set { _mPosition = value; }
        }

        public Vector2 Origin
        {
            get { return _mOrigin; }
            set { _mOrigin = value; }
        }

        public Vector2 Scale
        {
            get { return _mScale; }
            set { _mScale = value; }
        }

        public int Height
        {
            get { return _mSpr.Height; }
        }

        public int Width
        {
            get { return _mWidth; }
        }

        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
        }

        public float Depth
        {
            get { return _mDepth; }
            set { _mDepth = value; }
        }

        public UInt32 NbFrames
        {
            get { return _mNbFrames; }
        }

        public float Fps
        {
            get { return _mFps; }
        }

        public float Speed
        {
            get { return _mSpeed; }
            set { _mSpeed = value; }
        }

        public bool Loop
        {
            get { return ((_mState & (int)Sprite.AnimState.Loop) == (int)Sprite.AnimState.Loop); }

            set
            {
                if (value)
                    _mState = _mState | (int)Sprite.AnimState.Loop;
                else
                    _mState = _mState & ~(int)Sprite.AnimState.Loop;
            }
        }

        public bool Play
        {
            get { return ((_mState & (int)Sprite.AnimState.Play) == (int)Sprite.AnimState.Play); }

            set
            {
                if (value)
                    _mState = _mState | (int)Sprite.AnimState.Play;
                else
                    _mState = _mState & ~(int)Sprite.AnimState.Play;
            }
        }

        public bool AtEnd
        {
            get { return ((_mState & (int)Sprite.AnimState.AtEnd) == (int)Sprite.AnimState.AtEnd); }

            set
            {
                if (value)
                    _mState = _mState | (int)Sprite.AnimState.AtEnd;
                else
                    _mState = _mState & ~(int)Sprite.AnimState.AtEnd;
            }
        }

        public int CurrentFrame
        {
            get { return _mCurrentFrame; }
            set { _mCurrentFrame = Math.Min(Math.Max(value, 0), (int)_mNbFrames - 1); _mTime = (float)_mCurrentFrame / _mFps; }
        }

        public void Restart()
        {
            _mCurrentFrame = 0;
            _mTime = 0.0f;
            AtEnd = false;
        }

        public void Update(float _Dt)  // MilliSeconds
        {
            if (!Play || !_mAnimated)
                return;

            AtEnd = false;

            _mTime += _Dt * _mSpeed / 1000.0f;
            _mCurrentFrame = (int)(_mTime * _mFps);

            if (_mCurrentFrame >= _mNbFrames)
            {
                AtEnd = true;

                if (Loop)
                {
                    _mTime = 0.0f;
                    _mCurrentFrame = 0;
                }
                else
                {
                    _mCurrentFrame = (int)(_mNbFrames - 1);
                }
            }
            else
            if (_mCurrentFrame < 0)
            {
                AtEnd = true;

                if (Loop)
                {
                    _mTime = (float)(_mNbFrames - 1) / _mFps;
                    _mCurrentFrame = (int)(_mNbFrames - 1);
                }
                else
                {
                    _mCurrentFrame = 0;
                }
            }
        }

        public void Draw(SpriteBatch _SprBatch)
        {
            Rectangle Rect = new Rectangle(_mCurrentFrame * _mWidth, 0, _mWidth, Height);

            _SprBatch.Draw(_mSpr, Position, Rect, Color.White, 0, Origin, Scale, Flip, _mDepth);
        }
    }
}
