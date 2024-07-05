using PhysicsLibrary;
using System.Windows;
using System.Windows.Media;

namespace SimulationWindow {
    public interface IRenderer {

        public abstract void Draw(Vector2 position);
        public abstract UIElement UIElement { get; }
        public abstract void SetFillColor(SolidColorBrush color);
        public abstract void SetBounds(SolidColorBrush color, double thickness);
    }
}
