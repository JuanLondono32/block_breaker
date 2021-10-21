using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Paddle paddle1;
    [SerializeField] float velX = 2f;
    [SerializeField] float velY = 25f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;
    Vector2 paddleToBall;
    bool hasStarted = false;

    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    void Start()
    {
        paddleToBall = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            BallToPaddle();
            Launch();
        }
    }

    private void BallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBall;
    }

    private void Launch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            myRigidBody2D.velocity = new Vector2(velX, velY);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velTweak = new Vector2(Random.Range(0f, randomFactor), -Random.Range(0f, randomFactor));
        if (hasStarted)
        {
            AudioClip clip = ballSounds[Random.Range(0, ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velTweak;
        }
    }

}
