using UnityEngine;

public class MovementControl : MonoBehaviour
{
    Rigidbody2D rb;
    float vertical, horizontal;
    private Animator animator;

    [SerializeField] float moveSpeed;
    private Transform weaponParent;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = this.GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is not called once per frame but at a constant rate based on time elapsed
    void FixedUpdate()
    {
        moveCharacter();
    }

    void moveCharacter()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 characterScale = transform.localScale;
        if (horizontal < 0)
        {
            characterScale.x = -1;
        }
        if(horizontal > 0)
        {
            characterScale.x = 1;
        }

        transform.localScale = characterScale;

        if (weaponParent != null)
        {
            Vector3 weaponParentScale = weaponParent.localScale;
            weaponParentScale.x = 1;
            weaponParent.localScale = weaponParentScale;
        }

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
