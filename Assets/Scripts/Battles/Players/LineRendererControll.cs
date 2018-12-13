using UnityEngine;

namespace Battles.Players {
    public class LineRendererControll : MonoBehaviour {
        public bool draw;
        public bool isActive;
        [SerializeField] private Color nonActiveColor;
        [SerializeField] private Color activeColor;
        
        private GameObject[] targets;
        
       
        private LineRenderer lineRenderer;

        private void Awake() {
            lineRenderer = this.GetComponent<LineRenderer>();
        }
         

        private void Update() {
            lineRenderer.enabled = draw;
            if (draw&&targets!=null) {
                lineRenderer.SetPosition(0,targets[0].transform.position);
                lineRenderer.SetPosition(1,targets[1].transform.position);
                lineRenderer.startColor = isActive ? activeColor : nonActiveColor;
                lineRenderer.endColor = lineRenderer.startColor;
            }
        }

        public void SetUp(GameObject[] tg) {
            if (tg.Length != 2) return;
            targets = tg;
        }
    }
}