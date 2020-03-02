using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]

public class GroundSpawner : MonoBehaviour
{
    //Menampung referensi ground yang ingin di buat
    [SerializeField]
    private Ground groundRef;

    //Menampung ground sebelumnya
    private Ground prevGround;

    private void SpawnGround()
    {
        //Pengecekan Null Variable
        if (prevGround != null)
        {
            //menduplikasi Groundref
            Ground newGround = Instantiate(groundRef);

            //mengaktifkan game object
            newGround.gameObject.SetActive(true);

            //menempatkan new ground dengan posisi nextground dari prevground agar posisinya sejajar denga ground sebelumnya
            prevGround.SetNextGround(newGround.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Mencari koponent ground dari object yang keluar dari area trigger
        Ground ground = collision.GetComponent<Ground>();

        //Pengecekan null variable
        if (ground)
        {
            //Mengisi variable prevGround 
            prevGround = ground;

            //Membuat Ground baru
            SpawnGround();
        }
    }
}
