using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public TileManager game;

    private void OnMouseUp()
    {
        Debug.Log("Reset Clicked");
        game.ResetBoard();
    }
}

