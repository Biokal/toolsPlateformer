using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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
        Vector2 m_origin = new Vector2(32,32);
        Vector2 m_widthHeight;
        Vector2 m_previousPosition;
        Vector2 m_vitesse = new Vector2(0,0);
        float m_rotation = 0f;
        float m_rotationSpeed = 250f;

        Vector2 m_offset;

        Rectangle m_collisionBox;

        public Rectangle getCollisionBox()
        {
            m_collisionBox.X = (int)m_position.X - (int)m_widthHeight.X;
            m_collisionBox.Y = (int)m_position.Y - (int)m_widthHeight.Y;
            m_collisionBox.Width = (int)m_widthHeight.X;
            m_collisionBox.Height = (int)m_widthHeight.Y;

            return m_collisionBox;
        }

        public Vector2 getPosition()
        {
            return m_position;
        }

        public Vector2 getOrigin()
        {
            return m_origin;
        }

        public float getRotation()
        {
            return m_rotation;
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
        

        public void Update(GameTime gameTime, List<Wall> _listWall)
        {
            //m_previousPosition pour recaler si jamais il y a collision
            m_previousPosition = m_position;

            //Application gravité sur la position Y
            if (m_vitesse.Y < 750f)
            {
                m_vitesse.Y += 350f * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            m_position += m_vitesse* (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(Keyboard.GetState().IsKeyDown(Keys.D) || Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                m_rotation += m_rotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(m_rotation >90)
                {
                    m_rotation = 0;
                    m_position.X += 32;
                }
            }
            else
            {
                if(m_rotation>=45)
                {
                    if (m_rotation < 90)
                    {
                        m_rotation += m_rotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        m_rotation = 0;
                        m_position.X += 32;
                    }
                }
                else if(m_rotation<=45)
                {
                    if (m_rotation > 0)
                    {
                        m_rotation -= m_rotationSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    }
                    else
                    {
                        m_rotation = 0;
                    }
                }
            }

            foreach(Wall x in _listWall)
            {
                if(x.isColliding(this.getCollisionBox()))
                {
                    m_position = m_previousPosition;
                    m_vitesse.Y = 0;
                }
            }
            

        }

        public void Draw(SpriteBatch sb, Camera _cam)
        {
            sb.Draw(m_texture, m_position - _cam.getCameraPosition(), m_texture.Bounds,  Color.White, MathHelper.ToRadians(m_rotation), m_origin, 1f, SpriteEffects.None, 0);
        }
    }

    

}
