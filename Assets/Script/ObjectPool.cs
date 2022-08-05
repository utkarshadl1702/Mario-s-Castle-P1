using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] GameObject[] Enemy;
    [SerializeField][Range(0.1f, 30f)] float spawnTimer = 17f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            int num = Random.Range(0, Enemy.Length);
            Instantiate(Enemy[num], transform);
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
