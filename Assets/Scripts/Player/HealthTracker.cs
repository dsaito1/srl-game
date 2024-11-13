using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthTracker : MonoBehaviour
{
    public GameObject healthbar;
    public GameObject DeadPlayer;
    public GameObject GameOver;
    public int max_health;
    public int hp;

    MonoBehaviour player_controller;
    bool taking_damage;
    Image img;
    bool is_dead = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.hp = this.max_health;
        this.img = this.healthbar.GetComponent<Image>();
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        Debug.Log("entered collision");
        if (c.gameObject.tag == "Enemy")
        {
            this.taking_damage = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {
        Debug.Log("exited collision");
        if (c.gameObject.tag == "Enemy")
        {
            this.taking_damage = false;
        }
    }

    private void TakeDamage()
    {
        if (!is_dead)
        {
            this.hp -= 1;
            this.UpdateBar(((float)this.hp) / ((float)this.max_health));
            if (hp < 0)
            {
                is_dead = true;
                Die();
            }
        }
    }
    void Die()
    {
        MovementControl move = gameObject.GetComponent<MovementControl>();
        move.is_dead = true;
        gameObject.GetComponent<SpriteRenderer>().enabled= false;
        Instantiate(DeadPlayer, gameObject.transform);
        Instantiate(GameOver);
    }

    private void UpdateBar(float percentage)
    {
        img.fillAmount = percentage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.taking_damage)
        {
            this.TakeDamage();
        }
    }
}
