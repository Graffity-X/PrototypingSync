using Systems;
using SPU;
using UniRx;
using UnityEngine;

namespace Presets {
    public class Starter : InterfaceSerializeFieldMonoBehaviour<IStartable> {

        private void Start() {
            Interface.ChangeAbleStream
                .Where(n => n)
                .Subscribe(n => this.GetComponent<SPUTransTrigger>().Launch());
        }
    }
}