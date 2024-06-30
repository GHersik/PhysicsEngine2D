using System.Windows.Media;

namespace PhysicsEngine2D {
    public static class ColorSettings {
        public static SolidColorBrush BlueBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 77, 150, 255));
        public static SolidColorBrush YellowBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 217, 61));
        public static SolidColorBrush RedBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 107, 107));
        public static SolidColorBrush GreenBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 107, 203, 119));
        public static SolidColorBrush TransparentBrush { get; } = new SolidColorBrush(Color.FromArgb(0, 255, 107, 107));
        public static SolidColorBrush BlackBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
    }
}
