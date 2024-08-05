using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float baseDamage;
    [SerializeField] private float baseSpeed;
    public GameObject player;

    private float damage;
    private float speed;
    private float distance;

    // Difficulty parameter (Easy = 0, Medium = 1, Hard = 2)
    public int difficultyLevel;

    // Expose damage and speed for inspection in Unity Inspector
    [SerializeField] private float easyDamageMultiplier = 0.5f;
    [SerializeField] private float easySpeedMultiplier = 0.75f;
    [SerializeField] private float hardDamageMultiplier = 2f;
    [SerializeField] private float hardSpeedMultiplier = 2f;

    // Start is called before the first frame update
    void Start()
    {
        SetDifficulty(difficultyLevel);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;

        if(distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }

    public void SetDifficulty(int level)
    {
        switch(level)
        {
            case 0: // Easy
                damage = baseDamage * easyDamageMultiplier;
                speed = baseSpeed * easySpeedMultiplier;
                break;
            case 1: // Medium
                damage = baseDamage;
                speed = baseSpeed;
                break;
            case 2: // Hard
                damage = baseDamage * hardDamageMultiplier;
                speed = baseSpeed * hardSpeedMultiplier;
                break;
            default:
                damage = baseDamage;
                speed = baseSpeed;
                break;
        }
    }
}
