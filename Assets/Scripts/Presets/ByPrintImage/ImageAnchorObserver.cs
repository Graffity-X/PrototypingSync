using System;
using Systems;
using UniRx;
using UnityEngine;

namespace Presets.ByPrintImage {
    public class ImageAnchorObserver : MonoBehaviour,IStartable {
        public ImageAnchorCreator imageAnchorCreator;
        
        private Subject<Unit> changeAbleStream=new Subject<Unit>();
        public IObservable<Unit> CompleteSetUpPresets => changeAbleStream;

        public void Launch() {
            var anc = imageAnchorCreator.ImageAnchorGo;
            if (anc == null) {
                ScrollLogger.Log("Missing image anchor");
                return;
            }
            
            changeAbleStream.OnNext(Unit.Default);
        }
    }
}