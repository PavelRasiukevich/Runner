using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuScreen : BaseScreen
{
    public const string Exit_Setting = "Exit_Settings";
    public const string Exit_Game = "Exit_Game";

    [SerializeField] ScorePanel scorePanel;

    public override void Show()
    {
        base.Show();
        scorePanel.SetScore(GameInfo.Instance.BestScore);
    }

    public void OnSettingsPressed()
    {
        Exit(Exit_Setting);
    }

    public void OnGamePressed()
    {
        Exit(Exit_Game);
    }
}
