using System;
using UniRx;

namespace Presets {
    public interface IStartable {
        bool AbleFg { get; }
        IObservable<bool> ChangeAbleStream { get; }
    }
}