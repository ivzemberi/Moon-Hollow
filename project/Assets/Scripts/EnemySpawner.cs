using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ghostPrefab;
    [SerializeField] private float ghostInterval = 15f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy(ghostInterval, ghostPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(
            enemy, 
            new Vector3(
                Random.Range(-8f, 7.8f), 
                Random.Range(-3f, 3f), 
                0), 
            Quaternion.identity);
        //TODO: add max amount of enemies
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}

