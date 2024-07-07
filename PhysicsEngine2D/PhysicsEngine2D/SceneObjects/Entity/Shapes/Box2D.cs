using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using PhysicsLibrary;

namespace SimulationWindow {
    public class Box2D : Shape, IRenderer {

        public UIElement UIElement => this;

        public Entity AttachedEntity => attachedEntity;

        readonly Entity attachedEntity;
        readonly double width;
        readonly double height;

        public Box2D(Entity attachedEntity, double width, double height, SolidColorBrush color) {
            this.attachedEntity = attachedEntity;
            this.width = width;
            this.height = height;
            Width = width;
            Height = height;
            Fill = color;
        }

        public Box2D(Entity attachedEntity, double width, double height) : this(attachedEntity, width, height, ColorSettings.YellowBrush) { }

        public Box2D(Entity attachedEntity) : this(attachedEntity, 10, 10, ColorSettings.YellowBrush) { }

        protected override Geometry DefiningGeometry {
            get {
                return new RectangleGeometry(new Rect(0, 0, Width, Height));
            }
        }

        public void Draw(Vector2 position) => RenderTransform = new TranslateTransform(position.x - width / 2, position.y - height / 2);

        public void SetFillColor(SolidColorBrush color) => Fill = color;

        public void SetBounds(SolidColorBrush color, double thickness) {
            Stroke = color;
            StrokeThickness = thickness;
        }
    }
}
