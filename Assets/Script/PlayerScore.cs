using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] int score;
    [SerializeField] TMP_Text scoreText;

    void Start()
    {
        scoreText.text = "Has Obtenido =" + score;
    }


    public void AddScore(int scoreParameter)
    {   
                score = score + scoreParameter;
                scoreText.text = "Has Obtenido =" + score;
    }

    public int GetScore()
    {
        return score;
    }
}

