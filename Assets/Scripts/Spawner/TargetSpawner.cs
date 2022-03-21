using System.Collections.Generic;
using UnityEngine;

public class TargetSpawner : MonoBehaviour
{
    [SerializeField] private AppleSpawner _appleSpawner;
    [SerializeField] private Apple _appleTemplate;
    [SerializeField] private Knife _knifeTemplate;

    public Target _currentTarget { get; private set; }

    public void Spawn(Target targetTemplate)
    {
        _currentTarget = Instantiate(targetTemplate, transform.position, Quaternion.identity, transform);
        SpawnApple();
        SpawnKnifes();
    }

    private void SpawnApple()
    {
        bool isCanBeSpawned = _appleSpawner.TrySpawn();

        if (isCanBeSpawned == true)
        {
            SelectSpawnPositions(1, _currentTarget.AppleSpawnPoints, _appleTemplate);
        }
    }

    private void SpawnKnifes()
    {
        int count = Random.Range(1, 4);

        if (count > _currentTarget.KnifeSpawnPoints.Length)
        {
            count = _currentTarget.KnifeSpawnPoints.Length;
        }

        SelectSpawnPositions(count, _currentTarget.KnifeSpawnPoints, _knifeTemplate);
    }

    private void SelectSpawnPositions(int count, SpawnPoint[] spawnPoints, Object template)
    {
        List<int> filledPoints = new List<int>();

        while (count > 0)
        {
            int index = Random.Range(0, spawnPoints.Length);

            if (filledPoints.Contains(index) == false)
            {
                SpawnPoint spawnPoint = spawnPoints[index];
                Instantiate(template, spawnPoint.transform.position, spawnPoint.transform.rotation, spawnPoint.transform);

                filledPoints.Add(index);
                count--;
            }
        }
    }
}
