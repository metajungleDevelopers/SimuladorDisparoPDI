using UnityEngine;

public class ResetCagadores : MonoBehaviour
{
    public GameObject CargadorPrefab;
    public Transform[] SpawnPoints;



    public void Reset()
    {
        //Instanciamos un nuevo cargador en cada punto de spawn
        foreach (Transform spawnPoint in SpawnPoints)
        {
            Instantiate(CargadorPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
