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

        private SceneManager sceneManager;
        private Timer? timer;
        private readonly TimeSpan interval = TimeSpan.FromMilliseconds((int)(PhysicsSettings.FixedTimeStep * 1000));

        public SceneEngine(SceneManager sceneManager) {
            this.sceneManager = sceneManager;
        }

        public void StartTime() => timer = new Timer(FixedUpdate, null, TimeSpan.Zero, interval);

        public void StopTime() {
            timer?.Dispose();
            timer = null;
        }

        private void FixedUpdate(object? state) {
            if (Application.Current != null && !Application.Current.Dispatcher.HasShutdownStarted) {
                sceneManager.FixedUpdate();
                Application.Current.Dispatcher.Invoke(() => { sceneManager.Update(); });
                Time.FixedUpdate();
            }
        }
    }
}
