using UnityEngine;
using UnityEngine.UI;

public class SmoothPositionSwitcher : MonoBehaviour
{
    public float[] positionsX = { -2f, 0f, 2f }; // 3 posiciones en X
    public float moveSpeed = 5f; // Velocidad del movimiento

    private int currentIndex = 1; // Empezamos en la posición del medio
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(positionsX[currentIndex], transform.position.y, transform.position.z);
        transform.position = targetPosition;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);
    }

    public void cambiarPos(int num)
    {
        if (num >= 0 && num < positionsX.Length)
        {
            currentIndex = num;
            targetPosition = new Vector3(positionsX[currentIndex], transform.position.y, transform.position.z);
            // Ya no hace falta mover la posición directamente, lo hace Update suavemente
        }
    }
}
