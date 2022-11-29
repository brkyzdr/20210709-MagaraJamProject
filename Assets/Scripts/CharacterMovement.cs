using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CharacterMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    Vector3 vector3;
    Animator Anim;
    public AudioSource audio;
    public AudioClip[] sound;
    public Text CoObText;

    public float speed = 5f;
    public float jumpForce = 8f;
    float horizontalMove = 0f;
    public bool isDead;
    public float alinanCoOb;
    public bool level2 = false;
    public bool level3 = false;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        alinanCoOb = 0;
        transform.position = new Vector2(-182, -5);
        
    }

    void Update()
    {
        #region Yurume
        vector3 = new Vector2(Input.GetAxis("Horizontal"), 0f);
        transform.position += vector3 * speed * Time.deltaTime;

        horizontalMove = Input.GetAxisRaw("Horizontal");
        Anim.SetFloat("Run", Mathf.Abs(horizontalMove));


        if (horizontalMove != 0 && Mathf.Approximately(rb2d.velocity.y, 0) && !audio.isPlaying)
        {
            audio.clip = sound[0];
            audio.Play();
        }
        if (audio.clip == sound[0] && (horizontalMove == 0 || Input.GetButtonDown("Jump")))
        {
            audio.Stop();
        }

        #endregion

        #region Ziplama
        if (Mathf.Approximately(rb2d.velocity.y, 0) && Input.GetButtonDown("Jump"))
        {
            rb2d.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            Anim.SetBool("IsJumping", true);

            audio.clip = sound[1];
            audio.Play();
        }
        if (Mathf.Approximately(rb2d.velocity.y, 0))
        {
            Anim.SetBool("IsJumping", false);
            if (audio.clip == sound[1] && audio.isPlaying)
                audio.Stop();
        }
        #endregion

        #region Saga Sola Donme
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        else if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        #endregion

        CoObText.text = $"{alinanCoOb}/3";

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("CoOb"))
        {
            audio.clip = sound[2];
            audio.Play();
            alinanCoOb++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Portal1") && alinanCoOb == 3)
        {
            transform.position = new Vector2(-10, -4);
            alinanCoOb = 0;
        }
        if (collision.gameObject.tag.Equals("Portal2") && alinanCoOb == 3)
        {
            transform.position = new Vector2(107, -6);
            alinanCoOb = 0;
        }
        if (collision.gameObject.tag.Equals("Portal3") && alinanCoOb == 3)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if (collision.gameObject.tag.Equals("DeathArea"))
        {
            SceneManager.LoadScene("DeathScene");
        }
    }
}
