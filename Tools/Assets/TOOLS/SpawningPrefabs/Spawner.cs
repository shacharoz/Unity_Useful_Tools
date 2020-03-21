using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject PrefabToSpawn;

    public void SpawnNow()
    {
        Instantiate(PrefabToSpawn, transform.position, transform.rotation);        
    }
    public void SpawnNow(Transform here)
    {
        Instantiate(PrefabToSpawn, here.position, here.rotation);
    }
}
