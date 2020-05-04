using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<GameObject> findObjects;
    public Transform selectedObject;

    private int score = 0;

    //the difference between selectedObject and selected is that selectedObject contains the GUI object that the selected object (not selectedObject) will be attached to
    //while selected contains a reference to the actual object
    public GameObject selected;
    // Start is called before the first frame update
    void Start()
    {
        NewObject();
    }

    public void NewObject()
    {
        selected = findObjects[Random.Range(0, findObjects.Count)];
        if (selectedObject.childCount > 0)
            Destroy(selectedObject.GetChild(selectedObject.childCount - 1).gameObject);
    }

    public void FoundObject()
    {
        score += 10;
        NewObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
