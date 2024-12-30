using UnityEngine;
using UnityEngine.SceneManagement;  // Required to manage scenes

public class PlaySelectNight : MonoBehaviour
{
    public string levelName;
    public void OnButtonClick()
    {
        SceneManager.LoadScene(levelName);
    }
}
