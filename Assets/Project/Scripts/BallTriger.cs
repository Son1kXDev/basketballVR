using UnityEngine;

public class BallTriger : MonoBehaviour
{
    [SerializeField] private GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ball")
        {
            if (other.transform.position.y - transform.position.y >= 0)
            {
                player.GetComponent<Score>().AddScore();
                if (Score.score == 30)
                {
                    other.GetComponent<Ball>().DeleteZone();
                }
            }
            else
            {
                player.transform.position = new Vector3(0, player.transform.position.y, 0);
                other.transform.position = new Vector3(player.transform.position.x, 1, player.transform.position.z + 0.5f);
            }
        }
    }
}