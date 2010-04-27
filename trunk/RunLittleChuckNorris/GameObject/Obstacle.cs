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
    public class Obstacle : GameObject
    {
        Helper.IWorldProvider _mworldProvider;

        public Obstacle(Game game)
            : base(game)
        {
            _mworldProvider = (Helper.IWorldProvider)Game.Services.GetService(typeof(Helper.IWorldProvider));
            _mworldProvider.Obstacles.Add(this);

        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            
            base.UnloadContent();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            _mworldProvider.Obstacles.Remove(this);
        }
    }
}