using System;
using Microsoft.Xna.Framework.Input;

namespace Coeur
{
    public class InputManager
    {
        #region Private Members

        #region Singleton
        private static InputManager _mSingleton = null;
        #endregion

        private KeyboardState _mCurrentKeyBoardState;
        private KeyboardState _mLastKetBoardState;
        
        #endregion

        #region Constructor
        //-------------------------------------------------------------------------
        private InputManager()
        {
            _mLastKetBoardState = _mCurrentKeyBoardState = Keyboard.GetState();
        }
        #endregion

        #region Public Static Properties

        //-------------------------------------------------------------------------
        public static InputManager Singleton
        {
            get
            {
                if (_mSingleton == null)
                    _mSingleton = new InputManager();

                return _mSingleton;
            }
        }

        #endregion

        #region Public Methods

        //-------------------------------------------------------------------------
        public void Update()
        {
            _mLastKetBoardState = _mCurrentKeyBoardState;
            _mCurrentKeyBoardState = Keyboard.GetState();
        }

        #region Key Helper

        //-------------------------------------------------------------------------
        public bool IsKeyPressed(Keys _Key)
        {
            return _mCurrentKeyBoardState.IsKeyDown(_Key);
        }

        public bool IsKeyReleased(Keys _Key)
        {
            return _mCurrentKeyBoardState.IsKeyUp(_Key);
        }

        public bool IsKeyJustPressed(Keys _Key)
        {
            return (_mCurrentKeyBoardState.IsKeyDown(_Key) && _mLastKetBoardState.IsKeyUp(_Key));
        }

        public bool IsKeyJustReleased(Keys _Key)
        {
            return (_mCurrentKeyBoardState.IsKeyUp(_Key) && _mLastKetBoardState.IsKeyDown(_Key));
        }

        #endregion

        #endregion
    }
}