using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public Transform textBox;

    public bool activeTextWindow = false;

    public Camera camera2;
    public Material cameraMaterial;
    public Camera camera1;
    public Material cameraMaterial2;

    private void Start()
    {
        camera2.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterial.mainTexture = camera2.targetTexture;
        camera1.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMaterial2.mainTexture = camera1.targetTexture;
    }

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
