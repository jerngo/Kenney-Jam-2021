using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public GameObject finishPanel;
    public Truck_Cont truck;
    public GameObject batch3;
    public GunDefault gun;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            finishPanel.SetActive(true);
            truck.enabled = false;
            batch3.SetActive(false);
            gun.enabled = false;
        }
    }
}
