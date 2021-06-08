using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScreen : BaseScreen
{
    public const string EXIT_TO_RESULT = "EXIT_TO_RESULT";

    [SerializeField] TileMover mover;
    [SerializeField] Character character;
    [SerializeField] ScorePanel scorePanel;
    [SerializeField] TouchToCharacterAdapter adapter;

    public void ShowAndStartGame()
    {
        Show();

        adapter.RequestDirectionAction = character.OnRequestMove;
        mover.IsMoving = true;
        character.IsMoving = true;
        character.GameOver += OnGameOver;
    }

    private void Update()
    {
        scorePanel.SetScore(GameInfo.Instance.CalculateScore(mover.Distance));
    }

    public void OnGameOver()
    {
        mover.IsMoving = false;
        GameInfo.Instance.RegisterResult(mover.Distance);
        Exit(EXIT_TO_RESULT);
    }
}
