using PhysicsEngine2D;
using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimulationWindow {
    public class Box2DEntity : Entity {

        public Box2DEntity(Vector2 position, double width, double height, SolidColorBrush color) {
            Transform = new PhysicsLibrary.Transform(position);
            Renderer = new Box2D(width, height, color);
            Collider = new BoxCollider2D(this, new Vector2(-width / 2, -height / 2), new Vector2(width / 2, height / 2));
            Body = new Body();
        }

        public Box2DEntity(Vector2 position, double width, double height) : this(position, width, height, ColorSettings.BlueBrush) { }

        public Box2DEntity(Vector2 position, double width) : this(position, width, 10, ColorSettings.BlueBrush) { }

        public Box2DEntity(Vector2 position) : this(position, 10, 10, ColorSettings.BlueBrush) { }

        public Box2DEntity() : this(new Vector2(250, 250), 10, 10, ColorSettings.BlueBrush) { }

    }
}
