using System;
using System.Windows.Controls;
using System.Windows.Shapes;
using PhysicsLibrary;

namespace SimulationWindow {
    public class PhysicsObjectTracker {

        IRenderer? renderer = null;

        TextBlock positionTextBlock;
        TextBlock velocityTextBlock;
        TextBlock totalForcesTextBlock;
        TextBlock massTextBlock;

        public PhysicsObjectTracker(TextBlock positionTextBlock, TextBlock velocityTextBlock, TextBlock accelerationTextBlock, TextBlock massTextBlock) {
            this.positionTextBlock = positionTextBlock;
            this.velocityTextBlock = velocityTextBlock;
            this.totalForcesTextBlock = accelerationTextBlock;
            this.massTextBlock = massTextBlock;
        }

        public void SetNewObjectToTrack(IRenderer renderer) {
            EvaluateNewObject(renderer);
            DisplayObjectProperties();
        }

        void EvaluateNewObject(IRenderer newRenderer) {
            if (renderer == newRenderer)
                return;
            if (renderer != null)
                renderer.SetBounds(ColorSettings.WhiteBrush, 3);
            if (newRenderer != null)
                newRenderer.SetBounds(ColorSettings.YellowBrush, 3);

            renderer = newRenderer;
        }

        public void ResetTrackedObject() {
            renderer = null;
            ResetProperties();
        }

        public void FixedUpdate() {
            DisplayObjectProperties();
        }

        void DisplayObjectProperties() {
            if (renderer == null)
                return;

            TrackVectorProperty(positionTextBlock, renderer.AttachedEntity.Transform.position);
            TrackVectorProperty(velocityTextBlock, renderer.AttachedEntity.Body.Velocity);
            TrackVectorProperty(totalForcesTextBlock, renderer.AttachedEntity.Body.TotalForce * PhysicsSettings.FixedTimeStep);
            TrackNumericProperty(massTextBlock, renderer.AttachedEntity.Body.Mass);
        }

        void TrackVectorProperty(TextBlock textBlock, Vector2 value) {
            double valueX = Math.Round(value.x, 2);
            double valueY = Math.Round(value.y, 2);
            textBlock.Text = $"({valueX}, {valueY})";
        }

        void TrackNumericProperty(TextBlock textBlock, double value) {
            value = Math.Round(value, 2);
            textBlock.Text = $"{value}";
        }

        void ResetProperties() {
            positionTextBlock.Text = "(0,0)";
            velocityTextBlock.Text = "(0,0)";
            totalForcesTextBlock.Text = "(0,0)";
            massTextBlock.Text = "0";
        }
    }
}
