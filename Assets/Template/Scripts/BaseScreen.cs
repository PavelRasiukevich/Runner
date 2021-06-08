using System;
using UnityEngine;

public abstract class BaseScreen : MonoBehaviour
{
    public Action<Type, string> OnExitAction;

    public bool IsShow => gameObject.activeSelf;
 
    public virtual void Init(Action<Type,string> _exitAction)
    {
        OnExitAction = _exitAction;
    }

    public virtual void Show()
    {
        gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        gameObject.SetActive(false);
    }

    protected virtual void Exit(string _exitCode)
    {
        OnExitAction.Invoke(GetType(),_exitCode);
    }
}
