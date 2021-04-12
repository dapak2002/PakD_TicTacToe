using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public ScoreManager scores;
    public Owner CurrentPlayer;
    public GameObject resetButton;
    public GameObject quitButton;
    public Sprite shieldSprite;
    public Sprite swordSprite;
    public Sprite defaultSprite;
    public Tile[] Tiles = new Tile[9];

    private int turnCount;

    public enum Owner
    {
        None,
        Sword,
        Shield
    }

    private bool won;

    // Start is called before the first frame update
    void Start()
    {
        resetButton.SetActive(false);
        quitButton.SetActive(false);
        won = false;
        turnCount = 0;
        CurrentPlayer = Owner.Sword;
    }

    public void ChangePlayer()
    {
        if (CheckForWinner())
            return;
        if (CurrentPlayer == Owner.None)
            return;
        if (CurrentPlayer == Owner.Sword)
            CurrentPlayer = Owner.Shield;
        else
            CurrentPlayer = Owner.Sword;
    }

    public bool CheckForWinner()
    {
        if (turnCount == 8)
        {
            Debug.Log("Tie Game");
            CurrentPlayer = Owner.None;
        }
        if (CurrentPlayer == Owner.None)
        {
            resetButton.SetActive(true);
            quitButton.SetActive(true);
            return true;
        }

        if (Tiles[0].owner == CurrentPlayer && Tiles[1].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[3].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[3].owner == CurrentPlayer && Tiles[6].owner == CurrentPlayer)
            won = true;
        else if (Tiles[1].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[7].owner == CurrentPlayer)
            won = true;
        else if (Tiles[2].owner == CurrentPlayer && Tiles[5].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;
        else if (Tiles[6].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[2].owner == CurrentPlayer)
            won = true;
        else if (Tiles[0].owner == CurrentPlayer && Tiles[4].owner == CurrentPlayer && Tiles[8].owner == CurrentPlayer)
            won = true;

        if (won)
        {
            resetButton.SetActive(true);
            quitButton.SetActive(true);
            Debug.Log("Winner: " + CurrentPlayer);
            if (CurrentPlayer == Owner.Sword)
                scores.SwordWin();
            else if (CurrentPlayer == Owner.Shield)
                scores.ShieldWin();
            CurrentPlayer = Owner.None;
            scores.UpdateScores();
            return true;
        }
        turnCount++;
        return false;
    }

    public void ResetBoard()
    {
        for (int i = 0; i < 9; i++)
        {
            Tiles[i].ResetTile();
        }
        won = false;
        CurrentPlayer = Owner.Sword;
        turnCount = 0;
        resetButton.SetActive(false);
        quitButton.SetActive(false);
    }
}
