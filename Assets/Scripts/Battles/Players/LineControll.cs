using UnityEngine;

namespace Battles.Players {
    public class LineControll : MonoBehaviour {
        public bool draw;
        public GameObject target;

        private LineRenderer lineRenderer;

        private void Awake() {
            lineRenderer = this.GetComponent<LineRenderer>();
        }

        private void Update() {
            if (draw) {
                lineRenderer.SetPosition(0,transform.position);
                lineRenderer.SetPosition(1,target.transform.position);
            }
        }
    }
}