using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {

    public Transform GunShaft;
    public KeyCode KeyForBullet = KeyCode.Space;
    public GameObject BulletPrefab;

    private Transform BulletParent;

    private KeyCode KeyForRocket = KeyCode.Alpha1;
    private GameObject RocketPrefab;

    public int  limitShooting=0;
    private int _bulletsLeft = 0;

    public UnityEngine.UI.Text ammoLimitField;

    // Use this for initialization
    void Start () {
        _bulletsLeft = limitShooting;
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyDown(KeyForBullet))
        {
            FireNow();
        }

        if (Input.GetKeyDown(KeyForRocket))
        {
            FireNowRocket();
        }
    }

    private void FireNow()
    {
        if (limitShooting > 0)
        {
            _bulletsLeft -= 1;


            if (_bulletsLeft <= 0)
            {
                ammoLimitField.text = "0";
                return;
            }

            ammoLimitField.text = _bulletsLeft.ToString();

        }
        

        Instantiate(BulletPrefab, GunShaft.transform.position, GunShaft.transform.rotation, BulletParent);
        if (GunShaft.GetComponent<AudioSource>())  GunShaft.GetComponent<AudioSource>().Play();
    }

    private void FireNowRocket()
    {
        Instantiate(RocketPrefab, GunShaft.transform.position, GunShaft.transform.rotation, BulletParent);
        if (GunShaft.GetComponent<AudioSource>()) GunShaft.GetComponent<AudioSource>().Play();
    }
}
