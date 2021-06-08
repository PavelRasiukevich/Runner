using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class AppDirector : MonoBehaviour
{
    protected virtual void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
