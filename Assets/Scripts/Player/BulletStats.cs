using UnityEngine;

public class BulletStats : MonoBehaviour
{
    public int damage;
    public int health;
    public float speed;
    public int lifespan;

    int adjusted_lifespan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        adjusted_lifespan = lifespan * 50;
    }

    private void OnDisable()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        adjusted_lifespan--;
        if (adjusted_lifespan < 0 ) 
        {
            gameObject.SetActive( false );
        }
    }
}
