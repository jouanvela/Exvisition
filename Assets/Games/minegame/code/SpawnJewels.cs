using UnityEngine;
using System.Collections;

public class SpawnJewels : MonoBehaviour
{

    public int xRange = 4;
    public int yRange = 4;
    public int numObjects = 10;

    public GameObject[] objects;
    public int[] range=new int[10];

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < 10; y++)
        {
            range[y] = y;
        }
        shuffle(range);
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < numObjects; i++)
        {
            Vector3 spawnLoc = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange-2), 0);
            int objectPick = range[i];
            Instantiate(objects[objectPick], spawnLoc, Random.rotation);
        }
    }
    public void shuffle(int[] arr)
    {
        int tmp;
        for (int y = 0; y < numObjects; y++)
        {
            tmp = arr[y];
            int k = (int)(1 + (Random.Range(0,1) * 10));
            arr[y] = arr[k];
            arr[k] = tmp;
        }

    }
}