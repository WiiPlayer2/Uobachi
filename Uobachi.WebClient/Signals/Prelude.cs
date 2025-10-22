using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reactive;
using Reactive.Bindings;

namespace Uobachi.WebClient.Signals;

internal class SignalsBus
{
    public static readonly ThreadLocal<Action?> CurrentSubscriber = new();
}

internal interface ISignal<out T> : INotifyPropertyChanged
{
    T Value { get; }
}

internal interface IWritableSignal<T> : ISignal<T>
{
    new T Value { get; set; }
}

internal class Signal<T> : ISignal<T>
{
    private readonly Func<T> fn;
    private T value = default!;

    public Signal(Func<T> fn)
    {
        this.fn = fn;
        Recompute();
    }

    public T Value => value;

    private void Recompute()
    {
        SignalsBus.CurrentSubscriber.Value = Recompute;
        value = fn();
        SignalsBus.CurrentSubscriber.Value = Recompute;
        RaiseValueChanged();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RaiseValueChanged() => PropertyChanged?.Invoke(this, new(nameof(Value)));
}

internal class WritableSignal<T>(T initialValue) : IWritableSignal<T>
{
    private readonly HashSet<Action> subscribers = new();

    private T value = initialValue;
    
    public T Value
    {
        get
        {
            if (SignalsBus.CurrentSubscriber.Value is { } currentSubscriber)
                subscribers.Add(currentSubscriber);
            return value;
        }
        
        set
        {
            this.value = value;
            RaiseValueChanged();
            foreach (var subscriber in subscribers)
                subscriber();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void RaiseValueChanged() => PropertyChanged?.Invoke(this, new(nameof(Value)));
}

internal static class Prelude
{
    public static WritableSignal<T> Signal<T>(T initialValue) => new(initialValue);

    public static Signal<T> Computed<T>(Func<T> fn) => new(fn);
}