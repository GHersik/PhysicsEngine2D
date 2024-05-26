using System.Windows.Media;

namespace SimulationWindow {
    public static class ColorSettings {

        public static SolidColorBrush BlueBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 77, 150, 255));
        public static SolidColorBrush YellowBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 217, 61));
        public static SolidColorBrush RedBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 107, 107));
        public static SolidColorBrush GreenBrush { get; } = new SolidColorBrush(Color.FromArgb(255, 255, 107, 107));
    }
}
