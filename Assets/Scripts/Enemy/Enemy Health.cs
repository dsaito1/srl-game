using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    int health;
    public int maxHealth;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = maxHealth;   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerBullet")
        {
            BulletStats bullet = collision.gameObject.GetComponent<BulletStats>();
            health -= bullet.damage;
            bullet.health -= 1;
            if (bullet.health < 1)
            {
                collision.gameObject.SetActive(false);
            }
            if (health < 1)
            {
                gameObject.SetActive(false);
            }

        }
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
