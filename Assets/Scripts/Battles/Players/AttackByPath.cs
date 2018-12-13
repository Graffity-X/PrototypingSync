using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Battles.Players {
    public class AttackByPath : MonoBehaviour {
        private Subject<bool> attackStream=new Subject<bool>();
        public IObservable<bool> AttackStream => attackStream;

        public void Attack(bool t) {
            attackStream.OnNext(t);
        }
    }
}