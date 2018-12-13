using Systems;
using SPU;
using UniRx;
using UnityEngine;

namespace Presets {
    public class PresetWait : InterfaceSerializeFieldMonoBehaviour<IStartable> {

        private void Start() {
            Interface.CompleteSetUpPresets
                .Subscribe(n => this.GetComponent<SPUTransTrigger>().Launch());
        }
    }
}