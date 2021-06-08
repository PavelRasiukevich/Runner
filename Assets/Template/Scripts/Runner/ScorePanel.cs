using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScorePanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;

    public void SetScore(float _score)
    {
        scoreText.text = _score.ToString();
    }
}
