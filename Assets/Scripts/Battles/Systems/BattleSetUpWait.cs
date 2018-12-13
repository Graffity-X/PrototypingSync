using UniRx;
using UnityEngine;

namespace Battles.Systems {
    public class BattleSetUpWait : MonoBehaviour {
        [SerializeField] private int needPlayerNum = 2;
        
        private PlayersManage playersManage;

        private Subject<Unit> setUpCompleteStream=new Subject<Unit>();
        public Subject<Unit> SetUpCompleteStream => setUpCompleteStream;

        private void Start() {
            playersManage = this.GetComponent<PlayersManage>();

            playersManage.ObserveEveryValueChanged(n => n.AmountPlayer)
                .Where(n => n >= needPlayerNum)
                .First()
                .Subscribe(n=>setUpCompleteStream.OnNext(Unit.Default));
        }
    }
}