using System;
using System.Reactive.Subjects;

namespace Uobachi.Application;

public class Store<T>(T initialState) : IObservable<T>
{
    private readonly BehaviorSubject<T> subject = new(initialState);

    public T Current => subject.Value;
    
    // ReSharper disable once InconsistentlySynchronizedField
    public IDisposable Subscribe(IObserver<T> observer) => subject.Subscribe(observer);

    public void Apply(Func<T, T> fn)
    {
        lock(subject)
            subject.OnNext(fn(subject.Value));
    }
}
