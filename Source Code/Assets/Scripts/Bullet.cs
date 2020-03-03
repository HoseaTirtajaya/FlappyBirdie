using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] Bullet bullet;

    public bool isShoot;
    public float shootTimer = 10f;

    private Rigidbody2D rb;
    private CapsuleCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<CapsuleCollider2D>();

        //rb.transform.Translate(new Vector3());
    }

    // Update is called once per frame
    void Update()
    {

        Shoot();

        if (isShoot)
        {
            shootTimer -= Time.deltaTime;

            Shoot();

            if (shootTimer <= 0f)
            {
                isShoot = false;
                shootTimer = 10f;
                Instantiate(bullet);
            }

        }

        Debug.Log(isShoot);
        Debug.Log(shootTimer);
    }

    private void Shoot()
    {
        if (Input.GetKey(KeyCode.A))
        {
            isShoot = true;

            rb.velocity = new Vector2(100f * Time.deltaTime, 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Target")
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
