using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody rb;
    public static Vector3 SpawnZone;

    private void Start()
    {
        SpawnZone = new Vector3(0, 1, 4.5f);
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            if (Score.score >= 33)
            {
                if (!Tutorial.isTutorial)
                {
                    Destroy(gameObject);
                }
                else { SpawnZone = new Vector3(0, 1, 4.5f); Score.score = 0; }
            }
            gameObject.transform.position = SpawnZone;
            rb.isKinematic = true;
            gameObject.GetComponent<Teleport>().Enable();
        }
        else
        {
            Vector3 dir = Vector3.back;
            rb.AddForce(dir);
        }
    }

    public void DeleteZone()
    {
        Ball.SpawnZone = new Vector3(0, 1, 0.5f);
        gameObject.GetComponent<Teleport>().teleport = null;
    }
}