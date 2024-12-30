using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyWaves : MonoBehaviour
{
    public static EnemyWaves instance;
    [SerializeField]
    private GameObject EnemyPrefab;
    [SerializeField]
    private GameObject BossPrefab;
    private string sceneName;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;

        if (sceneName == "Night1" || sceneName == "Night2")
        {
            Spawn();
        }
        else if (sceneName == "Night3")
        {
            Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
            Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, -2f), Quaternion.identity);
            Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, -1.3f), Quaternion.identity);
            SpawnNight3();
        }
        else if (sceneName == "Night4")
        {
            Spawn();
            SpawnNight4();
        }
        else if (sceneName == "Endless")
        {
            Endless();
        }
    }

    public void Spawn()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(1.5f, 0f, 1.5f), Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, -1f), Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(-1f, 0f, -1.5f), Quaternion.identity);
    }

    public void SpawnNight3()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, -1f), Quaternion.identity);
    }

    public void SpawnNight4()
    {
        Instantiate(EnemyPrefab, transform.position + new Vector3(0f, 0f, 1f), Quaternion.identity);
        Instantiate(EnemyPrefab, transform.position + new Vector3(1.5f, 0f, 1.5f), Quaternion.identity);
    }

    public void Endless()
    {
        Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
    }

    public void SpawnBoss()
    {
        Instantiate(BossPrefab, transform.position, Quaternion.identity);
    }
}
