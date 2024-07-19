using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenueManager : MonoBehaviour
{


    public string UName;

    private string bestScore;


    public static MenueManager Instance = null;
    private void Awake() {
        Debug.Log("ON MENU MANAGER AWAK!");
        if (Instance != null && Instance == this) {
            Destroy(this);
            return;
        } else if (Instance == null){
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    [Serializable]
    class SaveData {
        public SaveData() {
            BestScore = 0;
        }

        public int BestScore;
    }

    public string LoadBestScore() {
        var path = System.IO.Path.Combine(Application.persistentDataPath, "bScore.json");
        if (!System.IO.File.Exists(path)) {
            Debug.Log("didnt found file while loading best score!");
            bestScore = "Best Score : 0";
        } else {
            var scoreJson = System.IO.File.ReadAllText(path);
            SaveData oldBestScore = JsonUtility.FromJson<SaveData>(scoreJson);
            bestScore = $"Best Score : {oldBestScore.BestScore}";
            Debug.Log($"loaded from json file: {bestScore}");
        }

        return bestScore;
    }

    public void SaveIfBestScore(string score) {
        var path = System.IO.Path.Combine(Application.persistentDataPath, "bScore.json");
        int scoreInt = Int32.Parse(score.Split(':')[1].Trim());
        int bScoreInt = Int32.Parse(bestScore.Split(':')[1].Trim());
        Debug.Log($"Score after death : {scoreInt}, {bScoreInt}");


        if (!System.IO.File.Exists(path)) {
            var stream = System.IO.File.Create(path);
            stream.Close();
        }

        if (scoreInt > bScoreInt) {
            SaveData nBestScore = new SaveData();
            nBestScore.BestScore = scoreInt;
            var nBestScoreJson = JsonUtility.ToJson(nBestScore);

            Debug.Log($"SAVING!{nBestScoreJson}");
            System.IO.File.WriteAllText(path, nBestScoreJson);
        }
    }
}
