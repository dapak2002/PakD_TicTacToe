using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text swordText;
    public Text shieldText;

    private int swordScore;
    private int shieldScore;

    // Start is called before the first frame update
    void Start()
    {
        swordScore = 0;
        shieldScore = 0;
        UpdateScores();
    }

    public void SwordWin()
    {
        swordScore++;
    }

    public void ShieldWin()
    {
        shieldScore++;
    }

    public void UpdateScores()
    {
        swordText.text = "Sword: " + swordScore;
        shieldText.text = "Shield: " + shieldScore;
    }
}
