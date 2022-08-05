using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimer : MonoBehaviour
{
    [SerializeField] GameObject[] EnemyPools;
    float startingTime;
    [SerializeField] int i=0;
    // Start is called before the first frame update
    void Start()
    {
        Transform[] EnemyPools = this.GetComponentsInChildren<Transform>();
        StartCoroutine(SpawnPools());
    }

    // Update is called once per frame
    void Update()
    {
    }


    IEnumerator SpawnPools()
    {
        for (int j = 0; j < EnemyPools.Length; j++)
        {
            EnemyPools[i].SetActive(true);
            i++;
            yield return new WaitForSeconds(10);
        }
    }
}
