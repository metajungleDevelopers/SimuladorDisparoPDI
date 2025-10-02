using UnityEngine;
using TMPro;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteAlways]
public class AutoUpdateVersion : MonoBehaviour
{
    public TextMeshProUGUI versionText;

    private void UpdateVersion()
    {
        if (versionText != null)
        {
#if UNITY_EDITOR
            versionText.text = "v " + PlayerSettings.bundleVersion;
#else
            versionText.text = "v " + Application.version; // Alternativa para builds
#endif
        }
    }

    private void OnValidate()
    {
        UpdateVersion();
    }

    private void Awake()
    {
        UpdateVersion();
    }
}
