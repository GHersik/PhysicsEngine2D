using System.Windows.Controls;

namespace PhysicsEngine2D {
    public class SceneRenderer {

        private Canvas canvas;

        public SceneRenderer(Canvas canvas) {
            this.canvas = canvas;
        }

        public void ReplaceCurrentRenderers(SceneData scene) {
            ClearRenderer();
            foreach (var entity in scene)
                canvas.Children.Add(entity.renderer.UIElement);
        }

        public bool AddEntityToRender(Entity entity) {
            if (canvas.Children.Contains(entity.renderer.UIElement))
                return false;

            canvas.Children.Add(entity.renderer.UIElement);
            return true;
        }

        public bool RemoveEntityFromRender(Entity entity) {
            if (!canvas.Children.Contains(entity.renderer.UIElement))
                return false;

            canvas.Children.Remove(entity.renderer.UIElement);
            return true;
        }

        public void ClearRenderer() {
            canvas.Children.Clear();
        }

        public void DrawScene(SceneData sceneData) {
            foreach (var entity in sceneData)
                entity.DrawEntity();
        }
    }
}
