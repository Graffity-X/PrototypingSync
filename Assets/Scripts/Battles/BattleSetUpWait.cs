using UniRx;
using UnityEngine;

namespace Battles {
    public class BattleSetUpWait : MonoBehaviour {
        [SerializeField] private int needPlayerNum = 2;
        
        private PlayersInfo playersInfo;

        private Subject<Unit> setUpCompleteStream=new Subject<Unit>();
        public Subject<Unit> SetUpCompleteStream => setUpCompleteStream;

        private void Start() {
            playersInfo = this.GetComponent<PlayersInfo>();

            playersInfo.ObserveEveryValueChanged(n => n.AmountPlayer)
                .Where(n => n >= needPlayerNum)
                .First()
                .Subscribe(n=>setUpCompleteStream.OnNext(Unit.Default));
        }
    }
}