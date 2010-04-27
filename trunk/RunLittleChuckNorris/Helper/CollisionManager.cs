using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using RunLittleChuckNorris.GameObject;


namespace RunLittleChuckNorris.Helper
{
    class CollisionManager
    {
        private List<Obstacle> _mObstacleList = new List<Obstacle>();
        private List<Plateforme> _mPlatformList = new List<Plateforme>();

        private IWorldProvider _wordlProvider;

        public CollisionManager(Game game)
        {
            _wordlProvider = (IWorldProvider)game.Services.GetService(typeof(IWorldProvider));

            _mObstacleList = _wordlProvider.Obstacles;
            _mPlatformList = _wordlProvider.Plateformes;
        }

        public GameObject.Plateforme CollidePlatform(GameObject.GameObject obj)
        {
            // Rectangle du l'objet dont on veut savoir la collision
            Rectangle baseRectangle = new Rectangle((int)obj.X, (int)obj.Y, obj.Sprite.Width, obj.Sprite.Width);

            foreach (Plateforme obs in _mPlatformList)
            {
                Rectangle blockRectangle = new Rectangle((int)obs.X, (int)obs.Y, obs.Sprite.Width, obs.Sprite.Height);

                 // Verifie la collision
                if (baseRectangle.Intersects(blockRectangle))
                {
                    GameObject.Plateforme collisionObj = (GameObject.Plateforme)obs;
                    return collisionObj;
                }
            }
            return null;
        }

        public GameObject.Obstacle CollideEnnemy(GameObject.GameObject obj)
        {
            // Rectangle du l'objet dont on veut savoir la collision
            Rectangle baseRectangle = new Rectangle((int)obj.X, (int)obj.Y, obj.Sprite.Width, obj.Sprite.Width);

            foreach (Obstacle obs in _mObstacleList)
            {
                Rectangle blockRectangle = new Rectangle((int)obs.X, (int)obs.Y, obs.Sprite.Width, obs.Sprite.Height);

                // Verifie la collision
                if (baseRectangle.Intersects(blockRectangle))
                {
                    GameObject.Obstacle collisionObj = (GameObject.Obstacle)obs;
                    return collisionObj;
                }
            }
            return null;
        }
    }
}



