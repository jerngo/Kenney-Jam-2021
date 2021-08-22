using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Cont : MonoBehaviour
{
    public Rigidbody sphereRigid;

    public float forwardAccel=8, reverseAccel=4, maxSpeed=50, turnStrength=180;

    float forwardAccelTemp;

    public float speedInput, turnInput;

    public int speedlevel = 1;

    string truckDriveSoundName="TruckDrive";

    Animator anim;
    AudioManager audioM;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audioM = GetComponent<AudioManager>();
        sphereRigid.transform.parent = null;
        forwardAccelTemp = forwardAccel;
    }

    // Update is called once per frame
    void Update()
    {
        if (speedlevel == 1)
        {
            truckDriveSoundName = "TruckDrive";
            audioM.Stop("TruckDrive2");
            forwardAccel = forwardAccelTemp;
        }
        else if(speedlevel == 2) {
            truckDriveSoundName = "TruckDrive2";
            audioM.Stop("TruckDrive");
            forwardAccel = forwardAccelTemp + 3;
        }
        speedInput = 0;

        if (Input.GetAxis("Vertical") > 0)
        {
            speedInput = Input.GetAxis("Vertical") * forwardAccel;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel;
        }

        //turnInput = Input.GetAxis("Horizontal");
        //transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, turnInput * turnStrength * Time.deltaTime * Input.GetAxis("Vertical"), 0));


        transform.position = sphereRigid.transform.position - new Vector3(0, 0.8f, 0.8f);
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(speedInput) > 0)
        {
            audioM.Stop("TruckIdle");
            audioM.PlayOnceAtATime(truckDriveSoundName);

            anim.SetFloat("Speed", Mathf.Abs(speedInput));
            sphereRigid.AddForce(transform.forward * speedInput);
        }
        else {
            audioM.Stop(truckDriveSoundName);
            audioM.PlayOnceAtATime("TruckIdle");

            anim.SetFloat("Speed", 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyWeapon") {
            GetComponent<Truck_Health>().decreaseHealth(5);
        }
    }
}
