using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlatformGenerator : MonoBehaviour
{
    public GameObject[] platformblock;
    public int maxPlatformCount = 15;
    public int currentPlatformCount = 0;
    public float zPos;
    public float blockLength = 20;
    public List<GameObject> generatedTiles;
    public Transform player;
    public TMP_Text distanceText;

    private void Start()
    {
        generatedTiles = new List<GameObject>();
        GeneratePlatform();
        

    }
    private void Update()
    {
        CheckDistance();
        distanceText.text = Mathf.FloorToInt(player.transform.position.z).ToString() + " M";
    }
    public void CheckDistance()
    {
        //Check how close is the latest generated Block.
        //If las block closer than blocklength, generate new block and delete last one
        if (Mathf.Abs(player.transform.position.z - zPos) < maxPlatformCount * blockLength - blockLength) 
        {
            DestroyBlocks();
            GeneratePlatform(); 
        }

    }
    public void DestroyBlocks()
    {
        if (generatedTiles.Count > 0)
        {
            GameObject blockToRemove = generatedTiles[0]; // Get the first block in the list
            generatedTiles.RemoveAt(0); // Remove it from the list
            Destroy(blockToRemove); // Destroy the GameObject
            currentPlatformCount--;
        }
    }
    public void GeneratePlatform()
    {
        for(int i = currentPlatformCount; i < maxPlatformCount; i++)
        {
            GameObject block;
            if (i < 5)
            {
                block = Instantiate(platformblock[0], new Vector3(0, 0, zPos), Quaternion.identity);
            }
            else
            {
                block = Instantiate(platformblock[Random.Range(0, platformblock.Length)], new Vector3(0, 0, zPos), Quaternion.identity);
            }
            generatedTiles.Add(block);
            zPos += blockLength;
            currentPlatformCount++;
        }
    }
}
