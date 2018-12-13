using System.Linq;
using Systems;
using Battles.Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackControll : MonoBehaviour {
        [SerializeField] private LineRendererControll lineRendererControll;
        private Subject<bool> attackStream=new Subject<bool>();

        
        private void Start() {
         }

        public void SetUp(AttackByPath attack_by_path) {
            attackStream.Merge(attack_by_path.AttackStream);
        }

        public void Launch() {
            attackStream
                .Subscribe(n => {
                    ScrollLogger.Log(n.ToString());
                    lineRendererControll.draw = n;
                });
            lineRendererControll.SetUp(this.GetComponent<PlayersManage>().Players.ToArray());
            ScrollLogger.Log("setup attack");
        }
    }
}