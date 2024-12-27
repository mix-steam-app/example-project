using UnityEngine;

public class Spawner : MonoBehaviour
{
	public GameObject SpawnPrefab;
	public float SpawnInterval;
	public float SpawnHeight;
	private float _timeSinceLastSpawn;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("Spawner instance started");
    }

    // Update is called once per frame
    void Update()
    {
		_timeSinceLastSpawn += Time.deltaTime;
		if (_timeSinceLastSpawn >= SpawnInterval)
		{
			_timeSinceLastSpawn = 0.0f;
			var spawnPosition = transform.position + Vector3.up * SpawnHeight;
			Instantiate(SpawnPrefab, spawnPosition, Quaternion.identity);
		}
    }
}
