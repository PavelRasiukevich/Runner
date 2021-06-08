using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TemplateDirector : AppDirector
{
    protected override void Awake()
    {
        base.Awake();
        SceneManager.LoadScene("Game");
    }
}
