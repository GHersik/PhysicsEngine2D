using SimulationWindow;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using PhysicsLibrary;
using PhysicsLibrary.Collider;

namespace PhysicsEngine2D {
    public class Circle2D : Shape {

        public Body Body { get; private set; }

        //future
        //public CircleCollider CircleCollider { get; private set; }
        private double radius;

        public Circle2D(double radius, SolidColorBrush color) {
            Body = new Body();
            this.radius = radius;
            Width = radius * 2;
            Height = radius * 2;
            Fill = color;
        }

        public Circle2D() : this(5, ColorSettings.YellowBrush) { }

        protected override Geometry DefiningGeometry {
            get {
                return new EllipseGeometry(new Rect(0, 0, this.Width - 2, this.Height - 2));
            }
        }

        public void Draw() {
            RenderTransform = new TranslateTransform(Body.position.x - radius, Body.position.y - radius);
        }
    }
}
