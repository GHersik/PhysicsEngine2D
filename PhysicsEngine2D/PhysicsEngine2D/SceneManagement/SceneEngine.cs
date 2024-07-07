using System;
using System.Threading;
using System.Windows;
using PhysicsLibrary;

namespace SimulationWindow {
    public class SceneEngine {

        public bool IsRunning => timer != null;

        Timer? timer;
        TimeSpan interval = TimeSpan.FromMilliseconds(4);
        DateTime lastUpdateTime;
        double accumulatedTime = 0.0;
        SceneManager sceneManager;

        public SceneEngine(SceneManager sceneManager) {
            this.sceneManager = sceneManager;
        }

        public void StartTime() {
            lastUpdateTime = DateTime.UtcNow;
            timer = new Timer(Update, null, TimeSpan.Zero, interval);
        }

        public void StopTime() {
            timer?.Dispose();
            timer = null;
        }

        void Update(object? state) {
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
