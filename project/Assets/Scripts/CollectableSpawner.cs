using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableSpawner : MonoBehaviour
{
    [SerializeField] private GameObject milkPrefab;
    [SerializeField] private GameObject goldPrefab;
    [SerializeField] private float milkInterval = 15f;
    [SerializeField] private float goldInterval = 7f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnCollectable(milkInterval, milkPrefab));
        StartCoroutine(spawnCollectable(goldInterval, goldPrefab));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator spawnCollectable(float interval, GameObject collectable)
    {
        //TODO: optimize range of spawning
        yield return new WaitForSeconds(interval);
        GameObject newCollectable = Instantiate(
            collectable, 
            new Vector3(
                Random.Range(-8f, 26f), 
                Random.Range(-3f, 3.5f), 
                0), 
            Quaternion.identity);
        StartCoroutine(spawnCollectable(interval, collectable));
    }
}
