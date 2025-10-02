using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    public Transform[] puntos;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        // Llama al m�todo para establecer una posici�n aleatoria al inicio
        EstablecerPosicionAleatoria();

    }

    // M�todo para establecer una posici�n aleatoria en uno de los puntos
    public void EstablecerPosicionAleatoria()
    {
        // Verifica que haya puntos disponibles
        if (puntos.Length == 0)
        {
            Debug.LogWarning("No hay puntos definidos para establecer una posici�n aleatoria.");
            return;
        }

        // Selecciona un �ndice aleatorio entre 0 y la cantidad de puntos - 1
        int indiceAleatorio = Random.Range(0, puntos.Length);

        // Establece la posici�n del objeto en el punto seleccionado
        transform.position = puntos[indiceAleatorio].position;
    }


}
