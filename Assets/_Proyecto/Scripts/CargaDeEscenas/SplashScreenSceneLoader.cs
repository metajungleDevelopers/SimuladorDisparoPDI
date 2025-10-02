using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SplashScreenSceneLoader : MonoBehaviour
{
    [Tooltip("Nombre de la escena a cargar cuando termine el video")]
    [SerializeField] private string sceneToLoad;

    [Tooltip("Referencia al VideoPlayer (opcional, se buscará automáticamente si no se asigna)")]
    [SerializeField] private VideoPlayer videoPlayer;

    private bool isVideoFinished = false;

    private void Awake()
    {
        // Si no se asignó un VideoPlayer, intentamos encontrarlo en este GameObject
        if (videoPlayer == null)
        {
            videoPlayer = GetComponent<VideoPlayer>();

            // Si aún no lo encontramos, buscamos en los hijos
            if (videoPlayer == null)
            {
                videoPlayer = GetComponentInChildren<VideoPlayer>();

                if (videoPlayer == null)
                {
                    Debug.LogError("No se encontró ningún VideoPlayer. Por favor asigne uno en el inspector o añádalo a este GameObject.");
                    return;
                }
            }
        }

        // Verificamos que se haya especificado una escena
        if (string.IsNullOrEmpty(sceneToLoad))
        {
            Debug.LogError("No se ha especificado una escena para cargar. Por favor asigne una en el inspector.");
            return;
        }

        // Nos suscribimos al evento de finalización del video
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    private void OnVideoFinished(VideoPlayer vp)
    {
        if (!isVideoFinished)
        {
            isVideoFinished = true;
            Invoke(nameof(LoadSpecifiedScene), 1);
        }
    }

    private void LoadSpecifiedScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnDestroy()
    {
        // Nos desuscribimos del evento para evitar memory leaks
        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached -= OnVideoFinished;
        }
    }
}