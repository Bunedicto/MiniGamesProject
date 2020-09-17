using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    private float speed = 20.0f;
    private float xRange = 20;
    public GameObject projectilePrefab;

    private Rigidbody playerRb;
    private Animator playerAnim;

    //this
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    //this
    public AudioClip jumpSound;
    public AudioClip crashSound;

    public float jumpForce = 20.0f;
    public float gravityModifier = 3.0f;

    public bool isOnGround = true;
    public bool isGameOver = false;

    private Rigidbody playerRb2;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public float speed2 = 5.0f;
    public bool hasPowerup = false;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound);
        }

        playerRb2 = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }


    // Update is called once per frame
    void Update()
    {
        // Check for left and right bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        // Player movement left to right
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);


        if (Input.GetKeyDown(KeyCode.Space))
        {
            // No longer necessary to Instantiate prefabs
            // Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Get an object object from the pool
            GameObject pooledProjectile = ObjectPooler.SharedInstance.GetPooledObject();
            if (pooledProjectile != null)
            {
                pooledProjectile.SetActive(true); // activate it
                pooledProjectile.transform.position = transform.position; // position it at player
            }
        }

        float forwardInput = Input.GetAxis("Vertical");

        playerRb2.AddForce(focalPoint.transform.forward * forwardInput * speed2);

        powerupIndicator.transform.position = transform.position;

        if (playerRb2.transform.position.y < -10)
        {
            playerRb2.transform.position = new Vector3(0, 0, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            dirtParticle.Play();
            isOnGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            dirtParticle.Stop();
            playerAudio.PlayOneShot(crashSound);
            explosionParticle.Play();
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
            Debug.Log("Game Over");
            isGameOver = true;
        }

        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRigidbody.AddForce(awayFromPlayer * 10, ForceMode.Impulse);
            Debug.Log("Collided with: " + collision.gameObject.name + " with powerup set to " + hasPowerup);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(10);
        powerupIndicator.gameObject.SetActive(false);
        hasPowerup = false;
    }
}
