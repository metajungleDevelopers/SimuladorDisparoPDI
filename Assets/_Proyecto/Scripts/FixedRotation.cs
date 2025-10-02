using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    public Transform Transform;

    // Update is called once per frame
    void Update()
    {

        //el trasnform debe tener una rotacion siempre de 60 0 0
        if (Transform != null)
        {
            Transform.rotation = Quaternion.Euler(60, 0, 0);
        }
        else
        {
            Debug.LogWarning("Transform is not assigned in FixedRotation script.");
        }
    }
}
