using System.Windows.Controls;

namespace SimulationWindow {
    public class SceneRenderer {

        readonly Canvas canvas;

        public SceneRenderer(Canvas canvas) {
            this.canvas = canvas;
        }

        public void ReplaceCurrentRenderers(SceneData scene) {
            ClearRenderer();
            foreach (var entity in scene)
                canvas.Children.Add(entity.Renderer.UIElement);
        }

        public bool AddEntityToRender(Entity entity) {
            if (canvas.Children.Contains(entity.Renderer.UIElement))
                return false;

            canvas.Children.Add(entity.Renderer.UIElement);
            return true;
        }

        public bool RemoveEntityFromRender(Entity entity) {
            if (!canvas.Children.Contains(entity.Renderer.UIElement))
                return false;

            canvas.Children.Remove(entity.Renderer.UIElement);
            return true;
        }

        public void ClearRenderer() {
            canvas.Children.Clear();
        }

        public static void DrawScene(SceneData sceneData) {
            foreach (var entity in sceneData)
                entity.DrawEntity();
        }
    }
}
