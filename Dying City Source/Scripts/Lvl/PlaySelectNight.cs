using UnityEngine;
using UnityEngine.SceneManagement;  // Required to manage scenes

public class PlaySelectNight : MonoBehaviour
{
    public string levelName;  // The name of the scene to load when the button is clicked

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Load the scene with the name provided in the levelName variable
        SceneManager.LoadScene(levelName);
    }
}
