
using UnityEngine;

public class Ufo : MonoBehaviour
{
    [SerializeField] UfoManager ufoManager;
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject UfoProjectile;
    public bool isActive;
    public float spawnTime = 1f;
    [SerializeField] float speed = 0.1f;
    float t = 0.0f;
    float shootInterval = 1.0f;
    float timer;
    [SerializeField] AudioClip shootingSound;



    private void Awake()
    {
        ufoManager = FindAnyObjectByType<UfoManager>();
        gameManager = FindAnyObjectByType<GameManager>();
       
    }

    private void Update()
    {
        Movement();
        timer += Time.deltaTime;

        
        if (timer >= shootInterval)
        {
            Shoot();
            timer = 0f; 
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Projectile")
        {
            UfoSpawnerReset();
            Destroy(this.gameObject);
        }
        if (collision.collider.tag == "Player")
        {
            gameManager.LosePlayerLife();
        }

    }

    void UfoSpawnerReset()
    {
        ufoManager.isActive = false;
        ufoManager.spawnTime = Time.time + ufoManager.nextSpawnTime;
        ufoManager.randomSpawnPoint = Random.Range(0, 2);
    }

    void Movement()
    {
        

        if (t < 1f)
        {
            t += Time.deltaTime * speed;
            transform.position = Vector2.Lerp(ufoManager.StartPoint.position, ufoManager.EndPoint.position, t);
            
        }

    }

    void Shoot()
    {
        if(this.transform.position == ufoManager.EndPoint.transform.position)
        {
            SoundManager.Instance.PlaySound(shootingSound);
            Instantiate(UfoProjectile,this.transform.position, Quaternion.identity);
        }
    }
}
