using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCounterScript : MonoBehaviour
{   

    public int layerCount;
    // Start is called before the first frame update
    void Start()
    {
        layerCount -= 4;
        
    }

    public void incrementCounter(){
        Debug.Log(666);
        layerCount -= 1;
    }

    public int returnCount() {
        return layerCount;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
