using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingStationParticleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position != transform.parent.position)
        {
            transform.position = new Vector3(transform.parent.position.x - (float)0.8, transform.parent.position.y, transform.parent.position.z + (float)1.377);
        }
    }
}
