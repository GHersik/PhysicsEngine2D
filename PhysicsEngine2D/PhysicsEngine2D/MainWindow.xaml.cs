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

        private readonly Time time = new((int)Math.Round(PhysicsSettings.FixedTimeStep * 1000));
        private readonly DispatcherTimer dispatcherTimer = new();
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
            dispatcherTimer.Stop();
            dispatcherTimer.Tick += FixedUpdate;
            dispatcherTimer.Interval = time.FixedTimeStep;
        }

        void SetupWorld() {
            Circle2D newCircle = new Circle2D();
            newCircle.Body.position = new Vector2(250, 250);
            newCircle.Body.AddForce(new Vector2(-50,-1000));
            //newCircle.Body.velocity = new Vector2(6,6);
            //newCircle.Body.acceleration = new Vector2(20, 20);
            //newCircle.Body.forceAccum = new Vector2(22,22);
            SceneView.Children.Add(newCircle);
            world.AddBody(newCircle.Body);

            Circle2D[] cirlces = { newCircle };
            renderer = new(cirlces);
        }

        void SetupPhysicsEngine() {
            physicsEngine = new(world);
        }
        #endregion

        public void StartSimulation() {
            dispatcherTimer.Start();
        }

        public void StopSimulation() {
            dispatcherTimer.Stop();
        }

        public void ResetSimulation() {
            dispatcherTimer.Stop();
        }

        void FixedUpdate(object? sender, EventArgs e) {
            physicsEngine.FixedUpdate();
            renderer.Render();
            time.FixedUpdate();



            //foreach (var sceneEntity in ) {

            //}
        }


    }
}
