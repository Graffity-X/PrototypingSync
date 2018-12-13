using Battles.Enemys;
using Battles.Players;
using UnityEngine;
using UniRx;

namespace Battles.Systems {
    public class BattleStarter : MonoBehaviour {
        
        private void Start() {

            this.GetComponent<BattleSetUpWait>().SetUpCompleteStream.Subscribe(n => {
                this.GetComponent<EnemyCreater>().Launch();
                this.GetComponent<AttackControll>().Launch();
            });
        }
    }
}