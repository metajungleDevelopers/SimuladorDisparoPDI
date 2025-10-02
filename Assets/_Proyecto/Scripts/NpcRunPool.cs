using UnityEngine;

public class NpcRunPool : MonoBehaviour
{
    public Transform SpawnPoint;
    public GameObject NpcPrefab;
    public int numeroDeSpawn;

    private void OnTriggerEnter(Collider other)
    {
        // Si es NPC, instancia uno nuevo
        if (other.CompareTag("NPC"))
        {
            Instantiate(NpcPrefab, SpawnPoint.position, SpawnPoint.rotation);
            // Después destruyes el objeto (esto sucede al final del frame)
            Destroy(other.gameObject);
        }
    }


    public void Spawn() 
    {
        Instantiate(NpcPrefab, SpawnPoint.position, SpawnPoint.rotation);
    }
}
