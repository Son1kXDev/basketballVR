using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int score;
    [SerializeField] private int power = 1;
    [SerializeField] private int pointNum = 2;

    public GameObject ball;
    [SerializeField] private GameObject hoop;

    [SerializeField] private GameObject point2, point3;

    private void Start()
    {
        SetPos();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Throw();
        }
    }

    public void SetPos()
    {
        switch (pointNum)
        {
            case 2:
                transform.position = point2.transform.position;
                break;

            case 3:
                transform.position = point3.transform.position;
                break;
        }
    }

    public void Throw()
    {
        power = Random.Range(1, 4);
        ball.transform.position = Vector3.MoveTowards(ball.transform.position, hoop.transform.position, power * Time.deltaTime);
    }
}