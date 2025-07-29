using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace Uobachi.Application;

public class Store<TState, TAction, TEnrichedState> : IObservable<TEnrichedState>, IDisposable
{
    private readonly BehaviorSubject<TEnrichedState> state;
    private readonly Subject<TAction> actions = new();
    private readonly IDisposable reducerSubscription;

    protected Store(TState initialState, Func<TState, TAction, TState> reducerFn, Func<TState, TEnrichedState> enrichFn)
    {
        state = new(enrichFn(initialState));
        reducerSubscription = actions
            .Scan(initialState, reducerFn)
            .Select(enrichFn)
            .Subscribe(state);
    }

    public TEnrichedState Current => state.Value;
    
    public IDisposable Subscribe(IObserver<TEnrichedState> observer) => state.Subscribe(observer);

    public void Apply(TAction action) => actions.OnNext(action);

    public void Dispose()
    {
        reducerSubscription.Dispose();
        state.Dispose();
        actions.Dispose();
    }
}
