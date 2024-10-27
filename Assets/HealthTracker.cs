using UnityEngine;

public class HealthTracker : MonoBehaviour
{
    public GameObject healthbar;
    public int max_health;
    public int hp;
    bool taking_damage;
    Vector3 scaler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.taking_damage = false;
        this.scaler = this.healthbar.transform.localScale;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            this.hp = this.max_health;
            this.taking_damage = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy") 
        {
            this.taking_damage = false;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.taking_damage)
        {
            this.hp -= 1;
        }
        if (this.max_health != 0)
        {
            this.healthbar.transform.localScale = new Vector3(this.scaler.x * ((float)this.hp) / ((float)this.max_health), this.scaler.y, 1);
        }
    }
}
