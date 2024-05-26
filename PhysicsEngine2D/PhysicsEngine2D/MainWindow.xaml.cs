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

namespace PhysicsEngine2D {

    public partial class MainWindow : Window {

        readonly Time timeSettings = new(30);
        readonly DispatcherTimer Time = new();
        readonly PhysicsEngine physicsEngine = new(new PhysicsSettings(new Vector2(0, -9.81)));

        public MainWindow() {
            InitializeComponent();
            Setup();

            //StartSimulation();

        }

        #region Initialization
        void Setup() {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SetupTime();
            SetupSimulation();
        }

        void SetupRigidBodies() {

        }

        void SetupTime() {
            Time.Stop();
            Time.Tick += FixedUpdate;
            Time.Interval = timeSettings.FixedTimeStep;
        }

        void SetupSimulation() {
            SceneView.Children.Add(new Circle2D());
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
            timeSettings.FixedUpdate();

            //foreach (var sceneEntity in ) {

            //}
        }


    }
}
