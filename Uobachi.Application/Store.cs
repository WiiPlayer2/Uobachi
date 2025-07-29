using System;
using System.Reactive.Subjects;

namespace Uobachi.Application;

public class Store<TState, TAction>(TState initialState, Func<TState, TAction, TState> reducerFn) : IObservable<TState>
{
    private readonly BehaviorSubject<TState> subject = new(initialState);

    public TState Current => subject.Value;
    
    // ReSharper disable once InconsistentlySynchronizedField
    public IDisposable Subscribe(IObserver<TState> observer) => subject.Subscribe(observer);

    public void Apply(TAction action)
    {
        lock(subject)
            subject.OnNext(reducerFn(subject.Value, action));
    }
}
