using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public Transform bakilan_kup;
    public Transform takip_edilen_kup;

    float hiz = 1.56f;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 pozisyon = takip_edilen_kup.position;
        transform.position = Vector3.Lerp(transform.position, pozisyon, hiz * Time.deltaTime);

        transform.LookAt(bakilan_kup);
    }
}
