﻿using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using PhysicsLibrary;

namespace SimulationWindow {
    public class Circle2D : Shape, IRenderer {

        public UIElement UIElement => this;
        public Entity AttachedEntity => attachedEntity;

        readonly Entity attachedEntity;
        readonly double radius;

        public Circle2D(Entity attachedEntity, double radius, SolidColorBrush color) {
            this.attachedEntity = attachedEntity;
            this.radius = radius;
            Width = radius * 2;
            Height = radius * 2;
            Fill = color;
        }

        public Circle2D(Entity attachedEntity, double radius) : this(attachedEntity, radius, ColorSettings.YellowBrush) { }

        public Circle2D(Entity attachedEntity) : this(attachedEntity, 6, ColorSettings.YellowBrush) { }

        protected override Geometry DefiningGeometry {
            get {
                return new EllipseGeometry(new Rect(0, 0, Width - 2, Height - 2));
            }
        }

        public void Draw(Vector2 position) => RenderTransform = new TranslateTransform(position.x - radius, position.y - radius);

        public void SetFillColor(SolidColorBrush color) => Fill = color;

        public void SetBounds(SolidColorBrush color, double thickness) {
            Stroke = color;
            StrokeThickness = thickness;
        }
    }
}
