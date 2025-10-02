using UnityEngine;

public class SceneChange : MonoBehaviour
{

    public string nombreEscena; // Nombre de la escena a la que se desea cambiar
    private void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto que colisiona tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            // Cambiar a la escena llamada "Escena2"
            CambiarEscene();

        }

    }

    public void CambiarEscene()
    {
        // Cargar la escena especificada por su nombre
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena);
    }

}
