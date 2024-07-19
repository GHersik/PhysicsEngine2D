using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using PhysicsLibrary;
using SimulationWindow;

namespace PhysicsEngine2D {

    public partial class MainWindow : Window {

        readonly SceneEngine sceneEngine;
        readonly SceneLoader sceneLoader;
        readonly PhysicsObjectTracker physicsObjectTracker;

        #region Initialization
        public MainWindow() {
            InitializeComponent();
            Setup();
            EnableInput(false);

            SceneManager sceneManager = new(this, SceneView);
            sceneEngine = new SceneEngine(sceneManager);
            sceneLoader = new SceneLoader(sceneManager, SceneFade);
            physicsObjectTracker = new(EntityPositionText, EntityVelocityText, EntityTotalForcesText, EntityMassText);
            StartSimulation();
        }

        void Setup() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        async void StartSimulation() {
            Task sceneLoad = sceneLoader.LoadDefaultSceneAsync();
            await sceneLoad;

            EnableInput(true);
            sceneEngine.StartTime();
        }
        #endregion

        public void Update() {
            if (TotalPhysicsStepsText == null)
                return;
            PhysicsEntitiesText.Text = PhysicsStatistics.PhysicsEntities.ToString();
            TotalPhysicsStepsText.Text = PhysicsStatistics.TotalFixedSteps.ToString();
            TotalCollisionsText.Text = PhysicsStatistics.TotalCollisions.ToString();
            CollisionsThisStepText.Text = PhysicsStatistics.CollisionsThisStep.ToString();
            AverageCollisionsThisStepText.Text = Math.Round(PhysicsStatistics.AverageCollisionsPerStep, 3).ToString();
            physicsObjectTracker.FixedUpdate();
        }

        public void TimeButton_Click(object sender, RoutedEventArgs e) {
            if (sceneEngine.IsRunning)
                SetSimulationTime(false);
            else
                SetSimulationTime(true);
        }

        void SetSimulationTime(bool value) {
            if (value) {
                sceneEngine.StartTime();
                TimeButton.Content = "STOP TIME";
            }
            else {
                sceneEngine.StopTime();
                TimeButton.Content = "START TIME";
            }
        }

        async void Generate_Click(object sender, RoutedEventArgs e) {
            SetSimulationTime(false);
            EnableInput(false);

            physicsObjectTracker.ResetTrackedObject();
            int sceneIndex = PickSimulationCB.SelectedIndex;
            SceneLoader.Scene enumValue = (SceneLoader.Scene)Enum.ToObject(typeof(SceneLoader.Scene), sceneIndex);
            PhysicsStatistics.ResetStatistics();

            Task sceneLoadTask = sceneLoader.LoadSceneAsync(enumValue);
            await sceneLoadTask;
            Update();
            EnableInput(true);
        }

        void SliderGravityX(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            Vector2 gravityValue = new Vector2(value, PhysicsSettings.Gravity.y);
            PhysicsSettings.SetGravity(gravityValue);
            if (GravityText != null)
                GravityText.Text = $"{PhysicsSettings.Gravity}";
        }

        void SliderGravityY(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            Vector2 gravityValue = new Vector2(PhysicsSettings.Gravity.x, value);
            PhysicsSettings.SetGravity(gravityValue);
            if (GravityText != null)
                GravityText.Text = $"{PhysicsSettings.Gravity}";
        }

        void SliderTimeStep(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            PhysicsSettings.SetFixedTimeStep(value);
            if (TimeStepText != null)
                TimeStepText.Text = PhysicsSettings.FixedTimeStep.ToString();
        }

        void SliderContactOffset(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            PhysicsSettings.SetDefaultContactOffset(value);
            if (ContactOffsetText != null)
                ContactOffsetText.Text = PhysicsSettings.DefaultContactOffset.ToString();
        }

        void SliderVelocityThreshold(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            PhysicsSettings.SetVelocityThreshold(value);
            if (VelocityThresholdText != null)
                VelocityThresholdText.Text = PhysicsSettings.VelocityThreshold.ToString();
        }

        void SliderSleepTolerance(object sender, RoutedPropertyChangedEventArgs<double> e) {
            double value = Math.Round(e.NewValue, 3);
            PhysicsSettings.SetSleepTolerance(value);
            if (SleepToleranceText != null)
                SleepToleranceText.Text = PhysicsSettings.LinearSleepTolerance.ToString();
        }

        void EnableInput(bool value) {
            TimeButton.IsEnabled = value;
            GenerateButton.IsEnabled = value;
            PickSimulationCB.IsEnabled = value;
        }

        void SceneView_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            if (e != null && e.OriginalSource != null && e.OriginalSource is IRenderer)
                physicsObjectTracker.SetNewObjectToTrack((IRenderer)e.OriginalSource);
            else
                physicsObjectTracker.SetNewObjectToTrack(null);
        }
    }
}
