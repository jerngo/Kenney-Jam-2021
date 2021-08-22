using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Holder : MonoBehaviour
{
    // Update is called once per frame
    public float moveSpeed = 1;
    private void Update()
    {
        LookAtMousePos();
    }

    void LookAtMousePos()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);

        Vector3 dir = mousePos - playerPos;

        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(-angle, Vector3.up);
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
    }
}
