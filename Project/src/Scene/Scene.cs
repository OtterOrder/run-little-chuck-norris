using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Coeur
{
    public class Scene
    {
        #region Private Members

        private List<Sprite>     _mSprList = new List<Sprite>();
        private List<Background> _mBgList = new List<Background>();
        private List<Camera>     _mCamList = new List<Camera>();

        private UInt32 _mId;

        #endregion

        #region Constructor
        
        //-------------------------------------------------------------------------
        public Scene(UInt32 id)
        {
            _mId = id;
        }

        #endregion

        #region Public Methods
        //-------------------------------------------------------------------------
        public void Update(float _Dt)
        {
            foreach (Camera camera in _mCamList)
            {
                camera.Update(_Dt);
            }

            foreach (Background ItBg in _mBgList)
            {
                ItBg.Update(_Dt);
            }

            foreach (Sprite ItSpr in _mSprList)
            {
                ItSpr.Update(_Dt);
            }
        }

        public void Draw(SpriteBatch _SprBatch, GraphicsDeviceManager _GraphicsManager)
        {
            foreach (Camera camera in _mCamList)
            {
                // Camera de la scène
                camera.SetCamera(_GraphicsManager);

                // Rendu background
                _SprBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None);

                _GraphicsManager.GraphicsDevice.SamplerStates[0].AddressU = TextureAddressMode.Wrap;
                _GraphicsManager.GraphicsDevice.SamplerStates[0].AddressV = TextureAddressMode.Wrap;

                _GraphicsManager.GraphicsDevice.SamplerStates[0].MinFilter = TextureFilter.Linear;
                _GraphicsManager.GraphicsDevice.SamplerStates[0].MagFilter = TextureFilter.Linear;

                foreach (Background ItBg in _mBgList)
                {
                    ItBg.Draw(_SprBatch);
                }
                _SprBatch.End();

                // Rendu sprite
                _SprBatch.Begin(SpriteBlendMode.AlphaBlend, SpriteSortMode.Immediate, SaveStateMode.None, camera.Transform);

                _GraphicsManager.GraphicsDevice.SamplerStates[0].AddressU = TextureAddressMode.Clamp;
                _GraphicsManager.GraphicsDevice.SamplerStates[0].AddressV = TextureAddressMode.Clamp;

                _GraphicsManager.GraphicsDevice.SamplerStates[0].MinFilter = TextureFilter.Linear;
                _GraphicsManager.GraphicsDevice.SamplerStates[0].MagFilter = TextureFilter.Linear;

                foreach (Sprite ItSpr in _mSprList)
                {
                    if (ItSpr.Visible)
                        ItSpr.Draw(_SprBatch);
                }
                _SprBatch.End();
            }
        }

        #region List Management

        #region Add/Remove

        public void AddSprite(Sprite _Spr)
        {
            _mSprList.Add(_Spr);
        }

        public void RemoveSprite(Sprite _Spr)
        {
            _mSprList.Remove(_Spr);
        }

        public void AddBackground(Background _Bg)
        {
            _mBgList.Add(_Bg);
        }

        public void AddCamera(Camera _Cam)
        {
            _mCamList.Add(_Cam);
        }

        #endregion

        #region Sorting

        public void SortSprites()
        {
            _mSprList.Sort(new SpriteComparer());
        }

        public void SortBackgrounds()
        {
            _mBgList.Sort(new BackgroundComparer());
        }

        #endregion

        #endregion

        #endregion

    }
}
