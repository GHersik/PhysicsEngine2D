using System;
using System.Threading;
using System.Windows;
using PhysicsEngine2D;
using PhysicsLibrary;

namespace SimulationWindow {
    public class SceneEngine {

        public bool IsRunning => timer != null;

        readonly SceneManager sceneManager;
        Timer? timer;
        readonly TimeSpan interval = TimeSpan.FromMilliseconds(4);
        double accumulatedTime = 0.0;
        DateTime lastUpdateTime;

        public SceneEngine(SceneManager sceneManager) {
            this.sceneManager = sceneManager;
        }

        public void StartTime() {
            lastUpdateTime = DateTime.UtcNow;
            timer = new Timer(FixedUpdate, null, TimeSpan.Zero, interval);
        }

        public void StopTime() {
            timer?.Dispose();
            timer = null;
        }

        void FixedUpdate(object? state) {
            DateTime currentTime = DateTime.UtcNow;
            double deltaTime = (currentTime - lastUpdateTime).TotalSeconds;
            lastUpdateTime = currentTime;

            accumulatedTime += deltaTime;

            while (accumulatedTime >= PhysicsSettings.FixedTimeStep) {
                sceneManager.FixedUpdate();
                accumulatedTime -= PhysicsSettings.FixedTimeStep;
            }

            if (Application.Current != null && !Application.Current.Dispatcher.HasShutdownStarted) {
                Application.Current.Dispatcher.Invoke(() => sceneManager.Update());
            }
        }
    }
}
