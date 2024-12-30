using UnityEngine;
using UnityEngine.UI;

public class QualityAdjust : MonoBehaviour
{
    public Dropdown qualityDropdown;

    void Start()
    {
        qualityDropdown.ClearOptions();
        string[] qualityLevels = QualitySettings.names;
        qualityDropdown.AddOptions(new System.Collections.Generic.List<string>(qualityLevels));
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
        qualityDropdown.onValueChanged.AddListener(SetQualityLevel);
    }
    public void SetQualityLevel(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex, true);
        Debug.Log("Quality level set to: " + QualitySettings.names[qualityIndex]);
    }
}
