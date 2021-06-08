using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDirector : SceneDirector
{
    protected override void Start()
    {
        base.Start();

        SetCurrentScreen<MenuScreen>().Show();
    }

    protected override void OnScreenExit(Type _screenType, string _exitCode)
    {
        if (_screenType == typeof(MenuScreen))
        {
            if (_exitCode.Equals(MenuScreen.Exit_Game))
                SceneManager.LoadScene(SceneId.Game_ID);
            else if (_exitCode.Equals(MenuScreen.Exit_Setting))
                SetCurrentScreen<SettingsScreen>().Show();
        }
        else if (_screenType == typeof(SettingsScreen))
        {
            if (_exitCode.Equals(SettingsScreen.Exit_Back))
                ToBackScreen();
        }
    }
}
