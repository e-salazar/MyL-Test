using DesignPatterns;
using Interfaces;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : Singleton<PoolingManager> {
    public Transform poolTransform;
    public Transform prefabsTransform;

    private Dictionary<Type, object> objectsPool = new Dictionary<Type, object>();

    public override void Awake() {
        base.Awake();
        CreateObjectPool<Scene3.Components.UIPost>(100);
        CreateObjectPool<Scene3.Components.UIComment>(5);
    }

    private void CreateObjectPool<T>(int initialSize) where T : MonoBehaviour, IPoolable<T> {
        if(initialSize < 0) { Debug.LogError("Error al crear el ObjectPool. El tamaño inicial del pool no puede ser negativo."); return; }

        T component = prefabsTransform.GetComponentInChildren<T>(true);
        if(component == null) { Debug.LogError("Error al crear el ObjectPool. No hay un prefab del tipo " + typeof(T) + "."); return; }

        objectsPool.Add(typeof(T), new ObjectPool<T>(initialSize, component, poolTransform));
    }
    public T New<T>() where T : MonoBehaviour, IPoolable<T> {
        object objectPool;
        if(!objectsPool.TryGetValue(typeof(T), out objectPool)) { Debug.LogError("Error al obtener el ObjectPool. No hay un ObjectPool para el tipo " + typeof(T) + "."); return null; }

        return ((ObjectPool<T>) objectPool).New();
    }
}