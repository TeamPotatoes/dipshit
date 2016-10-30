using UnityEngine;
using System.Collections;

public class MouseOrbitRotation : MonoBehaviour
{
    public Transform target; //в эту точку нацелена камера и отсюда берем координаты (объект CameraTarget в шее персонажа)
    
    public float distance = 5.0f;
    public float x_speed = 250.0f;
    public float y_speed = 120.0f;
    public int y_min_limit = -20;
    public int y_max_limit = 80;

    private float x = 0.0f;
    private float y = 0.0f;
    private Vector3 angles;
    private Quaternion rotation;
    private Vector3 position;
    
  
    void Start()
    {
        angles = transform.eulerAngles; //задаем перменную углы 
        x = angles.x;
        y = angles.y;
        

    }

    void LateUpdate()
    {

        if (target)
        {
            x += Input.GetAxis("Mouse X") * x_speed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * y_speed * 0.02f;
    
            y = ClampAngle(y, y_min_limit, y_max_limit);

            rotation = Quaternion.Euler(y, x, 0);
            position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;

            transform.rotation = rotation;
            transform.position = position;
        }

    }
    float ClampAngle(float angle, float min, float max)
   {
        if (angle < -360)
           angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
}
