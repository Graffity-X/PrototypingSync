using System.Linq;
using Battles.Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackControll : MonoBehaviour {
        [SerializeField] private LineRendererControll lineRendererControll;
        private Subject<bool> attackStream=new Subject<bool>();

        private bool isActive;
        
        private void Start() {
            attackStream
                .Where(n=>this.isActive)
                .Subscribe(n => {
                lineRendererControll.draw = n;
            });
        }

        public void SetUp(AttackByPath attack_by_path) {
            attackStream.Merge(attack_by_path.AttackStream);
        }

        public void Launch() {
            isActive = true;
            lineRendererControll.SetUp(this.GetComponent<PlayersManage>().Players.ToArray());
        }
    }
}