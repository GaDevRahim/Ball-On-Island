using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    int waveCount = 0;

    [SerializeField] GameObject enamy;
    [SerializeField] GameObject powerObj;
    float maxRangeXZ = 9.0f;
    float randomX;
    float randomZ;
    Vector3 randomPosi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(FindObjectsOfType<Enamy>().Length == 0 && !PlayerController.gameOver)
        {
            waveCount++;
            CreateObj();
        }
            
    }

    void CreateObj()
    {
        for (int i = 0; i < waveCount; i++)
        {
            Instantiate(enamy, CreateRandomPosi(), enamy.transform.rotation);
        }
        Instantiate(powerObj, CreateRandomPosi(), powerObj.transform.rotation);
    }

    Vector3 CreateRandomPosi()
    {
        randomX = Random.Range(-maxRangeXZ, maxRangeXZ);
        randomZ = Random.Range(-maxRangeXZ, maxRangeXZ);
        randomPosi.Set(randomX, 0, randomZ);
        return randomPosi;
    }
}
