using PhysicsEngine2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Physics;
using System.Windows.Controls;

namespace SimulationWindow.SceneManagement {
    public class SceneManager {

        private SceneData sceneData;
        private SceneRenderer sceneRenderer;
        private PhysicsEngine physicsEngine;

        public SceneManager(Canvas canvas) {
            sceneData = new SceneData();
            sceneRenderer = new SceneRenderer(canvas);
            physicsEngine = new PhysicsEngine();
        }

        public void SetNewSceneData(SceneData newSceneData) {
            ClearSceneData();
            sceneData = newSceneData;
            sceneRenderer.ReplaceCurrentRenderers(sceneData);
            physicsEngine.ReplacePhysicsRegistry(sceneData.RetrieveCurrentPhysicsBodies());
        }

        public bool AddEntity(Entity entity) {
            if (sceneData.Contains(entity))
                return false;

            sceneData.AddEntity(entity);
            sceneRenderer.AddEntityToRender(entity);
            physicsEngine.AddObject(entity.Body);
            return true;
        }

        public bool RemoveEntity(Entity entity) {
            if (!sceneData.Contains(entity))
                return false;

            sceneData.RemoveEntity(entity);
            sceneRenderer.RemoveEntityFromRender(entity);
            physicsEngine.RemoveObject(entity.Body);
            return true;
        }

        public void ClearSceneData() {
            sceneData.Clear();
            physicsEngine.Clear();
            sceneRenderer.ClearRenderer();
        }

        public void FixedUpdate() {
            physicsEngine.FixedUpdate();
            foreach (Entity entity in sceneData)
                entity.FixedUpdate();
        }

        public void Update() {
            sceneRenderer.DrawScene(sceneData);
            foreach (Entity entity in sceneData)
                entity.Update();
        }
    }
}
