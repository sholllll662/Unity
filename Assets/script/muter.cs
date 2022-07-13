using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//perintah untuk kincir
public class muter : MonoBehaviour
{
    public int kecepatanX,kecepatanY,kecepatanZ;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(kecepatanX,kecepatanY,kecepatanZ);//untuk muter balik
    }
}
