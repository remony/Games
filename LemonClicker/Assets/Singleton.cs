using UnityEngine;
using System;

/** Singleton implementation */
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static readonly Lazy<T> LazyInstance = new Lazy<T>(CreateSingleton);

    public static T Instance => LazyInstance.Value;

    private static T CreateSingleton() {
        var _object = new GameObject($"{typeof(T).Name} (singleton)");
        var instance = _object.AddComponent<T>();
        DontDestroyOnLoad(_object);
        return instance;
    }
}
