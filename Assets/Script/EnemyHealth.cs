using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int currentHitPoints;
    [SerializeField] int MaxHitPoints = 5;

    Enemy enemy;
    void Start()
    {
        currentHitPoints = MaxHitPoints;
        enemy = GetComponent<Enemy>();
    }


    void Update()
    {
        if (currentHitPoints <= 0)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
    }
    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }
    void ProcessHit()
    {
        currentHitPoints--;
        if (currentHitPoints <= 0)
        {
            Destroy(gameObject);
            enemy.RewardGold();
        }
    }
}
