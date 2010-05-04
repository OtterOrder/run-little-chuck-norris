using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Coeur
{
    public class Camera
    {
        #region Private Members
        private Viewport    _mViewport;

        private Vector2     _mPosition;
        private Vector2     _mScreenCenter;

        private float       _mBackBufferWidth;
        private float       _mBackBufferHeight;

        private Vector2      _mFocus;
        private Matrix       _mTransform;
        private float        _mSpeed;
        #endregion

        #region Constructor

        public Camera()
        {
            _mViewport.Width = 800;
            _mViewport.Height = 600;
            _mViewport.X = 0;
            _mViewport.Y = 0;
            _mScreenCenter = new Vector2(_mViewport.Width / 2, _mViewport.Height / 2);

            _mBackBufferWidth = CoeurGame.mBackBufferWidth;
            _mBackBufferHeight = CoeurGame.mBackBufferHeight;

            _mFocus = new Vector2(0, 0);

            _mSpeed = 0.01f;
        }

        #endregion

        #region Public Properties

        public Vector2 Position
        {
            get { return _mPosition; }
            set { _mPosition = value; _mFocus = _mPosition; }
        }

        public Vector2 Focus
        {
            get { return _mFocus; }
            set { _mFocus = value; }
        }

        public Matrix Transform
        {
            get { return _mTransform; }
            set { _mTransform = value; }
        }

        public float Speed
        {
            get { return _mSpeed; }
            set { _mSpeed = value; }
        }

        #endregion

        #region Public Methods

        public void SetViewportParam(float _PosX, float _PosY, float _Width, float _Height)
        {
            _mViewport.Width = (int)(_Width * _mBackBufferWidth);
            _mViewport.Height = (int)(_Height * _mBackBufferHeight);
            _mViewport.X = (int)(_PosX * _mBackBufferWidth);
            _mViewport.Y = (int)(_PosY * _mBackBufferHeight);
            _mScreenCenter = new Vector2(_mViewport.Width / 2, _mViewport.Height / 2);
        }

        public void Update(float _Dt)
        {
            _mTransform = Matrix.Identity *
                          Matrix.CreateTranslation(-_mPosition.X, -_mPosition.Y, 0);

            if (_mFocus.X != 0 && _mFocus.Y != 0)
                _mTransform *= Matrix.CreateTranslation(_mScreenCenter.X, _mScreenCenter.Y, 0);


            _mPosition.X += (int)((_mFocus.X - _mPosition.X) * _mSpeed * _Dt);
            _mPosition.Y += (int)((_mFocus.Y - _mPosition.Y) * _mSpeed * _Dt);
        }

        public void SetCamera(GraphicsDeviceManager _GraphicsManager)
        {
            _GraphicsManager.GraphicsDevice.Viewport = _mViewport;
        }

        #endregion
    }
}