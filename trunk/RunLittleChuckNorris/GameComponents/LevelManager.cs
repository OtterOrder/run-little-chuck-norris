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
using RunLittleChuckNorris.GameObject;
using RunLittleChuckNorris.Helper;


namespace RunLittleChuckNorris.GameComponents
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class LevelManager : Microsoft.Xna.Framework.GameComponent
    {
        public LevelManager(Game game)
            : base(game)
        {
        }

        static private Camera _mDefaultCam;
        private Player _mPlayer;
        private IWorldProvider _mworldProvider;
        private float _mPlayerOffset;

        private int _mRefreshDist = 1300;
        Random rand = new Random(DateTime.Now.Millisecond); 

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            _mDefaultCam = new Camera();
            _mPlayer = new GameObject.Player(Game, "Player");
            _mworldProvider = (IWorldProvider) Game.Services.GetService(typeof(IWorldProvider));

            _mPlayerOffset = 600;

            CreateInitLevel();

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            float Dt = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            _mDefaultCam.Update(Dt);
            _mDefaultCam.mFocus = new Vector2(_mPlayer.X + _mPlayerOffset, _mPlayer.Y);

            if (_mDefaultCam.MaxX % _mRefreshDist == 0)
            {
                CreateNextPiece((int)_mDefaultCam.MaxX);
            }

            base.Update(gameTime);
        }

        public void CreateInitLevel()
        {
            List<GameComponent> toBeRemoved = new List<GameComponent>();

            // remove all existing gameobject
            foreach (GameComponent g in Game.Components)
            {
                if (g is GameObject.Player)
                {
                    (g as GameObject.Player).Init();
                }
                else if (g is GameObject.Obstacle ||
                         g is GameObject.Plateforme)
                {
                    // remove it
                    toBeRemoved.Add(g);
                }
            }

            foreach (GameComponent g in toBeRemoved)
            {
                Game.Components.Remove(g);
            }

            _mDefaultCam.SetViewportParam(0, 0, 1.0f, 1.0f);
            _mDefaultCam.Position = new Vector2(0.0f, 0.0f);

            GameObject.GameObject obj;
            GameObject.Plateforme p = new GameObject.Plateforme(Game);
            p.X = 0;
            p.Y = 500;
            p.Width = 2000.0f;
            p.Height = 50.0f;

            obj = new GameObject.Ennemy(Game);
            obj.X = 1500;
            obj.Y = 500;
            obj = new GameObject.Caisse(Game);
            obj.X = 800;
            obj.Y = 500;
        }

        private void CreateNextPiece(int startX)
        {
            int maxWidth = 1000;
            GameObject.GameObject obj;

            int nbdiv = rand.Next(3, 6);

            for (int i = 0; i < nbdiv; i++)
            {
                GameObject.Plateforme p = new GameObject.Plateforme(Game);
                p.X = startX;

                int hauteur = rand.Next(200, 400);
                p.Y = hauteur;

                int longueur = maxWidth / nbdiv;
                p.Width = longueur;

                p.Height = 50.0f;

                startX += (longueur + rand.Next(20, 40));

            }

        }

        static public Camera GetCurrentCam()
        {
            return _mDefaultCam;
        }

        #region Properties

        public Player Player
        {
            get { return _mPlayer; }
        }

        #endregion
    }
}