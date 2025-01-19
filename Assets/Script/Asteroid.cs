using UnityEngine;

public class Asteroid : MonoBehaviour
{
    
    [SerializeField] float addforce;
    [SerializeField] float speed;
    [SerializeField] float randomDirX;
    [SerializeField] float randomDirY;
    [SerializeField] public float xBoundariMin, xBoundariMax;
    [SerializeField] public float yBoundariMin, yBoundariMax;
    [SerializeField] int asteroidtype;

    [SerializeField] AsteroidManager asteroidManager;
    [SerializeField] GameManager gameManager;
    

    [SerializeField] Rigidbody2D asteroidRb;  
    [SerializeField] Vector2 asteroidPos;
    [SerializeField] Vector2 direction;
    


    

    void Awake()
    {
        

        asteroidRb = this.GetComponent<Rigidbody2D>();
        asteroidManager = FindAnyObjectByType<AsteroidManager>();
        gameManager = FindAnyObjectByType<GameManager>(); 
        

    }
    private void Start()
    {
        RandomiseDirection();
        asteroidRb.AddForce(new Vector2(randomDirX, randomDirY) * addforce);
    }

    void Update()
    {
        direction = this.gameObject.transform.position;         
    }
    private void FixedUpdate()
    {
        Repositioning();
    }

    private void Repositioning()
    {

        if (direction.x >= xBoundariMax || direction.y >= yBoundariMax)
        {
            transform.position = -direction;
            asteroidRb.MovePosition(speed * Time.fixedDeltaTime * asteroidManager.transform.position);
        }
        if (direction.x <=xBoundariMin || direction.y <= yBoundariMin)
        {
            transform.position = -direction;
            asteroidRb.MovePosition(speed * Time.fixedDeltaTime * asteroidManager.transform.position);

        }
    }

    void RandomiseDirection()
    {
        randomDirX = Random.Range(-2, 2);
        randomDirY = Random.Range(-2, 2);

        if (randomDirX == 0 || randomDirY == 0)
        {
            randomDirX += 1;
            randomDirY += 1;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Projectile"))
        {
            asteroidPos = this.transform.position;
            Destroy(collision.gameObject);
            asteroidManager.CrackAsteroids(this.asteroidtype, this.asteroidPos, this.gameObject);
            asteroidManager.asteroidsList.Remove(this.gameObject);
            Destroy(this.gameObject);
            gameManager.GainScore();
           
        }

        if (collision.collider.CompareTag("Player"))
        {
            gameManager.LosePlayerLife();
        }
    }


}
