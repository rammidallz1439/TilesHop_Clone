using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject tilePrefab;
    public string jsonFileName;

    void Start()
    {
        // Load JSON data from file
        string filePath = Path.Combine(Application.streamingAssetsPath, jsonFileName);
        string jsonData = File.ReadAllText(filePath);

        // Parse JSON data
        SpectrumExtract spectrumData = JsonUtility.FromJson<SpectrumExtract>(jsonData);

        // Spawn tiles based on spectrum data
        foreach (float value in spectrumData.spectrumData)
        {
            if (value > 0.5f) // Example condition for spawning a tile
            {
                SpawnTile();
            }
        }
    }

    void SpawnTile()
    {
        // Spawn tile at desired position
        Instantiate(tilePrefab, transform.position, Quaternion.identity);
    }
}
