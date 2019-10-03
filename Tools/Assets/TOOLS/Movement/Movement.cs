
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public KeyCode LeftKey = KeyCode.A;
    public KeyCode RightKey = KeyCode.D;
    public KeyCode UpKey = KeyCode.W;
    public KeyCode DownKey = KeyCode.S;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //controlling the player up and down, left and right
        Move();

    }



    private void Move()
    {
        if (Input.GetKey(LeftKey))
        {
            transform.Translate(Vector3.left * Time.deltaTime * Speed);
        }

        if (Input.GetKey(RightKey))
        {
            transform.Translate(Vector3.right * Time.deltaTime * Speed);
        }

        if (Input.GetKey(UpKey))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * Speed);
        }

        if (Input.GetKey(DownKey))
        {
            transform.Translate(Vector3.back * Time.deltaTime * Speed);
        }
    }
}
