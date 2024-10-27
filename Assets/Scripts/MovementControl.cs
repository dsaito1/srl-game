using UnityEngine;

public class MovementControl : MonoBehaviour
{
    Rigidbody2D rb;
    float vertical, horizontal;

    [SerializeField] float moveSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCharacter();
    }

    void moveCharacter()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        rb.linearVelocity = new Vector2(horizontal * moveSpeed, vertical * moveSpeed);
    }
}
