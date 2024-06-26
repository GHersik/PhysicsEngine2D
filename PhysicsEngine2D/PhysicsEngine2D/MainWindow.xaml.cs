using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using SimulationWindow.SceneManagement;

namespace PhysicsEngine2D {

    public partial class MainWindow : Window {

        private SceneEngine sceneEngine;
        private SceneLoader sceneLoader;

        #region Initialization
        public MainWindow() {
            InitializeComponent();
            Setup();
            EnableInput(false);

            SceneManager sceneManager = new SceneManager(SceneView);
            sceneEngine = new SceneEngine(sceneManager);
            sceneLoader = new SceneLoader(sceneManager, SceneFade);
            StartSimulation();
        }

        private void Setup() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private async void StartSimulation() {
            Task sceneLoad = sceneLoader.LoadDefaultSceneAsync();
            await sceneLoad;

            EnableInput(true);
            sceneEngine.StartTime();
        }
        #endregion

        public void TimeButton_Click(object sender, RoutedEventArgs e) {
            if (sceneEngine.IsRunning)
                SetSimulationTime(false);
            else
                SetSimulationTime(true);
        }

        private void SetSimulationTime(bool value) {
            if (value) {
                sceneEngine.StartTime();
                TimeButton.Content = "Stop Time";
            }
            else {
                sceneEngine.StopTime();
                TimeButton.Content = "Start Time";
            }
        }

        private async void Generate_Click(object sender, RoutedEventArgs e) {
            SetSimulationTime(false);
            EnableInput(false);

            int sceneIndex = PickSimulationCB.SelectedIndex;
            SceneLoader.Scene enumValue = (SceneLoader.Scene)Enum.ToObject(typeof(SceneLoader.Scene), sceneIndex);

            Task sceneLoadTask = sceneLoader.LoadSceneAsync(enumValue);
            await sceneLoadTask;
            EnableInput(true);
            SetSimulationTime(true);
        }

        private void EnableInput(bool value) {
            TimeButton.IsEnabled = value;
            GenerateButton.IsEnabled = value;
            PickSimulationCB.IsEnabled = value;
        }
    }
}
