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

        //private SolidColorBrush brush = new SolidColorBrush(Color.FromArgb(255, 107, 203, 119));

        public Circle2DEntity(Vector2 position, double radius, SolidColorBrush color) {
            transform = new PhysicsLibrary.Transform(position);
            renderer = new Circle2D(radius, color);
            collider = new CircleCollider2D(this, radius);
            body = new Body();
        }

        public Circle2DEntity(Vector2 position, double radius) : this(position, radius, ColorSettings.YellowBrush) { }

        public Circle2DEntity(Vector2 position) : this(position, 10, ColorSettings.YellowBrush) { }

        public Circle2DEntity() : this(new Vector2(250, 250), 10, ColorSettings.YellowBrush) { }


        //public override void OnCollisionEnter2D(Collision2D collision) {
        //    byte r = (byte)(brush.Color.R);
        //    byte g = (byte)(brush.Color.G + 2);
        //    byte b = (byte)(brush.Color.B);

        //    brush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
        //    renderer.SetColor(brush);
        //}

        //public override void OnCollisionExit2D(Collision2D collision) {

        //}
    }
}
