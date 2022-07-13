using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//perintah unuk manuk
public class gerak : MonoBehaviour
{
    //variable untuk info nyawa dan koin
    Text infonyawa,infokoin;

    //variable buat kiri kanan
    public int Kjalan,Klompat;

    //variable buat balik badan
    public bool balik;
    public int pindah;

    //variable buat lompat 1x
    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    //variable buat nyawa dan koin
    public int nyawa;
    public int koin;

    //variable buat respawn
    Vector2 mulai;
    public bool ulang;

    //variable tumbol
    public bool tombolkiri, tombolkanan;

    //variable notif menang dan kalahh
    public GameObject menang, kalah;

    Rigidbody2D lompat;
    Animator anim;

    void Start()
    {
        //lompat
        lompat = GetComponent<Rigidbody2D> ();
        //animasi gerak
        anim = GetComponent<Animator> ();
        //respawn
        mulai = transform.position;
        //nyawa dan koin
        infonyawa = GameObject.Find("UInyawa").GetComponent<Text>();
        infokoin = GameObject.Find("UIkoin").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //nampilin nyawa dan koin
        infonyawa.text = "Nyawa : " + nyawa.ToString();
        infokoin.text = "koin : " + koin.ToString();

        //respawn
        if (ulang == true){
            transform.position = mulai;
            ulang = false;
        }
        
        //nyawa karakter
        if (nyawa <= 0){
            Destroy(gameObject);
            //untuk menampilkan notif menang dan kalah
            kalah.SetActive (true);
        }else if (koin >= 3){
            menang.SetActive (true);
        }
        
        //untuk animasi loncat
        if (tanah == true){
            anim.SetBool ("lompat", false);
        }else{
            anim.SetBool ("lompat", true);
        }
        //untuk loncat 1x ketika nyentuh tanah
        tanah = Physics2D.OverlapCircle (deteksitanah.position, jangkauan, targetlayer);

        //buat jalan ke kanan
        if(Input.GetKey (KeyCode.D) || tombolkanan == true){
            anim.SetBool ("jalan", true);//animasi jalan
            transform.Translate (Vector2.right * Kjalan * Time.deltaTime);
            pindah=1;
        //buat jalan ke kiri
        } else if (Input.GetKey (KeyCode.A) || tombolkiri == true){
            anim.SetBool ("jalan", true);//animasi jalan
            transform.Translate (Vector2.right * -Kjalan * Time.deltaTime);
            pindah=-1;
        }else {
            anim.SetBool ("jalan", false);//animasi jalan
        }

        //buat loncat
        if (tanah == true && (Input.GetKey (KeyCode.Space))){
            lompat.AddForce(new Vector2(0,Klompat));
        }
        
        //perintah buat balik badan make boolean
        if (pindah > 0 && !balik) {
            balikbadan();
        }else if (pindah < 0 && balik) {
            balikbadan();
        }
    }

    //logika buat balik badan
    void balikbadan(){
        balik = !balik;
        Vector3 manuk = transform.localScale;//buat balik badanya
        manuk.x *= -1;
        transform.localScale = manuk;
    }

    //untuk tombol
    public void tekankiri(){
        tombolkiri = true;
    }

    public void lepaskiri(){
        tombolkiri = false;
    }

    public void tekankanan(){
        tombolkanan = true;
    }

    public void lepaskanan(){
        tombolkanan = false;
    }

    public void jump(){
        if (tanah == true ){
            lompat.AddForce(new Vector2(0,Klompat));
        }
    }
}
