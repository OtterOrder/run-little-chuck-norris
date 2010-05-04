using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace Coeur
{
    //-------------------------------------------------------------------------
    //-------------------------------------------------------------------------
    public class Timer
    {
        #region Private Members

        #region Singleton

        private static Timer _mSingleton = null;

        #endregion

        private float _mTime = 0.0f;

        #endregion

        #region Constructor

        //-------------------------------------------------------------------------
        private Timer()
        {
        }

        #endregion

        #region Public Properties
        
        public float Seconds
        {
            get { return _mTime; }
        }

        #region Static Properties
        
        //-------------------------------------------------------------------------
        public static Timer Singleton
        {
            get
            {
                if (_mSingleton == null)
                    _mSingleton = new Timer();

                return _mSingleton;
            }
        }

        #endregion

        #endregion

        #region Public Methods

        public void Initialize()
        {
            _mTime = 0.0f;
        }
        
        public void Update(float _Dt)
        {
            _mTime += _Dt;
        }

        #endregion        
    }
}