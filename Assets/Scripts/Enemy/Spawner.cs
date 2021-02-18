using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public GameObject SpawnerEnemy;
    public GameObject Target;
    private bool CanSpawn = false;
    private Transform TargetTransform;
    public GameObject player;

    // Permet le lancement de la coroutine à chaque frame
    void Update()
    {
        if (!CanSpawn)
        {
            StartCoroutine(GenerateEnemies());
        }
    }

    // Courtine permetant la creation d'ennemis avec comme cible le joueur
    IEnumerator GenerateEnemies()
    {
        CanSpawn = true;
        TargetTransform = Target.transform;
        EnemyPrefab.GetComponent<Unit>().target = TargetTransform;
        EnemyPrefab.GetComponent<Enemy>().player = player;
        yield return new WaitForSeconds(5);
        Instantiate(EnemyPrefab, SpawnerEnemy.transform.position, Quaternion.identity);
        CanSpawn = false;
    }
}
