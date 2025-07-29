using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Uobachi.Application;

public class Store<TState, TAction> : IObservable<TState>, IDisposable
{
    private readonly BehaviorSubject<TState> state;
    private readonly Subject<TAction> actions = new();
    private readonly IDisposable reducerSubscription;

    public Store(TState initialState, Func<TState, TAction, TState> reducerFn)
    {
        state = new BehaviorSubject<TState>(initialState);
        reducerSubscription = actions
            .Scan(initialState, reducerFn)
            .Subscribe(state);
    }

    public TState Current => state.Value;
    
    // ReSharper disable once InconsistentlySynchronizedField
    public IDisposable Subscribe(IObserver<TState> observer) => state.Subscribe(observer);

    public void Apply(TAction action) => actions.OnNext(action);

    public void Dispose()
    {
        reducerSubscription.Dispose();
        state.Dispose();
        actions.Dispose();
    }
}
