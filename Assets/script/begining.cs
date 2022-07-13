using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class begining : MonoBehaviour
{
    public string pesan;
    public int kecepatan;
    public float waktu;
    public bool aktif;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        waktu += Time.deltaTime;

        if (waktu>3){
            aktif=true;
        }

        if (aktif==true){
            print (pesan);
            kecepatan=5;
        }    
    }
}
