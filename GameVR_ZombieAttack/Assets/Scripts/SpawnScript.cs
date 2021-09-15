using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{

    public float interval;
    public GameObject zombiePrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawn(interval));
    }

    IEnumerator EnemySpawn(float t)
    {
        Instantiate(zombiePrefab, transform.position, transform.rotation);
        yield return new WaitForSeconds(t);
        StartCoroutine(EnemySpawn(t));

    }

}
