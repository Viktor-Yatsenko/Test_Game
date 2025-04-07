using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    private float spawnTimer;
    [SerializeField] private int maxNumberEnemy;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval & SliderController.Instance.currentHealth > 0)
        {
            spawnTimer = 0;
            SpawnEnemy();
            maxNumberEnemy++;
            if(maxNumberEnemy >= 2) {gameObject.SetActive(false);}
        }
    }
    private void SpawnEnemy() {Instantiate(enemyPrefab, transform.position, transform.rotation);}
}