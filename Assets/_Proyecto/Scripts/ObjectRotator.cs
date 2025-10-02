using UnityEngine;

public class ObjectRotator : MonoBehaviour
{
    public Transform targetObject;         // Objeto a rotar
    public Vector3 rotationAxis = Vector3.up;  // Eje de rotación (por defecto Y)
    public float rotationSpeed = 90f;      // Grados por segundo
    public float rotationDuration = 10f;   // Segundos que rota
    public float pauseDuration = 10f;      // Segundos que se detiene

    private float timer = 0f;
    private bool isRotating = true;

    void Update()
    {
        if (targetObject == null)
            return;

        timer += Time.deltaTime;

        if (isRotating)
        {
            if (timer <= rotationDuration)
            {
                targetObject.Rotate(rotationAxis.normalized * rotationSpeed * Time.deltaTime);
            }
            else
            {
                timer = 0f;
                isRotating = false;
            }
        }
        else
        {
            if (timer >= pauseDuration)
            {
                timer = 0f;
                isRotating = true;
            }
        }
    }
}
