using System;
using System.Collections.Concurrent;
using UnityEngine;

public class Dispatcher : MonoBehaviour
{
    private static ConcurrentQueue<Action> _dispatchQueue;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        _dispatchQueue = new ConcurrentQueue<Action>();
    }

    private void Update()
    {
        if (_dispatchQueue.TryDequeue(out var action))
        {
            action();
        }
    }

    public static void Do(Action action)
    {
        _dispatchQueue.Enqueue(action);
    }
}
