using UnityEngine;

namespace Debugs {
    public class Debugger:MonoBehaviour {
        public bool debug;
        public static Debugger instance;

        private void Start() {
            instance = this;
        }
    }
}