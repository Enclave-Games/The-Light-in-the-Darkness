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

    [SerializeField]
    float speed = 3.0f;
    [SerializeField]
    float jumpForce = 15.0f;
    public Text CoinScore;
    int coin;
    [HideInInspector]
    public bool isMovingRight = true;
    
    bool isMoving = false;
    bool isGrounded = false;
    VirtualJoystick joystick;
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sp_render;

    void Start()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sp_render = GetComponentInChildren<SpriteRenderer>();
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<VirtualJoystick>();
    }

    void Update()
    {
        isMoving = false;
        if (joystick.Horizontal() != 0)
        {
            Run(joystick.Horizontal());
            isMoving = true;
        }
        if (joystick.Vertical() > 0.75f && isGrounded)
        {
            Jump();
            isMoving = true;
        }
        if(!isMoving&&isGrounded)State = CharState.Idle;
    }

    void Run(float inputx)
    {
        Vector3 direction = transform.right * inputx;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        sp_render.flipX = direction.x < 0.0f;
        isMovingRight = !sp_render.flipX;
        if (isGrounded) State = CharState.Run;
    }

    void Jump()
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
        if (collision.gameObject.tag == "Coin")
            CoinScore.text += 1;
        Destroy(collision.gameObject);
    }
}


