using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    int lives = 5;

    public int Lives
    {
        get { return lives; }
        set
        {
           if(value < 5) lives = value;
            livesBar.Refresh();
        }
    }
    private LivesBar livesBar;

    float speed = 3.0f;
    float jumpForce = 15.0f;
    public bool isMovingRight = true;
    
    bool isMoving = false;
    bool isGrounded = false;
    Rigidbody2D rb;
    public Animator animator;

    void Start()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        isMoving = false;
        
        if(!isMoving&&isGrounded)State = CharState.Idle;
    }

    public void Run()
    {
        Vector3 direction = transform.right * speed;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        if (isGrounded) State = CharState.Run;
    }

    public void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        State = CharState.Jump;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = true;
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isGrounded = false;
        if (!isGrounded) State = CharState.Jump;
    }

    CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    public enum CharState
    {
        Idle,Run,Jump
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HealthPotion")
            Destroy(collision.gameObject);
        Destroy(collision.gameObject);
    }
}


