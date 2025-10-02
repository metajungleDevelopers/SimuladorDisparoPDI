using UnityEngine;

public class BackwardsWalker : MonoBehaviour
{
    [Header("Objetivo al que caminar")]
    public Transform target;

    [Header("Velocidad de movimiento")]
    public float moveSpeed = 2f;

    public Animator Animator1;
    public Animator Animator2;

    public bool Iniciar;

    void Update()
    {
        if (target == null) return;

        if(Iniciar == true) 
        {
            // Dirección desde el personaje hacia el objetivo
            Vector3 toTarget = target.position - transform.position;
            toTarget.y = 0; // Ignora la altura para rotación en plano XZ

            if (toTarget.magnitude > 0.1f)
            {
                // Activar animaciones de caminar
                Animator1.SetBool("isWalking", true);
                Animator2.SetBool("isWalking", true);
                // ROTACIÓN: personaje mira en dirección opuesta al objetivo
                Quaternion backwardsRotation = Quaternion.LookRotation(-toTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, backwardsRotation, Time.deltaTime * 5f);

                // MOVIMIENTO: se mueve hacia el objetivo (aunque esté rotado en contra)
                Vector3 moveDir = toTarget.normalized;
                transform.position += moveDir * moveSpeed * Time.deltaTime;
            }
            //Si llego al punto que desactive dos animaciones
            else
            {
                // Desactivar animaciones
                Animator1.SetBool("isWalking", false);
                Animator2.SetBool("isWalking", false);

            }
        }

        
    }
}
