using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const string JumpString = "Jump";
    private const string GroundString = "Ground";
    private const string ObstacleString = "Obstacle";
    private const string SantaDeathString = "SantaDeath";

    Rigidbody2D rb;
    Animator anim, anim2, anim3, anim4, anim5;
    [SerializeField] float jumpForce;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && !gameOver && !gameOver && !gameOver)
        {
            if (grounded == true)
            {
                jump();
            }
        }
    }

    bool grounded;
    bool gameOver = false;

    void jump()
    {
        grounded = false;

        rb.velocity = Vector2.up * jumpForce;

        anim.SetTrigger(JumpString);

        GameManager.instance.IncrementScore();
    }

    private bool SetGameOverTrue()
    {
        return true;
    }

    private void OnCollisionEnter2D(Collision2D collision)   
    {
        if(collision.gameObject.tag == GroundString)
        {
            grounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ObstacleString)
        {
            GameManager.instance.GameOver();
            Destroy(collision.gameObject);
            anim.Play(SantaDeathString);
            gameOver = SetGameOverTrue();
        }
    }
}
