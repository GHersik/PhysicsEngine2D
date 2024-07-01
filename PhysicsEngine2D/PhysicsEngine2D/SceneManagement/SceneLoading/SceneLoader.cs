using Physics;
using PhysicsEngine2D;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SimulationWindow.SceneManagement {
    public class SceneLoader {

        public enum Scene {
            Ambient,
            BrownianMotion,
            BoxVsCircle
        }

        private Scenes scenes = new Scenes();
        private SceneManager sceneManager;

        private Rectangle fadeRect;
        private readonly SolidColorBrush FadeBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        private readonly TimeSpan fadeIntervalTime = TimeSpan.FromMilliseconds(10);
        private byte colorFadeAlpha;
        private CancellationTokenSource? cts;

        public SceneLoader(SceneManager sceneManager, Rectangle fadeRectangle) {
            this.sceneManager = sceneManager;
            fadeRect = fadeRectangle;
        }

        public async Task LoadSceneAsync(Scene scene) {
            Task taskFade = FadeShow(fadeRect);
            await taskFade;

            SceneData newSceneData = GetProperSceneData(scene);
            sceneManager.SetNewSceneData(newSceneData);
            sceneManager.Update();
            await Task.Delay(1000);

            Task taskShow = FadeHide(fadeRect);
            await taskShow;
        }

        public async Task LoadDefaultSceneAsync() {
            SceneData newSceneData = GetProperSceneData(Scene.Ambient);
            sceneManager.SetNewSceneData(newSceneData);
            sceneManager.Update();
            await Task.Delay(1000);

            Task taskShow = FadeHide(fadeRect);
            await taskShow;
        }

        private SceneData GetProperSceneData(Scene scene) {
            switch (scene) {
                case Scene.Ambient:
                    return scenes.Ambient();
                case Scene.BrownianMotion:
                    return scenes.BrownianMotion();
                case Scene.BoxVsCircle:
                    return scenes.CircleVsBox();
                default:
                    return scenes.Ambient();
            }
        }

        public async Task FadeShow(Rectangle rectToFade) {
            await StartFade(rectToFade, 0, 255);
        }

        public async Task FadeShow() {
            await StartFade(fadeRect, 0, 255);
        }

        public async Task FadeHide(Rectangle rectToFade) {
            await StartFade(rectToFade, 255, 0);
        }

        public async Task FadeHide() {
            await StartFade(fadeRect, 255, 0);
        }

        private async Task StartFade(Rectangle rectToFade, byte startAlpha, byte endAlpha) {
            StopCurrentFade();
            fadeRect = rectToFade;
            colorFadeAlpha = startAlpha;
            cts = new CancellationTokenSource();
            try {
                await FadeUpdate(endAlpha, cts.Token);
            }
            catch (OperationCanceledException) {
                // Handle cancellation if needed
            }
        }

        private async Task FadeUpdate(byte targetAlpha, CancellationToken cancellationToken) {
            if (fadeRect == null) return;

            while (colorFadeAlpha != targetAlpha) {
                cancellationToken.ThrowIfCancellationRequested();
                colorFadeAlpha = (byte)(targetAlpha > colorFadeAlpha ? colorFadeAlpha + 5 : colorFadeAlpha - 5);
                FadeBrush.Color = Color.FromArgb(colorFadeAlpha, FadeBrush.Color.R, FadeBrush.Color.G, FadeBrush.Color.B);
                fadeRect.Fill = FadeBrush;
                await Task.Delay(fadeIntervalTime, cancellationToken);
            }
        }

        private void StopCurrentFade() {
            if (cts != null) {
                cts.Cancel();
                cts.Dispose();
                cts = null;
            }
        }
    }
}
