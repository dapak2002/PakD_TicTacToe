using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton : MonoBehaviour
{
    private void OnMouseUp()
    {
        Debug.Log("Application Quit");
        Application.Quit();
    }
}
