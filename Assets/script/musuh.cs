using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musuh : MonoBehaviour
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
            //pake nyawa
            KomponenGerak.nyawa --;
            //buat respawn
            KomponenGerak.ulang = true;

            //buat menghilangkan si sprite yang di pilih di atas
            //Destroy(KomponenGerak.gameObject);

            //Destroy(gameObject);// untuk menghilangkan objek musuh
        }
    }
}
