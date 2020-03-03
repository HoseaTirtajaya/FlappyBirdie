using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Bird : MonoBehaviour
{
    [SerializeField] private float upForce = 100;
    [SerializeField] private bool isDead;
    [SerializeField] private UnityEvent OnJump, OnDead;
    [SerializeField] private UnityEvent OnAddPoint;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text currentScore;
    [SerializeField] private Text High;

    public int score;
    public int highScore;

    private Rigidbody2D rbody;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        PlayerPrefs.SetInt("highScore", highScore);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead && Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("hehehe");
            BirdJump();
        }
    }

    public bool IsDead()
    {
        return isDead;
    }

    public void Dead()
    {
        if (!isDead && OnDead != null)
        {
            OnDead.Invoke();
        }

        isDead = true;

    }
    void BirdJump()
    {
        //Mengecek rigidbody null atau tidak
        if (rbody)
        {
            //menghentikan kecepatan burung ketika jatuh
            rbody.velocity = Vector2.zero;

            //Menambahkan gaya ke arah sumbu y agar burung meloncat
            rbody.AddForce(new Vector2(5f, upForce));
        }

        //Pengecekan Null variable
        if (OnJump != null)
        {
            //Menjalankan semua event OnJump event
            OnJump.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //menghentikan Animasi Burung ketika bersentukan dengan object lain
        animator.enabled = false;
    }

    public void AddScore(int value)
    {
        //Menambahkan Score value
        score += value;
        //Debug.Log(score);

        //Mengubah nilai text pada score text
        scoreText.text = score.ToString();
        if(highScore <= score)
        {
            highScore = score;
            PlayerPrefs.GetInt("highScore", highScore);
            PlayerPrefs.Save();
            //Debug.Log(highScore);
            currentScore.text = "Score: " + score.ToString();
            High.text = "Highscore: " + highScore.ToString();
        }

        //Pengecekan Null Value
        if (OnAddPoint != null)
        {
            //Memanggil semua event pada OnAddPoint
            OnAddPoint.Invoke();
        }
    }

    public void ShootPipe()
    {

    }

}