using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using PhysicsEngine2D;
using Physics;
using SimulationWindow;
using System.Windows.Threading;
using System.Threading;
using System.Windows;
using PhysicsLibrary;

namespace SimulationWindow.SceneManagement {
    public class SceneEngine {

        public bool IsRunning => timer != null;

        SceneManager sceneManager;
        Timer? timer;
        readonly double fixedTimeStep = PhysicsSettings.FixedTimeStep;
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

            while (accumulatedTime >= fixedTimeStep) {
                sceneManager.FixedUpdate();
                accumulatedTime -= fixedTimeStep;
            }

            if (Application.Current != null && !Application.Current.Dispatcher.HasShutdownStarted) {
                Application.Current.Dispatcher.Invoke(() => sceneManager.Update());
            }
        }
    }
}
