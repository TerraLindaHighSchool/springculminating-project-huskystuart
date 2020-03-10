using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> findObjects;
    public Transform selectedObject;

    //the difference between selectedObject and selected is that selectedObject contains the GUI object that the selected object (not selectedObject) will be attached to
    //while selected contains a reference to the actual object
    private GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
