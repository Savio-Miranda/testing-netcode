using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private MovementManager movement;
    [SerializeField] private StatsManager stats;
    
    void Awake()
    {
        movement = new MovementManager(gameObject);
        stats = new StatsManager(gameObject);
    }

    void FixedUpdate()
    {
        //movement.Movement();
        movement.Rotation();
    }
}
