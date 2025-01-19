using Unity.Mathematics;
using UnityEngine;

public class SpaceShip : MonoBehaviour
{
   
   Rigidbody2D rb;
   [SerializeField] private float thrusterForce = 1f;
   [SerializeField] private float rotationSpeed = 100f;
   [SerializeField] private int rotationSide;
   [SerializeField] private GameObject projectile;
   [SerializeField] private GameObject projectileSpawner;
   


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
   
    void FixedUpdate()
    {
        Movement();   
    }
    private void Update()
    {
        Shoot();
    }

    void Movement()
    {
        if (rb != null)
        {
            if (Input.GetKey(KeyCode.W))
            {
                Thruster(thrusterForce);
            }
            if (Input.GetKey(KeyCode.A))
            {
                RotateShip(rotationSide = 1, rotationSpeed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                RotateShip(rotationSide = 2, rotationSpeed);
            }
            
        }
    }

    void Thruster(float thrusterForce)
    {        
            rb.AddForce(rb.transform.TransformDirection(Vector2.up) * thrusterForce);
    }
    void RotateShip(int rotationSide, float rotationSpeed)
    {
        
        if (rb != null && rotationSide == 1 )
        {
            rb.MoveRotation(rb.rotation + rotationSpeed * Time.fixedDeltaTime);
        }
        else if (rb != null && rotationSide == 2)
        {
            rb.MoveRotation(rb.rotation - rotationSpeed * Time.fixedDeltaTime);
        }
        
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            Instantiate(projectile,projectileSpawner.transform.position, this.transform.rotation);

        }
        
    }
}
