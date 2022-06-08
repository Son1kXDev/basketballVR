using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static float time;
    [SerializeField] private TextMeshProUGUI timerText;
    public bool isOver = false;

    private void Start()
    {
        if (!isOver)
        {
            time = 0;
        }
        else DisplayTime(time);
    }

    private void Update()
    {
        if (!isOver)
        {
            time += Time.deltaTime;
            DisplayTime(time);
        }
    }

    private void DisplayTime(float time)
    {
        time += 1;
        float min = Mathf.FloorToInt(time / 60);
        float sec = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}