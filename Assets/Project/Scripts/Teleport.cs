using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject teleport;
    public GameObject teleportPoint;
    public GameObject player, ball;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ball = GameObject.FindGameObjectWithTag("ball");
    }

    public void Enable()
    {
        teleportPoint.transform.position = new Vector3(ball.transform.position.x, 0, ball.transform.position.z - 0.5f);
    }
}