using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hopParticleSystemScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;

    // Update is called once per frame
    void Update(){
    if(transform.position != transform.parent.position)
        {
            transform.position = transform.parent.position;
        }
    }
}
