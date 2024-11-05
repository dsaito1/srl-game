using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    GameObject target;
    Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.target = GameObject.FindGameObjectWithTag("Player");
        this.offset = target.GetComponent<CapsuleCollider2D>().offset;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 dir = ((target.transform.position + this.offset) - gameObject.transform.position).normalized;
        gameObject.transform.position += dir * speed;
    }
}
