using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public float timeElapsed;
    public Color unitColour;

    private void Awake()
    {
        //making sure that there is always one of this (destroying any copies)
        if(Instance != null)
        {
            Destroy(gameObject);
        }

        // setting the current object as Instance
        Instance = this;

        //making this object persistent
        DontDestroyOnLoad(gameObject);

        loadColour();
        Debug.Log(Application.persistentDataPath + "/savefile.json");
            
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    [System.Serializable]
    class saveData
    {
        public Color _unitColor;
    }

    public void saveColour()
    {
        saveData data = new saveData();
        data._unitColor = unitColour;

        string jsonData = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void loadColour()
    {
        string jsonData = File.ReadAllText(Application.persistentDataPath + "/savefile.json");
        saveData data = JsonUtility.FromJson<saveData>(jsonData);

        unitColour = data._unitColor;
    }
}
