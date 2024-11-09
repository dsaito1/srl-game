using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform player;  // Reference to the player Transform
    public float orbitRadius = 1.0f;  // Radius of the circular path
    public float orbitSpeed = 2.0f;   // Speed of the orbit

    private float angle = 0.0f;       // Current angle in radians

    private void Update()
    {
        OrbitAroundPlayer();
    }

    void OrbitAroundPlayer()
    {
        // Increase the angle over time to make the weapon rotate around the player
        angle += orbitSpeed * Time.deltaTime;

        // Calculate the new position based on the angle
        float x = player.position.x + Mathf.Cos(angle) * orbitRadius;
        float y = player.position.y + Mathf.Sin(angle) * orbitRadius;

        // Set the weapon's position to create the orbiting effect
        transform.position = new Vector2(x, y);

        transform.rotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg);
    }
}