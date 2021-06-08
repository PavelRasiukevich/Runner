using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameDirector : SceneDirector
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
            {
                SetCurrentScreen<GameScreen>().ShowAndStartGame();
            }
        }
        else if (_screenType == typeof(GameScreen))
        {
            if (_exitCode.Equals(GameScreen.EXIT_TO_RESULT))
                SetCurrentScreen<ResultScreen>().Show();
        }
        else if (_screenType == typeof(ResultScreen))
        {
            if (_exitCode.Equals(ResultScreen.EXIT_TO_GAME))
                SceneManager.LoadScene(SceneId.Game_ID);
        }
    }
}
