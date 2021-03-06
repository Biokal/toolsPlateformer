﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platformer
{
    class Goal
    {
        public bool Used = false;

        Texture2D m_texture;
        Vector2 m_position;
        Vector2 m_size;

        Rectangle m_collisionBox = new Rectangle(0, 0, 0, 0);

        public Rectangle getCollisionBox()
        {
            m_collisionBox.X = (int)m_position.X;
            m_collisionBox.Y = (int)m_position.Y;
            m_collisionBox.Width = (int)m_size.X;
            m_collisionBox.Height = (int)m_size.Y;

            return m_collisionBox;
        }

        public Goal(Vector2 _position, bool used = true, int _Width = 32, int _Height = 32)
        {
            m_size = new Vector2(_Width, _Height);
            m_position = _position;
            Used = used;

            m_texture = SpritePack.GetSingleton().GetTexture("Flag");
        }

        public void SetPosition(Vector2 _position)
        {
            m_position = _position;
        }

        public bool isColliding(Rectangle collider)
        {
            if (getCollisionBox().Intersects(collider))
                return true;
            return false;
        }

        public void Draw(SpriteBatch sb, Camera _cam)
        {
            sb.Draw(m_texture, m_position - _cam.getCameraPosition(), Color.White);
        }

    }
}
