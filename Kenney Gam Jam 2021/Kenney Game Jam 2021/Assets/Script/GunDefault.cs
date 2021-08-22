using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunDefault : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    Animator anim;

    public float shootSpeed;
    AudioManager audioM;
    // Start is called before the first frame update
    void Start()
    {
        audioM = GetComponent<AudioManager>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            anim.SetTrigger("Shoot");
            shoot();
        }
    }

    void shoot() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(-bullet.transform.forward * shootSpeed, ForceMode.Impulse);
    }
}
