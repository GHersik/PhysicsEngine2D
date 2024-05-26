using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Physics2D;
using PhysicsLibrary;
using SimulationWindow;

namespace PhysicsEngine2D {

    public partial class MainWindow : Window {

        readonly Time timeSettings = new(20);
        readonly DispatcherTimer Time = new();
        private Renderer renderer;
        private PhysicsEngine physicsEngine;
        private World world = new();

        public MainWindow() {
            InitializeComponent();
            Setup();

            StartSimulation();
        }

        #region Initialization
        void Setup() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SetupTime();
            SetupWorld();
            SetupPhysicsEngine();
        }

        void SetupTime() {
            Time.Stop();
            Time.Tick += FixedUpdate;
            Time.Interval = timeSettings.FixedTimeStep;
        }

        void SetupWorld() {
            Circle2D newCircle = new Circle2D();
            newCircle.Body.position = new Vector2(250, 250);
            newCircle.Body.forceAccum += new Vector2(0, -300);
            //newCircle.Body.velocity = new Vector2(6,6);
            //newCircle.Body.acceleration = new Vector2(20, 20);
            //newCircle.Body.forceAccum = new Vector2(22,22);
            SceneView.Children.Add(newCircle);
            world.AddBody(newCircle.Body);

            Circle2D[] cirlces = { newCircle };
            renderer = new(cirlces);
        }

        void SetupPhysicsEngine() {
            physicsEngine = new(new PhysicsSettings(new Vector2(0, 9.81)), world);
        }
        #endregion

        public void StartSimulation() {
            Time.Start();
        }

        public void StopSimulation() {
            Time.Stop();
        }

        public void ResetSimulation() {
            Time.Stop();
        }

        void FixedUpdate(object? sender, EventArgs e) {
            physicsEngine.FixedUpdate();
            renderer.Render();
            timeSettings.FixedUpdate();



            //foreach (var sceneEntity in ) {

            //}
        }


    }
}
