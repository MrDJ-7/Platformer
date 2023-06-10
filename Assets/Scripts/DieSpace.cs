using UnityEngine;

public class DieSpace : MonoBehaviour
{
    public GameObject respawn;
    // private void Update()
    // {
    //     OnTriggerEnter2D(other);
    // }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.position = respawn.transform.position;
        }
    }

}
