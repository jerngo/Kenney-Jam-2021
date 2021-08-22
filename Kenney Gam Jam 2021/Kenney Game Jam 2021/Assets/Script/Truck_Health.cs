using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Truck_Health : MonoBehaviour
{
    public float health = 100;
    bool ableToRecieveHit = true;
    public Animator bloodPanel;

    AudioManager audioM;

    public GameObject deadPanel;

    private void Start()
    {
        audioM = GetComponent<AudioManager>();
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (health <= 0) {
            bloodPanel.SetBool("Dead",true);
            deadPanel.SetActive(true);
            audioM.Play("TruckDead");
            FindObjectOfType<Truck_Cont>().enabled = false;
            FindObjectOfType<GunDefault>().enabled = false;
            FindObjectOfType<Gun_Holder>().enabled = false;
            FindObjectOfType<Truck_Health>().enabled = false;

        }
    }

    public void decreaseHealth(float healthDecrease) {
        if (ableToRecieveHit) {

            audioM.Play("GetHit");
            bloodPanel.SetTrigger("Blood");
            health -= healthDecrease;
            StartCoroutine(cooldownHealthHit(1));

        }
       
    }

    IEnumerator cooldownHealthHit(int cooldownTime) {
        ableToRecieveHit = false;
        yield return new WaitForSeconds(cooldownTime);
        ableToRecieveHit = true;
    }
}
