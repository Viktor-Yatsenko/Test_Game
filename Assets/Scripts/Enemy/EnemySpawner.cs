using UnityEngine;
public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    public int numberEnemies = 5;
    private float spawnTimer;
    [SerializeField] private int maxNumberEnemy;
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval & PlayerUIController.Instance.currentHealth > 0)
        {
            spawnTimer = 0;
            SpawnEnemy();
            maxNumberEnemy++;
            if(maxNumberEnemy >= numberEnemies) {gameObject.SetActive(false);}
        }
    }
    private void SpawnEnemy() {Instantiate(enemyPrefab, transform.position, transform.rotation);}
}