using UnityEngine;

namespace Battles.Players {
    public class BodyControll : MonoBehaviour {
        public GameObject body;

        private void Update() {
            if (body == null) return;
            body.transform.position = this.transform.position;
        }
    }
}