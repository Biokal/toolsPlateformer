using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Platformer
{
    class Camera
    {
        Vector2 m_position;
        Vector2 m_cameraOffset;

        public Camera(int widthCamera, int heightCamera)
        {
            m_position = new Vector2(0, 0);
            m_cameraOffset = new Vector2(widthCamera, heightCamera);
        }

        public void setCameraPosition(Vector2 _position)
        {
            m_position = _position;
        }

        public Vector2 getCameraPosition()
        {
            return m_position - m_cameraOffset/2;
        }
            
    }
}
