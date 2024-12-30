using UnityEngine;
using UnityEngine.UI;

public class QualityAdjust : MonoBehaviour
{
    public Dropdown qualityDropdown; // Reference to the Dropdown UI component

    void Start()
    {
        // Populate the dropdown with available quality levels
        qualityDropdown.ClearOptions();
        string[] qualityLevels = QualitySettings.names;
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(qualityLevels));

        // Set the current dropdown value to the active quality level
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();

        // Add listener for changes in the dropdown
        qualityDropdown.onValueChanged.AddListener(SetQualityLevel);
    }

    // Set the quality level based on the dropdown selection
    public void SetQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true); // Apply changes immediately
        Debug.Log("Quality level set to: " + QualitySettings.names[qualityIndex]);
    }
}
