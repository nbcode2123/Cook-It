

using System;
using System.Collections.Generic;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;

public class ObserverManager
{

    private static Dictionary<ObserverEvent, List<Delegate>> Listeners = new Dictionary<ObserverEvent, List<Delegate>>();
    public static void AddListener(ObserverEvent name, Action callback)
    {
        if (Listeners.ContainsKey(name))
        {
            Listeners[name].Add(callback);
        }
        else
        {
            Listeners.Add(name, new List<Delegate>());
            Listeners[name].Add(callback);
        }
    }
    public static void AddListener<T>(ObserverEvent name, Action<T> callback)
    {
        if (Listeners.ContainsKey(name))
        {
            Listeners[name].Add(callback);
        }
        else
        {
            Listeners.Add(name, new List<Delegate>());
            Listeners[name].Add(callback);
        }
    }

    public static void RemoveListener(ObserverEvent name, Action callback)
    {
        if (!Listeners.ContainsKey(name))
            return;
        if (Listeners.ContainsKey(name))
        {
            Listeners[name].Remove(callback);
        }
        if (Listeners[name].Count == 0)
        {
            Listeners.Remove(name);

        }


    }
    public static void RemoveListener<T>(ObserverEvent name, Action<T> callback)
    {
        if (!Listeners.ContainsKey(name))
            return;
        if (Listeners.ContainsKey(name))
        {
            Listeners[name].Remove(callback);
        }
        if (Listeners[name].Count == 0)
        {
            Listeners.Remove(name);

        }


    }
    public static void Notify<T>(ObserverEvent name, T param)
    {
        if (!Listeners.ContainsKey(name)) return;

        for (int i = 0; i < Listeners[name].Count; i++)
        {
            if (Listeners[name][i] is Action<T> action)
            {

                action?.Invoke(param);


            }
        }
    }
    public static void Notify(ObserverEvent name)
    {
        if (!Listeners.ContainsKey(name))
        {
            return;
        }
        for (int i = 0; i < Listeners[name].Count; i++)
        {
            if (Listeners[name][i] is Action action)
            {

                action?.Invoke();


            }
        }
    }
}
public enum ObserverEvent
{
    EndMoveNavigation,
    RayCastDetectPoint,
    RayCastDetectObj,
    TriggerObjectTakeItem,
    PutItemToShelf
}
