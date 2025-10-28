using System;
using System.Threading;
using System.Windows;
using PhysicsEngine2D;
using PhysicsLibrary;

namespace SimulationWindow {
    public class SceneEngine {

        public bool IsRunning => timer != null;

<<<<<<< HEAD
        readonly SceneManager sceneManager;
        Timer? timer;
        readonly TimeSpan interval = TimeSpan.FromMilliseconds(4);
        double accumulatedTime = 0.0;
        DateTime lastUpdateTime;
=======
        Timer? timer;
        TimeSpan interval = TimeSpan.FromMilliseconds(4);
        DateTime lastUpdateTime;
        double accumulatedTime = 0.0;
        SceneManager sceneManager;
>>>>>>> development

        public SceneEngine(SceneManager sceneManager) {
            this.sceneManager = sceneManager;
        }

        public void StartTime() {
            lastUpdateTime = DateTime.UtcNow;
<<<<<<< HEAD
            timer = new Timer(FixedUpdate, null, TimeSpan.Zero, interval);
=======
            timer = new Timer(Update, null, TimeSpan.Zero, interval);
>>>>>>> development
        }

        public void StopTime() {
            timer?.Dispose();
            timer = null;
        }

<<<<<<< HEAD
        void FixedUpdate(object? state) {
            DateTime currentTime = DateTime.UtcNow;
            double deltaTime = (currentTime - lastUpdateTime).TotalSeconds;
            lastUpdateTime = currentTime;

=======
        void Update(object? state) {
            DateTime currentTime = DateTime.UtcNow;
            double deltaTime = (currentTime - lastUpdateTime).TotalSeconds;
            lastUpdateTime = currentTime;
>>>>>>> development
            accumulatedTime += deltaTime;

            while (accumulatedTime >= PhysicsSettings.FixedTimeStep) {
                sceneManager.FixedUpdate();
                accumulatedTime -= PhysicsSettings.FixedTimeStep;
            }
<<<<<<< HEAD

=======
>>>>>>> development
            if (Application.Current != null && !Application.Current.Dispatcher.HasShutdownStarted) {
                Application.Current.Dispatcher.Invoke(() => sceneManager.Update());
            }
        }
    }
}
