using PhysicsEngine2D;
using Physics;
using System.Windows.Controls;

namespace SimulationWindow {
    public class SceneManager {

        SceneData sceneData;
        readonly SceneRenderer sceneRenderer;
        readonly PhysicsEngine physicsEngine;

        public SceneManager(Canvas canvas) {
            sceneData = new SceneData();
            sceneRenderer = new SceneRenderer(canvas);
            physicsEngine = new PhysicsEngine();
        }

        public void SetNewSceneData(SceneData newSceneData) {
            ClearSceneData();
            sceneData = newSceneData;
            sceneRenderer.ReplaceCurrentRenderers(sceneData);
            physicsEngine.PhysicsWorld.ReplaceRegistry(sceneData.RetrievePhysicsEntities());
        }

        public bool AddEntity(Entity entity) {
            if (sceneData.Contains(entity))
                return false;

            sceneData.AddEntity(entity);
            sceneRenderer.AddEntityToRender(entity);
            physicsEngine.PhysicsWorld.AddBody(entity);
            return true;
        }

        public bool RemoveEntity(Entity entity) {
            if (!sceneData.Contains(entity))
                return false;

            sceneData.RemoveEntity(entity);
            sceneRenderer.RemoveEntityFromRender(entity);
            physicsEngine.PhysicsWorld.RemoveBody(entity);
            return true;
        }

        public void ClearSceneData() {
            sceneData.Clear();
            physicsEngine.PhysicsWorld.Clear();
            sceneRenderer.ClearRenderer();
        }

        public void FixedUpdate() {
            physicsEngine.FixedUpdate();
            foreach (Entity entity in sceneData)
                entity.FixedUpdate();
        }

        public void Update() {
            SceneRenderer.DrawScene(sceneData);
            foreach (Entity entity in sceneData)
                entity.Update();
        }
    }
}
