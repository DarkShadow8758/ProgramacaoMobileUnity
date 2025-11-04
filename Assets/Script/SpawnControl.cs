using System.Collections;
using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [Header("Prefabs para sortear")]
    public GameObject[] prefabs;
    [Header("Pontos de spawn (fora da tela)")]
    public Transform[] spawnPoints;
    [Header("Loops - Tempo entre o spawn")]
    public float spawnTime = 1.5f;
    [Header("Destino para onde vão os objetos")]
    public Vector2 destiny = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(LoopSpawn());
    }

    private IEnumerator LoopSpawn()
    {
        while (true)
        {
            Spawn();
            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void Spawn()
    {
        if (prefabs.Length == 0 || spawnPoints.Length == 0) return;
        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        var spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        var go = Instantiate(prefab, spawnPoint.position, Quaternion.identity);

        var move = go.GetComponent<SimpleMove2D>();
        if (move != null)
        {
            move = go.AddComponent<SimpleMove2D>();
            move.destiny = destiny;
        }
        

    }
}
