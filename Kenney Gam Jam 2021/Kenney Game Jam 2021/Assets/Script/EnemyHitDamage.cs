using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitDamage : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            StartCoroutine(cooldownHealthHit(1));
        }

    }

    IEnumerator cooldownHealthHit(int cooldownTime)
    {
        GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(cooldownTime);
        GetComponent<Collider>().enabled = true;
    }
}
