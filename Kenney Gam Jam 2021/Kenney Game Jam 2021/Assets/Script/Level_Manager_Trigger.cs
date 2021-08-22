using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Manager_Trigger : MonoBehaviour
{
    public bool isStageTwo;
    public bool isFinalStage;


    public GameObject batch1;
    public GameObject batch2;
    public GameObject batch3;

    public GameObject cameraTarget;

    public Animator textAnnouncement;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
 
        if (other.gameObject.tag == "Player") {
            Debug.Log(other.gameObject.tag + " passed");
            if (isStageTwo && !isFinalStage)
            {
                textAnnouncement.SetTrigger("Play");
                textAnnouncement.GetComponent<Text>().text = "ALMOST THERE";
                batch1.SetActive(false);
                batch2.SetActive(true);
            }

            else if (isFinalStage && !isStageTwo) {
                textAnnouncement.SetTrigger("Play");
                textAnnouncement.GetComponent<Text>().text = "I CAN SEE THE EXIT";
                cameraTarget.GetComponent<CameraTarget>().threshold = 5;
                FindObjectOfType<Truck_Cont>().speedlevel = 2;
                batch2.SetActive(false);
                batch3.SetActive(true);
            }
        }
    }
}
