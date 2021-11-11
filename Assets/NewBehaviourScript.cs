using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 1f;
    public Rigidbody2D rb;
    public float height = 1f;

    // Start is called before the first frame update
    void Start()
    {
        

    }
    void Update() {
        
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(Input.mousePosition);
            rb.velocity = (transform.right * speed) + (transform.up * height);
        }
    }

}
