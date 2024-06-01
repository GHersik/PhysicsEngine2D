using PhysicsLibrary;
using System.Windows;

namespace PhysicsEngine2D {
    public interface IRenderer {

        public abstract void Draw(Vector2 position);
        public abstract UIElement UIElement { get; }

    }
}
