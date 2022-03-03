using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    private float horizontalInput;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    public float jumpForce = 10;
    public float gravityModifier;
    public bool isOnGround= true;
    public bool gameOver= false;
    public Image image;
    private int jump = 0;
    private float speed = 5;

    AnimalControl animal;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;
        animal = GameObject.FindGameObjectWithTag("Animal").GetComponent<AnimalControl>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        playerRb.AddForce(Vector3.forward * horizontalInput, ForceMode.Impulse);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) 
        {
           animal.isparent=false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = true;
            playerAnim.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);

           
        }

        if (Input.GetKey(KeyCode.RightArrow)  && !gameOver)
        {
            playerRb.AddForce(Vector3.back * jumpForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftArrow) && !gameOver)
        {
            playerRb.AddForce(Vector3.forward * jumpForce, ForceMode.Impulse);
        }

        if(gameOver)
        {
            image.gameObject.SetActive(true);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
            if(animal.isparent == false)
            {
                gameOver = true;
                Debug.Log("Game Over");
                playerAnim.SetBool("Death_b", true);
                playerAnim.SetInteger("DeathType_int", 1);
                playerAudio.PlayOneShot(crashSound, 1.0f);
                explosionParticle.Play();
                dirtParticle.Stop();
            }

        }
        else if(col.gameObject.CompareTag("obstical"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnim.SetBool("Death_b",true);
            playerAnim.SetInteger("DeathType_int", 1);
            playerAudio.PlayOneShot(crashSound, 1.0f);
            explosionParticle.Play();
            dirtParticle.Stop();
        }
       
    }
}
