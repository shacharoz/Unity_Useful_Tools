using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{


    public int speed;
    public int angleOfRuote;

    public void Drive( int acceleratorValue ){
        speed = acceleratorValue;
    }

    public void Reverse( int acceleratorValue ){
        speed = -acceleratorValue;
    }

    public void RotateVolante( int angleOfVolante )
    {
        angleOfRuote = angleOfVolante;
    }








    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
