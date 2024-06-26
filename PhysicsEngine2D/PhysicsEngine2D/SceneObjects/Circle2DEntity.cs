using PhysicsEngine2D;
using PhysicsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PhysicsEngine2D {
    public class Circle2DEntity : Entity {

        public Circle2DEntity(Vector2 position, double radius, SolidColorBrush color) {
            transform = new PhysicsLibrary.Transform(position);
            renderer = new Circle2D(radius, color);
            collider = new CircleCollider2D(this, radius);
            body = new Body();
        }

        public Circle2DEntity(Vector2 position, double radius) : this(position, radius, ColorSettings.YellowBrush) { }

        public Circle2DEntity(Vector2 position) : this(position, 10, ColorSettings.YellowBrush) { }

        public Circle2DEntity() : this(new Vector2(250, 250), 10, ColorSettings.YellowBrush) { }


        public override void OnCollisionEnter2D(Collision2D collision) {
            renderer.SetColor(ColorSettings.GreenBrush);
        }

        public override void OnCollisionExit2D(Collision2D collision) {

        }
    }
}
