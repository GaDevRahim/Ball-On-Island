using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScoreText : MonoBehaviour
{

    Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        if (PlayerController.gameOver) score.text = "";
        else score.text = "Score : " + Enamy.score;
    }
}
