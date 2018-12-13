using System;
using UniRx;
using Random = UnityEngine.Random;

namespace Systems {
    public class RandomInterval {

        private Subject<Unit> publishStream=new Subject<Unit>();
        public IObservable<Unit> PublishStream=>publishStream;
        
        public RandomInterval(float interval,float interval_range=1) {
            Observable
                .Timer(TimeSpan.FromSeconds(Random.Range(interval /interval_range, interval * interval_range)))
                .Repeat()
                .Subscribe(n => { publishStream.OnNext(Unit.Default); });
        }
    }
}