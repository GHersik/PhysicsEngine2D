using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhysicsLibrary;

namespace SimulationWindow {

    public class Scenes {

        //SolidColorBrush randomColor = new SolidColorBrush(Color.FromRgb((byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255), (byte)rnd.Next(80, 255)));
        readonly Random rnd = new Random();

        public SceneData Ambient() {
            SceneData scene = new SceneData();
            
            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++) {
                    Vector2 position = new Vector2(i * 50 + rnd.Next(-18, 18), j * 50 + rnd.Next(-18, 18));
                    int massAndRadius = rnd.Next(4, 8);
                    Circle2DEntity circle = new Circle2DEntity(position, massAndRadius, ColorSettings.WhiteBrush);
                    circle.body.Mass = massAndRadius;
                    circle.body.Damping = 1;
                    circle.body.AddForce(new Vector2(rnd.Next(-200, 200), rnd.Next(-200, 200)), ForceMode.Impulse);
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.03);
            return scene;
        }

        public SceneData BrownianMotion() {
            SceneData scene = new SceneData();
            
            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 8; j++) {
                    Vector2 position = new Vector2(i * 28, j * 28);
                    Circle2DEntity circle = new Circle2DEntity(position, 4, ColorSettings.YellowBrush);
                    circle.body.Mass = 4;
                    circle.body.Damping = 1;
                    circle.body.AddForce(new Vector2(rnd.Next(-300, 300), rnd.Next(-300, 300)), ForceMode.Impulse);
                    scene.AddEntity(circle);
                }

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 400), 20, ColorSettings.YellowBrush);
            bigCircle.body.Mass = 20;
            scene.AddEntity(bigCircle);

            AddWalls(scene);
            PhysicsSettings.SetGravity(Vector2.Zero);
            PhysicsSettings.SetFixedTimeStep(.02);
            return scene;
        }

        public SceneData RestingContact() {
            SceneData scene = new SceneData();

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(250, 100), 20, ColorSettings.TransparentBrush);
            bigCircle.body.Mass = 20;
            bigCircle.body.Damping = .9;
            bigCircle.body.Restitution = .7;
            bigCircle.renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(250, 400), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.body.SetKinematic(true);
            boxEntity.renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(new Vector2(0, 200));
            PhysicsSettings.SetFixedTimeStep(.06);
            return scene;
        }

        public SceneData BilliardSample() {
            SceneData scene = new SceneData();
            
            double x = 190;
            for (int i = 0; i < 5; i++) {
                double y = 100 + i * 21;
                for (int j = 0; j < 5 - i; j++) {
                    Vector2 position = new Vector2(x + j * 24 + i * 12, y);
                    Circle2DEntity circle = new Circle2DEntity(position, 12, ColorSettings.WhiteBrush);
                    circle.body.Damping = .7;
                    scene.AddEntity(circle);
                }
            }

            Circle2DEntity whiteBall = new Circle2DEntity(new Vector2(250, 400), 12, ColorSettings.WhiteBrush);
            whiteBall.body.Damping = .7;
            whiteBall.body.AddForce(new Vector2(rnd.Next(-40, 40), -rnd.Next(200, 500)), ForceMode.Impulse);
            scene.AddEntity(whiteBall);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.01);
            return scene;
        }

        public SceneData Tunneling() {
            SceneData scene = new SceneData();

            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.body.Mass = 20;
            bigCircle.body.Damping = 1;
            bigCircle.body.Restitution = .7;
            bigCircle.body.AddForce(new Vector2(10000, 0), ForceMode.Impulse);
            bigCircle.renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(360, 250), 40, 100, ColorSettings.TransparentBrush);
            boxEntity.body.SetKinematic(true);
            boxEntity.renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public SceneData MarginalBounds() {
            SceneData scene = new SceneData();
            
            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.body.Mass = 20;
            bigCircle.body.Damping = 1;
            bigCircle.body.Restitution = .7;
            bigCircle.body.AddForce(new Vector2(11000, 0), ForceMode.Impulse);
            bigCircle.renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(360, 280), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.body.SetKinematic(true);
            boxEntity.renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public SceneData ImpossibleScenarios() {
            SceneData scene = new SceneData();
            
            Circle2DEntity bigCircle = new Circle2DEntity(new Vector2(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.body.Mass = 20;
            bigCircle.body.Damping = 1;
            bigCircle.body.Restitution = .7;
            bigCircle.body.AddForce(new Vector2(10000, 0), ForceMode.Impulse);
            bigCircle.renderer.SetBounds(ColorSettings.YellowBrush, 1.5);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new Vector2(360, 250), 40, 100, ColorSettings.TransparentBrush);
            boxEntity.body.SetKinematic(true);
            boxEntity.renderer.SetBounds(ColorSettings.YellowBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.NoGravity);
            PhysicsSettings.SetFixedTimeStep(.07);
            return scene;
        }

        public SceneData LargeSet() {
            SceneData scene = new SceneData();
            
            for (int i = 1; i < 20; i++)
                for (int j = 1; j < 20; j++) {
                    Vector2 position = new Vector2(i * 25 + rnd.Next(-1, 1), j * 25 + rnd.Next(-1, 1));
                    Circle2DEntity circle = new Circle2DEntity(position, 4, ColorSettings.WhiteBrush);
                    circle.body.AddForce(new Vector2(rnd.Next(-1000, 1000), rnd.Next(-1000, 1000)));
                    circle.body.Damping = .9;
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            PhysicsSettings.SetGravity(PhysicsSettings.EarthGravity);
            PhysicsSettings.SetFixedTimeStep(.02);
            return scene;
        }

        void AddWalls(SceneData sceneData) {
            Box2DEntity right = new(new Vector2(520, 250), 40, 580, ColorSettings.TransparentBrush);
            right.body.SetKinematic(true);
            Box2DEntity left = new(new Vector2(-20, 250), 40, 580, ColorSettings.TransparentBrush);
            left.body.SetKinematic(true);
            Box2DEntity top = new(new Vector2(250, -20), 580, 40, ColorSettings.TransparentBrush);
            top.body.SetKinematic(true);
            Box2DEntity bottom = new(new Vector2(250, 520), 580, 40, ColorSettings.TransparentBrush);
            bottom.body.SetKinematic(true);

            sceneData.AddEntity(right);
            sceneData.AddEntity(left);
            sceneData.AddEntity(top);
            sceneData.AddEntity(bottom);
        }
    }
}
