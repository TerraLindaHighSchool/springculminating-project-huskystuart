using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform textBox;

    public bool activeTextWindow = false;
    
    public void toggleTextWindow()
    {
        if (textBox.gameObject.activeSelf)
        {
            textBox.gameObject.SetActive(false);
            activeTextWindow = false;
        } else
        {
            textBox.gameObject.SetActive(true);
            activeTextWindow = true;
        }
    }
}
