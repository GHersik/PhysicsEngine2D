using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using PhysicsLibrary;

namespace PhysicsEngine2D
{
    public class Circle2D : Shape, IRenderer {

        private double radius;

        public Circle2D(double radius, SolidColorBrush color) {
            this.radius = radius;
            Width = radius * 2;
            Height = radius * 2;
            Fill = color;
        }

        public Circle2D(double radius) : this(radius, ColorSettings.YellowBrush) { }

        public Circle2D() : this(5, ColorSettings.YellowBrush) { }

        protected override Geometry DefiningGeometry {
            get {
                return new EllipseGeometry(new Rect(0, 0, Width - 2, Height - 2));
            }
        }

        public void Draw(Vector2 position) => RenderTransform = new TranslateTransform(position.x - radius, position.y - radius);

        public UIElement UIElement => this;

    }
}
