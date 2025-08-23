using UnityEngine;

public class ItemMagnet : MonoBehaviour
{
    public float magnetRange = 5f;
    public float moveSpeed = 10f;

    private Transform player;
   
    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player").transform;
    }


    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance < magnetRange)
        {
            // Closer distance = higher speed
            float speedFactor = 1 - (distance / magnetRange);
            float currentSpeed = moveSpeed * speedFactor;

            // Move toward the player
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                currentSpeed * Time.deltaTime
            );
        }
    }
}
