using UnityEngine;

/// <summary>
/// Unity Script to give camera WASD + mouse control
/// WASD : basic movement ; mouse directs the orientation of the view
/// Left Shift : Accelerate (as in running)
/// Space : Toggle moving camera on X and Z axes only.
/// </summary>
/// <author>Windexglow (11-13-2010), gunderson (2017)</author>
/// <see cref="https://gist.github.com/gunderson/d7f096bd07874f31671306318019d996#file-flycamera-cs-L56"/>
public class FlyCamera : MonoBehaviour
{
    /// <summary>
    /// regular speed
    /// </summary>
    [Tooltip("Normal movement speed")]
    public float mainSpeed = 100.0f;

    /// <summary>
    /// Running speed. Multiplied by how long (left) shift is held. 
    /// if you dont want the extra speed, put here the same number as normal speed.
    /// </summary>
    [Tooltip("Acceleration when holding left shift")]
    public float shiftAdd = 250.0f;

    /// <summary>
    /// Maximum speed when holding left shift
    /// </summary>
    [Tooltip("Maximum speed when holding left shift")]
    public float maxShift = 1000.0f;

    /// <summary>
    /// mouse sensitivity 
    /// </summary>
    [Tooltip("mouse sensitivity")]
    public float camSens = 0.25f;

    /// <summary>
    /// kind of in the middle of the screen, rather than at the top (play)
    /// </summary>
    private Vector3 lastMouse = new Vector3(255, 255, 255);
    private float totalRun = 1.0f;

    void Update()
    {
        //calculate mouse view direction
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x, transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse = Input.mousePosition;
        //Mouse camera angle done.


        //Keyboard commands
        float f = 0.0f;
        Vector3 p = GetBaseInput(); //take WASD input from user

        if (Input.GetKey(KeyCode.LeftShift))
        {
            //if LeftShift -> Running mode
            totalRun += Time.deltaTime;
            p = p * totalRun * shiftAdd;
            p.x = Mathf.Clamp(p.x, -maxShift, maxShift);
            p.y = Mathf.Clamp(p.y, -maxShift, maxShift);
            p.z = Mathf.Clamp(p.z, -maxShift, maxShift);
        }
        else
        {
            //No Shift -> normal speed
            totalRun = Mathf.Clamp(totalRun * 0.5f, 1f, 1000f);
            p = p * mainSpeed;
        }

        p = p * Time.deltaTime;
        Vector3 newPosition = transform.position;
        if (Input.GetKey(KeyCode.Space))
        {
            //If player wants to move on X and Z axis only
            transform.Translate(p);
            newPosition.x = transform.position.x;
            newPosition.z = transform.position.z;
            transform.position = newPosition;
        }
        else
        {
            transform.Translate(p);
        }
    }

    /// <summary>
    /// checks basic WASD input and put it in a Vector. if it's 0 than it's not active.
    /// </summary>
    /// <returns>Vector of all user input from WASD</returns>
    private Vector3 GetBaseInput()
    { 
        Vector3 p_Velocity = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            p_Velocity += new Vector3(0, 0, 1);
        }
        if (Input.GetKey(KeyCode.S))
        {
            p_Velocity += new Vector3(0, 0, -1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            p_Velocity += new Vector3(-1, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            p_Velocity += new Vector3(1, 0, 0);
        }
        return p_Velocity;
    }
}