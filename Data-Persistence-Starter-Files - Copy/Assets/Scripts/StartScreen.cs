using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartScreen : MonoBehaviour
{
    public Text input, highscore;
    public StartScreen Instance;
    public static string str;
    public static int highScore;

    private void Start()
    {
        LoadHIghScore();
    }
    private void FixedUpdate()
    {
        str = input.text;
        highscore.text = "HighScore : " + highScore;
    }
    [System.Serializable]
    public class SaveData
    {
        public string inputName;
        public int highScore;
    }
    public void SaveColor()
    {
        SaveData data = new SaveData();
        data.inputName = str;
       
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.dat",json);
        
    }
    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savedata.dat";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            str = data.inputName;
            
          
        }
    }
    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savedata.dat";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            if (MainManager.m_Points > MainManager.high)
            {
                highScore = data.highScore;
            }

        }
    }
    public void SaveButton()
    {
        Instance.SaveColor();
    }
    public void LoadButton()
    {
        Instance.LoadColor();
        MainManager.username = str;
    }
    public  void LoadHIghScore()
    {
        Instance.LoadHIghScore();
        MainManager.high = highScore;
       
    }
}
