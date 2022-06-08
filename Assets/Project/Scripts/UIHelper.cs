using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHelper : MonoBehaviour
{
    private void Start()
    {
        if (Application.loadedLevelName == "Menu")
        {
            print("Load");
            JSONController.instance.LoadField();
        }
        else print("No Load");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trash")
        {
            Application.Quit();
        }
        if (other.gameObject.tag == "Game")
        {
            SceneManager.LoadScene("Game");
            Score.score = 0;
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Menu")
        {
            SceneManager.LoadScene("Menu");
            Destroy(gameObject);
        }
        if (other.gameObject.tag == "Training")
        {
            SceneManager.LoadScene("Training");
            Destroy(gameObject);
        }
    }
}