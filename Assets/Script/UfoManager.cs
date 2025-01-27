using System.Collections.Generic;
using UnityEngine;

public class UfoManager : MonoBehaviour
{
    [SerializeField] public GameObject ufoPrefab;
    [SerializeField] public GameObject spawnPoint;
    [SerializeField] public Transform StartPoint;
    [SerializeField] public Transform EndPoint;
    public float spawnTime = 1f;
    public float nextSpawnTime = 3f;
    public bool isActive;
    public float randomSpawnPoint;
    [SerializeField] AudioClip spawnSound;




    private void Start()
    {
        
        StartPoint = spawnPoint.GetComponent<Transform>();
       
    }
    private void Update()
    {
        RandomSpawnPoint();
        ufoSpawner();
    }

    void SpawnUFO()
    {
        SoundManager.Instance.PlaySound(spawnSound);
        Instantiate(ufoPrefab,spawnPoint.transform.position,Quaternion.identity);
    }

    void ufoSpawner()
    {
        if (ufoPrefab.gameObject == null)
        {
            isActive = false;
            
        }
        if (!isActive && Time.time >= spawnTime)
        {
            
            SpawnUFO();
            isActive = true;
                      
        }
    }

    void RandomSpawnPoint()
    {
  
        if (randomSpawnPoint == 0)
        {
            spawnPoint.transform.position = new Vector2(11, 0);
            EndPoint.transform.position= new Vector2(3, 0);
        }
        else if (randomSpawnPoint == 1)
        {
            spawnPoint.transform.position = new Vector2(-11,0);
            EndPoint.position = new Vector2(-3,0);
        }
    }
}
