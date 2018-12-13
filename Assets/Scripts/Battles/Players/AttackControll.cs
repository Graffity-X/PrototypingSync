using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackControll : MonoBehaviour {
        private Subject<Unit> attackStream=new Subject<Unit>();
        public IObservable<Unit> AttackStream => attackStream;

        public void Attack() {
            attackStream.OnNext(Unit.Default);
            ScrollLogger.Log("attttt");
        }
    }
}