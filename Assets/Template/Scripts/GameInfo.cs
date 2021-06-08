using UnityEngine;

public class GameInfo : BaseManager<GameInfo>
{
    [SerializeField] int scorePerUnit;

    public int InGameScore { get; private set; }
    public int BestScore { get; private set; }

    public void RegisterResult(float _distance)
    {
        InGameScore = CalculateScore(_distance);

        if (InGameScore > BestScore)
            BestScore = InGameScore;
    }

    public int CalculateScore(float _distance)
    {
        int _score = (int)(_distance * scorePerUnit);

        return _score;
    }
}
