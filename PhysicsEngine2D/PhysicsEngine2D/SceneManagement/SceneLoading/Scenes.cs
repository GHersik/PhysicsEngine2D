using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using PhysicsLibrary;

namespace SimulationWindow {

    public static class Scenes {

        static readonly Random rnd = new();

        public static SceneData Ambient() {
            SceneData scene = new();

            for (int i = 1; i < 10; i++)
                for (int j = 1; j < 10; j++) {
                    Vector2 position = new(i * 50 + rnd.Next(-18, 18), j * 50 + rnd.Next(-18, 18));
                    int massAndRadius = rnd.Next(4, 8);
                    Circle2DEntity circle = new(position, massAndRadius, ColorSettings.WhiteBrush);
                    circle.Body.Mass = massAndRadius;
                    circle.Body.Damping = 1;
                    circle.Body.AddForce(new Vector2(rnd.Next(-200, 200), rnd.Next(-200, 200)), ForceMode.Impulse);
                    circle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            return scene;
        }

        public static SceneData BrownianMotion() {
            SceneData scene = new();

            for (int i = 1; i < 18; i++)
                for (int j = 1; j < 8; j++) {
                    Vector2 position = new(i * 28, j * 28);
                    Circle2DEntity circle = new(position, 4, ColorSettings.WhiteBrush);
                    circle.Body.Mass = 4;
                    circle.Body.Damping = 1;
                    circle.Body.AddForce(new Vector2(rnd.Next(-300, 300), rnd.Next(-300, 300)), ForceMode.Impulse);
                    circle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
                    circle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
                    scene.AddEntity(circle);
                }

            Circle2DEntity bigCircle = new(new Vector2(250, 400), 20, ColorSettings.WhiteBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            AddWalls(scene);
            return scene;
        }

        public static SceneData RestingContact() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(250, 100), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = .9;
            bigCircle.Body.Restitution = .7;
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(250, 400), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            return scene;
        }

        public static SceneData BilliardSample() {
            SceneData scene = new();

            double x = 190;
            for (int i = 0; i < 5; i++) {
                double y = 100 + i * 21;
                for (int j = 0; j < 5 - i; j++) {
                    Vector2 position = new(x + j * 24 + i * 12, y);
                    Circle2DEntity circle = new(position, 12, ColorSettings.WhiteBrush);
                    circle.Body.Damping = .7;
                    scene.AddEntity(circle);
                }
            }

            Circle2DEntity whiteBall = new(new Vector2(250, 400), 12, ColorSettings.WhiteBrush);
            whiteBall.Body.Damping = .7;
            whiteBall.Body.AddForce(new(rnd.Next(-40, 40), -rnd.Next(200, 500)), ForceMode.Impulse);
            scene.AddEntity(whiteBall);

            AddWalls(scene);
            return scene;
        }

        public static SceneData Tunneling() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(100, 250), 40, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(2500, 0), ForceMode.VelocityChange);
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 250), 40, 200, ColorSettings.TransparentBrush);
            boxEntity.Body.Mass = 20;
            boxEntity.Body.Restitution = 1;
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            return scene;
        }

        public static SceneData MarginalBounds() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new Vector2(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(11000, 0), ForceMode.Impulse);
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 280), 100, 40, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            return scene;
        }

        public static SceneData Gravity() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(250, 100), 60, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            return scene;
        }

        public static SceneData EnergyConservation() {
            SceneData scene = new();

            Circle2DEntity smallCircle = new(new(150, 250), 24, ColorSettings.TransparentBrush);
            smallCircle.Body.Mass = 4;
            smallCircle.Body.Restitution = 1;
            smallCircle.Body.AddForce(new(15, 0), ForceMode.VelocityChange);
            smallCircle.Body.Damping = 1;
            smallCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(smallCircle);

            Circle2DEntity bigCircle = new(new(350, 250), 60, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Restitution = 1;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.AddForce(new(-5, 0), ForceMode.VelocityChange);
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            return scene;
        }

        public static SceneData ImpossibleScenarios() {
            SceneData scene = new();

            Circle2DEntity bigCircle = new(new(100, 250), 20, ColorSettings.TransparentBrush);
            bigCircle.Body.Mass = 20;
            bigCircle.Body.Damping = 1;
            bigCircle.Body.Restitution = .7;
            bigCircle.Body.AddForce(new(10000, 0), ForceMode.Impulse);
            bigCircle.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(bigCircle);

            Box2DEntity boxEntity = new(new(360, 250), 40, 100, ColorSettings.TransparentBrush);
            boxEntity.Body.SetKinematic(true);
            boxEntity.Renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            scene.AddEntity(boxEntity);

            AddWalls(scene);
            return scene;
        }

        public static SceneData LargeSet() {
            SceneData scene = new();

            for (int i = 1; i < 20; i++)
                for (int j = 1; j < 20; j++) {
                    Vector2 position = new(i * 25 + rnd.Next(-1, 1), j * 25 + rnd.Next(-1, 1));
                    Circle2DEntity circle = new(position, 4, ColorSettings.WhiteBrush);
                    circle.Body.AddForce(new(rnd.Next(-1000, 1000), rnd.Next(-1000, 1000)));
                    circle.Body.Damping = .9;
                    scene.AddEntity(circle);
                }

            AddWalls(scene);
            return scene;
        }

        static void AddWalls(SceneData sceneData) {
            Box2DEntity right = new(new(520, 250), 40, 580, ColorSettings.TransparentBrush);
            right.Body.SetKinematic(true);
            Box2DEntity left = new(new(-20, 250), 40, 580, ColorSettings.TransparentBrush);
            left.Body.SetKinematic(true);
            Box2DEntity top = new(new(250, -20), 580, 40, ColorSettings.TransparentBrush);
            top.Body.SetKinematic(true);
            Box2DEntity bottom = new(new(250, 520), 580, 40, ColorSettings.TransparentBrush);
            bottom.Body.SetKinematic(true);

            sceneData.AddEntity(right);
            sceneData.AddEntity(left);
            sceneData.AddEntity(top);
            sceneData.AddEntity(bottom);
        }
    }
}
