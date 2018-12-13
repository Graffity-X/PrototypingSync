using System;
using System.Linq;
using Systems;
using Battles.Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackControll : MonoBehaviour {
        [SerializeField] private LineRendererControll lineRendererControll;
        private IObservable<bool> attackStream=new Subject<bool>();

        private int attackerNum;
        
        private void Start() {
         }

        public void SetUp(AttackByPath attack_by_path) {
            attackStream=attackStream.Merge(attack_by_path.AttackStream);
            attackerNum++;
            ScrollLogger.Log("setup attack");
        }

        public void Launch() {
            attackStream
                .Buffer(attackerNum)
                .Subscribe(n => {
                    var able = false;
                    n.Aggregate<bool>((m, l) => able = m || l);
                    ScrollLogger.Log(able.ToString());
                    lineRendererControll.draw = able;
                });
            lineRendererControll.SetUp(this.GetComponent<PlayersManage>().Players.ToArray());
            ScrollLogger.Log("Launch attack");
        }
    }
}