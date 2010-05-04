using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Coeur
{
    public class SceneManager
    {
        #region Private Members
        
        #region singleton
        
        private static SceneManager _mSingleton = null;
        
        #endregion
        
        private List<Scene> _mSceneList = new List<Scene>();

        #endregion

        #region Constructor

        //-------------------------------------------------------------------------
        private SceneManager()
        {
        }

        #endregion

        #region Public Static Properties

        //-------------------------------------------------------------------------
        public static SceneManager Singleton
        {
            get
            {
                if (_mSingleton == null)
                    _mSingleton = new SceneManager();

                return _mSingleton;
            }
        }

        #endregion

        #region Public Methods

        #region Scene Management

        //-------------------------------------------------------------------------
        public UInt32 CreateScene()
        {
            UInt32 id = (UInt32)_mSceneList.Count;
            Scene scene = new Scene(id);
            _mSceneList.Add(scene);

            return id;
        }

        public Sprite GetNewSprite(string _FileName, ContentManager _ContentManager, UInt32 _SceneId)
        {
            Sprite spr = new Sprite(_FileName, _ContentManager);
            _mSceneList[(int)_SceneId].AddSprite(spr);

            return spr;
        }

        public Sprite GetNewSprite(string _FileName, ContentManager _ContentManager, UInt32 _SceneId, UInt32 _NbFrames, float _Fps)
        {
            Sprite spr = new Sprite(_FileName, _ContentManager, _NbFrames, _Fps);
            _mSceneList[(int)_SceneId].AddSprite(spr);

            return spr;
        }

        public Background GetNewBackground(string _FileName, ContentManager _ContentManager, UInt32 _SceneId)
        {
            Background bg = new Background(_FileName, _ContentManager);
            _mSceneList[(int)_SceneId].AddBackground(bg);

            return bg;
        }

        public Camera GetNewCamera(UInt32 _SceneId)
        {
            Camera camera = new Camera();
            _mSceneList[(int)_SceneId].AddCamera(camera);

            return camera;
        }

        public Scene GetScene(UInt32 _SceneId)
        {
            return _mSceneList[(int)_SceneId];
        }

        public void RemoveSprite(Sprite _Sprite, UInt32 _SceneId)
        {
            if (_Sprite != null)
                _mSceneList[(int)_SceneId].RemoveSprite(_Sprite);
        }

        #endregion

        #region Sorting

        //-------------------------------------------------------------------------
        public void SortSprites()
        {
            foreach (Scene scene in _mSceneList)
            {
                scene.SortSprites();
            }
        }

        public void SortBackgrounds()
        {
            foreach (Scene scene in _mSceneList)
            {
                scene.SortBackgrounds();
            }
        }

        #endregion

        #region Update

        //-------------------------------------------------------------------------
        public void Update(float _Dt)
        {
            foreach (Scene scene in _mSceneList)
            {
                scene.Update(_Dt);
            }
        }

        #endregion

        #region Draw

        //-------------------------------------------------------------------------
        public void Draw(SpriteBatch _SprBatch, GraphicsDeviceManager _GraphicsManager)
        {

            foreach (Scene scene in _mSceneList)
            {
                scene.Draw(_SprBatch, _GraphicsManager);
            }
        }

        public void DrawScene(SpriteBatch _SprBatch, GraphicsDeviceManager _GraphicsManager, UInt32 _SceneId)
        {
            _mSceneList[(int)_SceneId].Draw(_SprBatch, _GraphicsManager);
        }

        #endregion

        #endregion
    }
}