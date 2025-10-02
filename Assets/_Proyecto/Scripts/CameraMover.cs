using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Camera targetCamera;         // Cámara a mover
    public Transform targetPosition;    // Posición destino
    public float moveSpeed = 5f;        // Velocidad de movimiento
    public KeyCode toggleKey = KeyCode.E; // Tecla para alternar

    private Vector3 originalPosition;
    private bool movingToTarget = false;
    private bool isMoving = false;

    void Start()
    {
        if (targetCamera == null)
        {
            Debug.LogWarning("CameraMover: No camera assigned.");
            return;
        }

        originalPosition = targetCamera.transform.position;
    }

    void Update()
    {
        if (targetCamera == null || targetPosition == null)
            return;

        // Detectar tecla
        if (Input.GetKeyDown(toggleKey))
        {
            movingToTarget = !movingToTarget;
            isMoving = true;
        }

        if (isMoving)
        {
            Vector3 destination = movingToTarget ? targetPosition.position : originalPosition;

            // Mover suavemente
            targetCamera.transform.position = Vector3.MoveTowards(
                targetCamera.transform.position,
                destination,
                moveSpeed * Time.deltaTime
            );

            // Verificar si ya llegó
            if (Vector3.Distance(targetCamera.transform.position, destination) < 0.01f)
            {
                targetCamera.transform.position = destination;
                isMoving = false;
            }
        }
    }
}
