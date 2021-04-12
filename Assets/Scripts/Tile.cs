using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public TileManager tileManager;
    public TileManager.Owner owner;

    private void OnMouseUp()
    {
        // Check for current player that is claiming ownership of this space
        owner = tileManager.CurrentPlayer;

        // Set the sprite color to represent the owner (Sword = Blue, Shield = Red)
        if (owner == TileManager.Owner.Sword)
            ChangeToSword();
        else if (owner == TileManager.Owner.Shield)
            ChangeToShield();

        // Update to the next player in rotation
        tileManager.ChangePlayer();
    }

    public void ChangeToShield()
    {
        this.GetComponent<SpriteRenderer>().sprite = tileManager.shieldSprite;
    }


    public void ChangeToSword()
    {
        this.GetComponent<SpriteRenderer>().sprite = tileManager.swordSprite;
    }


    public void ResetTile()
    {
        this.GetComponent<SpriteRenderer>().sprite = tileManager.defaultSprite;
        owner = tileManager.CurrentPlayer;
    }
}

