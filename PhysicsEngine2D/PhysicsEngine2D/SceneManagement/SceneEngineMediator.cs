using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulationWindow.SceneManagement {

    public delegate void FixedUpdateHandler(object sender, SomeEventArgs e);

    public static class SceneEngineMediator {

        public static event FixedUpdateHandler FixedUpdate;

        public static void RaiseFixedUpdateEvent(object sender, SomeEventArgs e) {
            FixedUpdate?.Invoke(sender, e);
        }


    }

    public class SomeEventArgs : EventArgs {
        public string? Message { get; set; }
    }
}
