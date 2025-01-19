using Unity.Mathematics;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed;
    [SerializeField] Vector2 startPoint;
    [SerializeField] float currentDistance;
    [SerializeField] float maxDistance;

    private void Start()
    {
        startPoint = transform.position;
    }
    void Update()
    {
        ProjectileMovement();
    }

    void ProjectileMovement()
    {
        transform.Translate(Vector2.up * projectileSpeed * Time.deltaTime);

        currentDistance = Vector2.Distance(startPoint, transform.position);

        if (currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }      
    }

    
}
