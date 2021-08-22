using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletDefault : MonoBehaviour
{
    public GameObject destroyedParticle;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "HardObject") {
            Instantiate(destroyedParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "HardObject")
        {
            Instantiate(destroyedParticle, transform.position, transform.rotation);
            Destroy(this.gameObject);
        }
    }
}
