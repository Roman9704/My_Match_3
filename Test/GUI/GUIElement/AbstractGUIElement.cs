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
        public abstract void set_position(Vector2f Position);
        public abstract void set_positionX(float X);
        public abstract void set_positionY(float Y);
        public abstract Vector2f get_position();
        public abstract float get_positionX();
        public abstract float get_positionY();

        public abstract void Draw();
        public virtual void Update() { }
    }
}
