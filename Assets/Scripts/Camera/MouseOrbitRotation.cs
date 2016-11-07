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
    // переменные столкновения камеры со стенами
    public float maxdistance = 5.0f; //максимальное отдаление камеры
    public float mindistance = 1.0f; // минимальное расстояние камеры до игрока
    //private float CollideRange = 1.0f; // 
    //private float CollideAmmount = 0.1f;
  
    void Start()
    {
        angles = transform.eulerAngles; //задаем перменную углы 
        x = angles.x;
        y = angles.y;
        

    }
    void Update()
    { 
        
    
        
        
    }
    void LateUpdate()
    {
        //Переменны вращения камеры
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
         
        //Строки столкновения камеры с объектами
        RaycastHit hit; //при столкновении луча с каким-либо объектом, в эту переменную записывается инфа об объекте
        Debug.DrawRay(target.position, position - target.position, Color.green);//это для визуального отображения луча в окне Scene при запуске
        
        // кастуем луч от камеры до персонажа, который при соприкосновении с каким-либо объектом на заданном расстоянии будет...
        //if (Physics.Raycast(position, target.position - position, out hit))
        if (Physics.Raycast(target.position, position - target.position, out hit))
        //if (Physics.SphereCast(position, 3.0f, target.position - position, out hit))
        {
            distance = hit.distance; //...брать дистанцию до объекта и отдавать ее камере
        }
        // не даем камере уплывать дальше чем положено
        if (distance > maxdistance)
        {
            distance = maxdistance;
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
