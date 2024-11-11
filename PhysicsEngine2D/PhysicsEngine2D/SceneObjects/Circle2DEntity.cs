using PhysicsEngine2D;
using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace SimulationWindow {
    public class Circle2DEntity : Entity {

        public Circle2DEntity(Vector2 position, double radius, SolidColorBrush color) {
            Transform = new PhysicsLibrary.Transform(position);
            Renderer = new Circle2D(this, radius, color);
            Collider = new CircleCollider2D(this, radius);
            Body = new Body();
        }

        public Circle2DEntity(Vector2 position, double radius) : this(position, radius, ColorSettings.YellowBrush) { }

        public Circle2DEntity(Vector2 position) : this(position, 10, ColorSettings.YellowBrush) { }

        public Circle2DEntity() : this(new Vector2(250, 250), 10, ColorSettings.YellowBrush) { }

    }
}
