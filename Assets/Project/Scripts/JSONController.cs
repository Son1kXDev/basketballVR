using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class JSONController : MonoBehaviour
{
    public static JSONController instance;
    public List<Save> saves;
    public Save save;
    public TextMeshProUGUI savesText;
    public bool isSave;

    private void Awake()
    {
        if (instance) Destroy(this.gameObject);
        else instance = this; DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (isSave)
        {
            SaveField();
        }
    }

    public void LoadField()
    {
        instance.saves.Add(JsonUtility.FromJson<Save>(File.ReadAllText(Application.streamingAssetsPath + "/save.json")));
        if (instance.savesText == null) instance.savesText = GameObject.FindGameObjectWithTag("jsonText").GetComponent<TextMeshProUGUI>();
        for (int i = 0; i < instance.saves.Count; i++)
        {
            string gameNumber = $"Игра {instance.saves[i].gameNumber} - ";
            string playerScore = $"Игрок: {instance.saves[i].playerScore}, ";
            string botScore = $"Противник: {instance.saves[i].botScore}, ";
            float min = Mathf.FloorToInt(instance.saves[i].gameTime / 60);
            float sec = Mathf.FloorToInt(instance.saves[i].gameTime % 60);
            string gameTime = string.Format("Время игры: {0:00}:{1:00}", min, sec);
            instance.savesText.text += $"{gameNumber + playerScore + botScore + gameTime}\n";
        }
    }

    public void SaveField()
    {
        instance.save.gameNumber++;
        instance.save.playerScore = Score.score;
        instance.save.botScore = 0;
        instance.save.gameTime = Timer.time;
        File.WriteAllText(Application.streamingAssetsPath + "/save.json", JsonUtility.ToJson(save));
        Score.score = 0;
        isSave = false;
    }

    [System.Serializable]
    public struct Save
    {
        public int gameNumber;
        public int playerScore;
        public int botScore;
        public float gameTime;
    }
}