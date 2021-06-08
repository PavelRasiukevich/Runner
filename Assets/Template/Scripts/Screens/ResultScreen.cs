using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultScreen : BaseScreen
{
    public const string EXIT_TO_GAME = "EXIT_TO_GAME";

    [SerializeField] TextMeshProUGUI scoreText;

    public override void Show()
    {
        base.Show();
        scoreText.text = GameInfo.Instance.InGameScore.ToString();
    }

    public void OnGamePressed()
    {
        Exit(EXIT_TO_GAME);
    }
}
