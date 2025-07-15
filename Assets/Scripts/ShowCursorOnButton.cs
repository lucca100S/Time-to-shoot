using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowCursorOnButton : MonoBehaviour
{
    public GameObject cursor;
    
    public void ShowCursor()
    {
        cursor.SetActive(true);
        AudioController.instance.PlaySFX(7);
    }

    public void HideCursor()
    {
        cursor.SetActive(false);
    }

    private void OnDisable()
    {
        HideCursor();
    }
}
