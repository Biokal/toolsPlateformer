using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Player
    {

        Texture2D m_texture;
        Vector2 m_position;
        Vector2 m_widthHeight;

        Rectangle m_collisionBox = new Rectangle(0, 0, 0, 0);

        public Rectangle getCollisionBox()
        {
            m_collisionBox.X = (int)m_position.X;
            m_collisionBox.Y = (int)m_position.Y;
            m_collisionBox.Width = (int)m_widthHeight.X;
            m_collisionBox.Height = (int)m_widthHeight.Y;

            return m_collisionBox;
        }

        public Player(GraphicsDevice _graphics, Vector2 _position, int _Width, int _Height, Color _color)
        {
            //Création d'une texture par la carte graphique :
            //on définit une texture, sa largeur et sa hauteur
            m_texture = new Texture2D(_graphics, _Width, _Height);
            //les futures données de cette textures , un tableau de couleur de la taille de la texture
            Color[] data = new Color[_Width * _Height];
            for (int i = 0; i < data.Length; i++)
            {
                //pour chaque pixel on attribue une couleur
                data[i] = _color;
            }
            //on attribue les données (couleurs) de la textures
            m_texture.SetData(data);
            m_widthHeight = new Vector2(_Width, _Height);
            this.m_position = _position;

        }








    }

    

}
