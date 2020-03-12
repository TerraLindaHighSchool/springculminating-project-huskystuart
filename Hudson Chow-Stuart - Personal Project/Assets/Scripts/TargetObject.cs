using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.selected == gameObject)
        {
            gameManager.FoundObject();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
