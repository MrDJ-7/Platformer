using UnityEditor.Tilemaps;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{

    public float speed = 20f;
    private Rigidbody2D rb;

    bool faceRight = true;

    public GameObject playerMain;
    private int numjumps = 2;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        rb.MovePosition(rb.position + Vector2.right * moveX * speed * Time.deltaTime * 10);
        if (numjumps > 0 && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * 8000);
            numjumps--;
        }
        if (moveX > 0 && !faceRight)
            flip();
        else if (moveX < 0 && faceRight)
            flip();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
            numjumps = 2;
    }

    void flip()
    {
        faceRight = !faceRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
