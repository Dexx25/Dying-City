using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class Enemycheckersys : MonoBehaviour
{
    public string tagToCheck = "Enemy";  // Tag to check for (can be changed in Inspector)
    public string sceneToLoad = "Night2";   // Scene to load if no object with the tag exists
    private string sceneName;
    public bool waveHandled=true;
    public GameObject holder;

    void Start(){
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        holder = GameObject.Find("EnemyHolder");
    }
    void Update()
    {
        // Check if any object with the specified tag exists in the hierarchy
        if (GameObject.FindGameObjectWithTag(tagToCheck) == null)
        {
            // If no object is found, load the specified scene
            LoadScene();
        }
        CheckForTwoEnemies();

        
    }

    void LoadScene()
    {
        // Load the scene by name
        SceneManager.LoadScene(sceneToLoad);
    }
    void CheckForTwoEnemies()
    {
        // Find all objects with the specified tag
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(tagToCheck);

        // Check if there are exactly 2 objects
        if (enemies.Length <= 2 && waveHandled)
        {
            StartCoroutine(DeactivateObject());
            waveHandled = false;
        }
    }
    IEnumerator DeactivateObject()
{
    if (waveHandled)
    {
        switch (sceneName)
    {
        case "Night1":
        case "Night2":
            yield break;

        case "Night3":
            yield return new WaitForSeconds(2f);
            EnemyWaves.instance.SpawnNight3();
            yield return new WaitForSeconds(2f);
            EnemyWaves.instance.SpawnNight3();
            yield return new WaitForSeconds(50);
            EnemyWaves.instance.SpawnNight3();
            EnemyWaves.instance.SpawnNight3();
            EnemyWaves.instance.SpawnNight3();
            waveHandled = false;
            holder.SetActive(false);
            break;

        case "Night4":
            EnemyWaves.instance.SpawnNight4();
            yield return new WaitForSeconds(1f);
            EnemyWaves.instance.SpawnNight4();
            yield return new WaitForSeconds(1f);
            EnemyWaves.instance.SpawnBoss();
            waveHandled = false;
            yield break;

        case "Endless":
            EnemyWaves.instance.Endless();
            break;

        default:
            Debug.LogWarning($"Unhandled scene: {sceneName}");
            break;
    }
    }
    
}
}
