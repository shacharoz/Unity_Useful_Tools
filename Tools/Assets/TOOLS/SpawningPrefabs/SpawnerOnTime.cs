using UnityEngine;

public class SpawnerOnTime : MonoBehaviour
{
    [SerializeField]
    private GameObject enemy;
    [SerializeField]
    private float rate = 1.5f;
    private float time_from_last_spawn = 0;
    [SerializeField]
    private Transform room;
    public bool useX;
    [SerializeField]
    private float xMin;
    [SerializeField]
    private float xMax;
    public bool useZ;
    [SerializeField]
    private float zMin;
    [SerializeField]
    private float zMax;

    void Update()
    {
        time_from_last_spawn += Time.deltaTime;
        if (time_from_last_spawn >= rate)
        {
            if (room) room.gameObject.SetActive(false);

            float deltaX = (useX) ? Random.Range(xMin, xMax) : 0;
            float deltaZ = (useZ) ? Random.Range(zMin, zMax) : 0;

            Instantiate(enemy, transform.position + new Vector3(deltaX, 0, deltaZ), Quaternion.identity, transform);
            time_from_last_spawn = 0;
        }
    }
}