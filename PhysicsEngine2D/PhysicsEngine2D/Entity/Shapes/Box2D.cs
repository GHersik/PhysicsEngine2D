using PhysicsEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Shapes;
using PhysicsLibrary;

namespace PhysicsEngine2D {
    public class Box2D : Shape, IRenderer {
        
        public UIElement UIElement => this;

        private double width;
        private double height;

        public Box2D(double width, double height, SolidColorBrush color) {
            this.width = width;
            this.height = height;
            Width = width;
            Height = height;
            Fill = color;
        }

        public Box2D(double width, double height) : this(width, height, ColorSettings.YellowBrush) { }

        public Box2D() : this(10, 10, ColorSettings.YellowBrush) { }

        protected override Geometry DefiningGeometry {
            get {
                return new RectangleGeometry(new Rect(0, 0, Width, Height));
            }
        }

        public void Draw(Vector2 position) => RenderTransform = new TranslateTransform(position.x - width / 2, position.y - height / 2);

        public void SetColor(SolidColorBrush color) => Fill = color;

    }
}
