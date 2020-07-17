using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanGenerator : MonoBehaviour
{
    public GameObject[] propPrefabs;
    private BoxCollider area;
    public int count = 100;
    private List<GameObject> props = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        area = GetComponent<BoxCollider>();

        for(int i=0; i < count; i++)
        {
            Spawn();
        }

        area.enabled = false;
    }
    
    private void Spawn()
    {
        int selection = Random.Range(0, propPrefabs.Length);
        GameObject selectedPrefabs = propPrefabs[selection];
        Vector3 spawnPos = GetRandomPosition();

        GameObject instance = Instantiate(selectedPrefabs, spawnPos, Quaternion.identity);
        props.Add(instance);
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float PosX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2);
        float PosY = basePosition.y + Random.Range(-size.y / 2f, size.y / 2);
        float PosZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2);

        Vector3 spawnPos = new Vector3(PosX, PosY, PosZ);
        return spawnPos;
    }

    public void Reset()
    {
        for(int i = 0; i < props.Count; i++)
        {
            props[i].transform.position = GetRandomPosition();
            props[i].SetActive(true);
        }
    }
}
