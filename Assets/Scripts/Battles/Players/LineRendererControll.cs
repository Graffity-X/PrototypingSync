using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class LineRendererControll : MonoBehaviour {
        public bool draw;
        public bool isActive;
        [SerializeField] private Color nonActiveColor;
        [SerializeField] private Color activeColor;

        CapsuleCollider capsule;
     
        [SerializeField]private GameObject[] targets;

        private Subject<GameObject> lineHitStream=new Subject<GameObject>();
        public Subject<GameObject> LineHitStream => lineHitStream;

        private LineRenderer lineRenderer;

        private void Awake() {
            lineRenderer = this.GetComponent<LineRenderer>();
            capsule = this.GetComponent<CapsuleCollider>();
            
            
            capsule.radius = lineRenderer.startWidth/ 2;
            capsule.center = Vector3.zero;
            capsule.direction = 2; 
            
            this.ObserveEveryValueChanged(n => n.draw)
                .Subscribe(n => {
                    lineRenderer.enabled = draw;
                   
                });
            this.ObserveEveryValueChanged(n => n.isActive)
                .Subscribe(n => {
                    var col = isActive ? activeColor : nonActiveColor;
                    lineRenderer.SetColors(col, col);
                });

            
        }
         

        private void Update() {
            if (draw&&targets!=null) {
                var start = targets[0].transform;
                var target = targets[1].transform;
                lineRenderer.SetPosition(0,start.position);
                lineRenderer.SetPosition(1,target.position);
                
                capsule.transform.position = start.position + (target.position - start.position) / 2;
                capsule.transform.LookAt(start.position);
                capsule.height = (target.position - start.position).magnitude;
            }
        }

        public void SetUp(GameObject[] tg) {
            if (tg.Length != 2) return;
            targets = tg;
        }

        private void OnTriggerStay(Collider other) {
            if (other.gameObject.CompareTag("Enemy")&&isActive) {
                lineHitStream.OnNext(other.gameObject);
            }
        }
    }
}