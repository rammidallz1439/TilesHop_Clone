using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpectrumExtract : MonoBehaviour
{
    public AudioSource audioSource;     // Reference to the AudioSource component playing the music
    public int sampleCount = 1024;      // Number of samples to collect
    public float[] spectrumData;        // Array to store the spectrum data

    void Start()
    {
        spectrumData = new float[sampleCount];
    }

    void Update()
    {
        // Get spectrum data from the audio source
        audioSource.GetSpectrumData(spectrumData, 0, FFTWindow.BlackmanHarris);

        // Convert spectrum data to JSON format
        string jsonData = ConvertSpectrumDataToJson();

        // Do something with the JSON data (e.g., save to file)
        SaveJSONToFile(jsonData);
    }

    string ConvertSpectrumDataToJson()
    {
        // Create a list to store the formatted spectrum data
        List<string> formattedSpectrumList = new List<string>();

        // Add spectrum data to the list and format each value
        for (int i = 0; i < spectrumData.Length; i++)
        {
            // Format each value with 4 decimal places
            string formattedValue = spectrumData[i].ToString("F4");
            formattedSpectrumList.Add(formattedValue);
        }

        // Serialize the list to JSON format using JsonUtility
        string jsonData = JsonUtility.ToJson(formattedSpectrumList);

        return jsonData;
    }

    void SaveJSONToFile(string jsonData)
    {
        // Specify the file path where you want to save the JSON data
        string filePath = Path.Combine(Application.streamingAssetsPath, "spectrumData.json");

        // Write the JSON data to the file
        File.WriteAllText(filePath, jsonData);

        // Log the path to the saved JSON file
        Debug.Log("JSON data saved to: " + filePath);
    }
}
