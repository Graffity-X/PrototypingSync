using System;
using System.Collections.Generic;
using System.Linq;
using Systems;
using Battles.Enemys;
using Battles.Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackControll : MonoBehaviour {
        [SerializeField] private LineRendererControll lineRendererControll;

        private EnemyLifeControll enemyLifeControll;
        private IObservable<bool> attackStream=new Subject<bool>();

        public bool IsActive => lineRendererControll.draw;
        private int attackerNum;

        private List<bool> triggers=new List<bool>();
        
        private void Start() {
            enemyLifeControll = this.GetComponent<EnemyLifeControll>();
            lineRendererControll.LineHitStream.Subscribe(n => enemyLifeControll.Damage());
        }

        public void SetUp(AttackByPath attack_by_path) {
            triggers.Add(false);
            var a = attackerNum++;
            attack_by_path.AttackStream.Subscribe(n => { ValueChange(n, a); });
            
            ScrollLogger.Log("setup attack");
        }

        private void ValueChange(bool f, int i) {
            Debug.Log(i);
            triggers[i] = f;
        }

        public void Launch() {
            Observable.EveryUpdate()
                .Subscribe(n => {
                        lineRendererControll.draw = triggers[0]||triggers[1];
                        lineRendererControll.isActive = triggers[0]&&triggers[1];
                   
                });
            lineRendererControll.SetUp(this.GetComponent<PlayersManage>().Players.ToArray());
            ScrollLogger.Log("Launch attack");
        }
    }
}