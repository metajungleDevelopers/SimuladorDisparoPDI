using UnityEngine;

public class ResetShoot : MonoBehaviour
{



    public void ResetAll() 
    {
        //reiniciamos la escena activa
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);

    }
}
