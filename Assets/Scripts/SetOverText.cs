using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetOverText : MonoBehaviour
{
    Text gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.gameOver && Enamy.score != 0) gameOver.text = "Great Work!! \nYour Score : " + Enamy.score;
        else if (PlayerController.gameOver && Enamy.score == 0) gameOver.text = "Game \nOver !!"; 
    }
}
