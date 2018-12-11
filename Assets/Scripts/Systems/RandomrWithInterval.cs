using System;
using UniRx;
using Random = UnityEngine.Random;

namespace Systems {
    public class RandomrWithInterval {

        private Subject<float> publishStream=new Subject<float>();
        public IObservable<float> PublishStream=>publishStream;
        
        public RandomrWithInterval(float min,float max,float interval,float interval_range=1) {
            Observable
                .Timer(TimeSpan.FromSeconds(Random.Range(interval /interval_range, interval * interval_range)))
                .Repeat()
                .Subscribe(n => { publishStream.OnNext(Random.Range(min, max)); });
        }
    }
}