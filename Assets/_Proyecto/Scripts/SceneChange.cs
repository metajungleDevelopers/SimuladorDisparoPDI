using UnityEngine;

public class SceneChange : MonoBehaviour
{
    public void CambiarEscene(string nombreEscena)
    {
        // Cargar la escena especificada por su nombre
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena);
    }
}
