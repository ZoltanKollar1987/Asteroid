using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AsteroidManager : MonoBehaviour
{
    [SerializeField] GameObject bigAsteroid;
    [SerializeField] GameObject mediumAsteroid;
    [SerializeField] GameObject smallAsteroid;
    [SerializeField] int spawnAmount;
    [SerializeField] int initialspawn;
    [SerializeField] GameObject[] initialAsteroidSpawnerPos;
    [SerializeField] public List<GameObject> asteroidsList;
    [SerializeField] AudioClip explodingAsteroidSound;
    

    


    private void Start()
    {
        asteroidsList = new List<GameObject>();       
        SpawnStartingAsteroids(spawnAmount = 4);        
    }


    
    public void CrackAsteroids(int type, Vector2 position, GameObject asteroid)
    {
        SoundManager.Instance.PlaySound(explodingAsteroidSound);

        if (type == 1)
        {
            asteroid = mediumAsteroid;        
        }
        if (type == 2)
        {
            asteroid = smallAsteroid;
        }
        if (type == 3)
        {
            return;
        }

        for (int i = 0; i < spawnAmount / 2; i++)
        {
            asteroidsList.Add(Instantiate(asteroid, position, Quaternion.identity));            
        }
        

    }
    
    void SpawnStartingAsteroids(int spawnAmount)
    {
        

        for (int i = 0; i < spawnAmount; i++)
        {
            asteroidsList.Add(Instantiate(bigAsteroid, initialAsteroidSpawnerPos[i].transform.position, Quaternion.identity));                  
        }
        

    }

    

}
