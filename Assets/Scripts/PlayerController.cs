using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool canRotate;

    public GameObject planetToRotate;//to get the position in worldspace to which this gameObject will rotate around.

    [Header("Settate solo la z")]
    public Vector3 axis;//by which axis it will rotate. x,y or z.

    [Header("Velocità di rotazione")]
   public float angle; //or the speed of rotation.
    float oldPoint;
    UiManager managerUi;

    private void Start()
    {
        managerUi = FindObjectOfType<UiManager>();
        oldPoint = managerUi.points;
    }

    // Update is called once per frame
    void Update()
    {
        IncreseSpeed();
        if (canRotate)
        {
            //Gets the position of your 'Turret' and rotates this gameObject around it by the 'axis' provided at speed 'angle' in degrees per update 
            transform.RotateAround(planetToRotate.transform.position, axis, angle*Time.deltaTime);
        }
    }

    void IncreseSpeed() {
        if (oldPoint != managerUi.points) {
            oldPoint = managerUi.points;
            angle += 3f;
        }
    }
}
