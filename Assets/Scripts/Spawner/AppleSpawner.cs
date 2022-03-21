using UnityEngine;

[CreateAssetMenu(fileName = "Apple", menuName = "AppleSpawner")]
public class AppleSpawner : ScriptableObject
{
    [SerializeField] private float _spawnChance = 25;

    public bool TrySpawn()
    {
        if (Random.Range(0, 100) <= _spawnChance)
        {
            return true;
        }

        return false;
    }
}
