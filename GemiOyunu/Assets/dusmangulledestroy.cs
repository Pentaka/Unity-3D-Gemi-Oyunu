using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dusmangulledestroy : MonoBehaviour
{
    public AudioClip ses;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (gameObject.transform.position.y <= -17f)
        {
            Destroy(this.gameObject, 3f);

        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
    }
}
