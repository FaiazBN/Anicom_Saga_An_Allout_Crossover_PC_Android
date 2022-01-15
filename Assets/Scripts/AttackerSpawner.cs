using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField] bool spawn = true;
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Attackers[] attacker;
    
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnAttackers();
        }       
    }
    public void StopSpawning()
    {
        spawn = false;
    }

    private void SpawnAttackers()
    {
        var newAttackerIndex = Random.Range(0, attacker.Length);

        Spawn(attacker[newAttackerIndex]);
    }
    private void Spawn(Attackers attacker)
    {
        Attackers currentAttacker = Instantiate(attacker, transform.position, transform.rotation) as Attackers;

        currentAttacker.transform.parent = transform;
    }
}
