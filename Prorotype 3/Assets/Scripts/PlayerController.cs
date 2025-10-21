using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource audioSource;
    public ParticleSystem explotionParticles;
    public ParticleSystem dirtParticles;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public float jumpForce = 10;
    public float gravityMultiplier = 2.0f;
    public bool IsOnGround = true;
    public bool IsGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        Physics.gravity *= gravityMultiplier;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && IsOnGround && !IsGameOver){
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnimator.SetTrigger("Jump_trig");
            IsOnGround = false;
            dirtParticles.Stop();
            audioSource.PlayOneShot(jumpSound, 1.0f);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticles.Play();
            IsOnGround = true;
        }else if (collision.gameObject.CompareTag("Obstacle"))
        {
            IsGameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            explotionParticles.Play();
            dirtParticles.Stop();
            Debug.Log("Game Over!");
            audioSource.PlayOneShot(crashSound, 1.0f);
            

        }
       IsOnGround = true;
    }
}
