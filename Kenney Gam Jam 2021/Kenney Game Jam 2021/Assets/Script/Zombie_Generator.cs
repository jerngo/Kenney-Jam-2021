using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie_Generator : MonoBehaviour
{
    public Transform truck;
    public float offsetZ;

    public GameObject zombieFastPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnZombie(2));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(transform.position.x, transform.position.y, truck.position.z + offsetZ);
    }

    IEnumerator SpawnZombie(int delay) {
        GameObject[] zombies = GameObject.FindGameObjectsWithTag("HardObject");
        if (zombies.Length < 6) {
            GameObject zombie = Instantiate(zombieFastPrefab, transform.position, transform.rotation);
            zombie.GetComponent<Zombie_Cont>().MoveSpeed = 10;
            yield return new WaitForSeconds(delay);
            StartCoroutine(SpawnZombie(2));
        }
    }
}
