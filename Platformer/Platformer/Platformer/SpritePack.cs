using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class SpritePack
    {
        GraphicsDevice m_RegisteredDevice;
        ContentManager m_ContentManager;
        static SpritePack m_Instance;
        Dictionary<string, Texture2D> m_Textures;


        public SpritePack(GraphicsDevice _graphics, ContentManager _contents)
        {
            m_Instance = this;
            m_Textures = new Dictionary<string, Texture2D>();
            m_RegisteredDevice = _graphics;
            m_ContentManager = _contents;
        }

        static public SpritePack GetSingleton()
        {
            return m_Instance;
        }

        public Texture2D GetTexture(string Name)
        {
            if(m_Textures[Name] == null)
            {
                Texture2D newTexture = m_ContentManager.Load<Texture2D>(@"Sprite/"+ Name+".png");
                m_Textures.Add(Name, newTexture);
            }

            return m_Textures[Name];
        }

    }
}
