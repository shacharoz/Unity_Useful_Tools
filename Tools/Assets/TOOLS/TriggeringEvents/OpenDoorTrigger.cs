using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour {

    public Transform Door;
    public float ZValueClosed;
    public float ZValueOpened;


    // Use this for initialization
    void Start () {

        CloseDoorNow();

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenDoorNow();
        }
    }

    private void OpenDoorNow()
    {
        //open door with code
        Door.position = new Vector3(Door.position.x, Door.position.y, ZValueOpened);

        //open door with animation
        //Door.GetComponent<Animator>().SetTrigger("OpenDoorNow");
    }

    private void CloseDoorNow()
    {
        //close door with code
        Door.position = new Vector3(Door.position.x, Door.position.y, ZValueClosed);

        //close door with animation
        //Door.GetComponent<Animator>().SetTrigger("CloseDoorNow");
    }
}
