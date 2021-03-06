using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseManager : MonoBehaviour
{
    protected abstract void Awake();

}

public abstract class BaseManager<T> : BaseManager where T : BaseManager
{
    protected override void Awake()
    {
        if (Instance)
            throw new System.Exception("Instance not null");

        Instance = this as T;
    }

    public static T Instance { get; private set; }
}
