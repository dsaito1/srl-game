using UnityEngine;

public class MovementControl : MonoBehaviour
{
    Rigidbody2D rb;
    float vertical, horizontal;
    private Animator animator;
    public bool is_dead = false;

    [SerializeField] float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is not called once per frame but at a constant rate based on time elapsed
    void FixedUpdate()
    {
        if (!is_dead)
        {
            moveCharacter();
        }
    }

    void moveCharacter()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 characterScale = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1;
        }
        if(Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1;
        }
        transform.localScale = characterScale;
        if ((horizontal > 0) || (vertical > 0) || (horizontal < 0) || (vertical < 0))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
