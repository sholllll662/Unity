using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class koin : MonoBehaviour
{
    gerak KomponenGerak;//memanggil script gerak

    // Start is called before the first frame update
    void Start()
    {
        KomponenGerak = GameObject.Find("manuk").GetComponent<gerak>();//milih spritenya
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D other){
        if (other.transform.tag == "Player"){
            KomponenGerak.koin ++;
            Destroy(gameObject);
        }
    }
}
