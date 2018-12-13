using System;
using UniRx;

namespace Presets {
    public interface IStartable {
        IObservable<Unit> CompleteSetUpPresets { get; }
    }
}