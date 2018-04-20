using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.System;

namespace Test
{
    abstract class AbstractGUIElement
    {
        public abstract void set_Position(Vector2f Position);
        public abstract void set_PositionX(float X);
        public abstract void set_PositionY(float Y);
        public abstract Vector2f get_Position();
        public abstract float get_PositionX();
        public abstract float get_PositionY();

        public abstract void Draw();
        public virtual void Update() { }
    }
}
