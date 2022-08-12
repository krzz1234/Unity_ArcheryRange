using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     Rigidbody rb = GetComponent<Rigidbody>();
    if(rb.velocity.magnitude > 0.5) { transform.rotation = Quaternion.LookRotation(rb.velocity, Vector3.up);
    }
    }
    
    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Target"){
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.isKinematic = true;
            
        }
    }
}
