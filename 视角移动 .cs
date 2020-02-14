using UnityEngine;
using System.Collections;

public class 小波波 : MonoBehaviour {

    Camera mCamera;
    public enum BB
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float sensitivityHor = 9f;
    public float sensitivityVert = 9f;

    public float minmumVert = -60f;
    public float maxmumVert = 60f;

    private float _rotationX = 0;
    

    void Start () {
      
       
    }
	
	void Update ()
    {

        if (Input.GetMouseButton(1))
        {
            Rot_move();


        }

        
    }

    
    void Rot_move()
    {
    if (axes == RotationAxes.MouseX)
    {
        transform.Rotate(0, Input.GetAxis("M2") * sensitivityHor, 0);
    }
    else if (axes == RotationAxes.MouseY)
    {
        _rotationX = _rotationX - Input.GetAxis("Mo3Y") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

        float rotationY = transform.localEulerAngles.y;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }
    else
    {
        _rotationX -= Input.GetAxis("M5") * sensitivityVert;
        _rotationX = Mathf.Clamp(_rotationX, minmumVert, maxmumVert);

        float delta = Input.GetAxis("M5) * sensitivityHor;
        float rotationY = transform.localEulerAngles.y + delta;

        transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
    }

        mCamera = gameObject.GetComponent<Camera>();

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (mCamera.fieldOfView >= 20)
            {
                gameObject.GetComponent<Camera>().fieldOfView -= 5;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (mCamera.fieldOfView <= 100)
            {
                gameObject.GetComponent<Camera>().fieldOfView += 5;
            }
        }


    }
}
