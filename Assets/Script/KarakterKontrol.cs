using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Karakterkontrol : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float hiz;
    private float hareket;


    private bool zemin;
    public Transform zeminKontrol;
    public float yaricapKontrol;
    public LayerMask zeminNe;
    public int ekstraZiplama;
    public float ziplamakuvveti;
    public int ekstraZiplamaSayisi;
    private bool ziplama;


    public GameObject ates;
    public Transform atesnoktasi;
    public float atishizi;
    public float sayac;

    Animator animator;

 
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }
    private void Update()
    {
        sayac -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (sayac <= 0)
            {
                shoot();
                animator.SetTrigger("Ateþ");
                sayac = 1f;

            }
        }




        ziplama = Input.GetKeyDown(KeyCode.W);
        if (zemin == true)
        {
            ekstraZiplama = ekstraZiplamaSayisi;
        }
        if (ziplama && ekstraZiplama > 0)
{
            rb.velocity = Vector2.up * ziplamakuvveti;
            ekstraZiplama--;
            animator.SetBool("zýplýyormu", zemin);

        } else if (Input.GetKeyDown(KeyCode.W) && ekstraZiplama == 0 && zemin == true)
        {
            rb.velocity = Vector2.up * ziplamakuvveti;
           

        }
       


    }

    private void FixedUpdate()
    {
        zemin = Physics2D.OverlapCircle(zeminKontrol.position, yaricapKontrol, zeminNe);
        hareket = Input.GetAxis("Horizontal");
        animator.SetFloat("speed",Mathf.Abs(hareket));
        rb.velocity = new Vector2(hareket * hiz, rb.velocity.y);
        if (hareket < 0)
        {
            sr.flipX = true;
        }
        else if (hareket > 0)
        {
            sr.flipX = false;
        }
    }
    private void shoot()
    {
        
            GameObject mermi = Instantiate(ates, atesnoktasi.position, Quaternion.identity);
            mermi.GetComponent<Rigidbody2D>().velocity = new Vector2(atishizi * Time.deltaTime, 0);
            Destroy(mermi, 2f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bitis")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}

