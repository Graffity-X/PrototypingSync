using System;
using UniRx;
using UnityEngine;

namespace Presets.ByPrintImage {
    public class ImageAnchorObserver : MonoBehaviour,IStartable {
        public ImageAnchorCreator imageAnchorCreator;
        
        public bool AbleFg { get; private set; }
        private Subject<bool> changeAbleStream=new Subject<bool>();
        public IObservable<bool> ChangeAbleStream => changeAbleStream;

        public void Launch() {
            var anc = imageAnchorCreator.ImageAnchorGo;
            if (anc == null) return;
            
            changeAbleStream.OnNext(true);
        }
    }
}