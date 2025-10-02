using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshPro TextoTime;
    public Animator animCortina;
    public BackwardsWalker BackwardsWalker;

    public void Comenzar()
    {
        StartCoroutine(Contador());
    }

    private System.Collections.IEnumerator Contador()
    {
        float tiempo = 5.0f;
        while (tiempo >= 0)
        {
            TextoTime.text = tiempo.ToString("F1"); // Mostrar con un decimal (ej: 4.9)
            yield return new WaitForSeconds(0.1f);
            tiempo -= 0.1f;
        }

        TextoTime.text = "0.0"; // Asegura que termina en 0.0 exacto
        animCortina.SetTrigger("AbrirCortina");
        BackwardsWalker.Iniciar = true;
    }
}
