using UnityEngine;

public class LineMovement : MonoBehaviour
{
    public int timer = 5;
    public int direction = 1;
    private void FixedUpdate()
    {
        if (timer == 0)
        {
            if (transform.position.x > 5.5f)
            {
                direction = -1;
                var transform1 = transform;
                var position = transform1.position;
                position.y -= 2;
                transform1.position = position;
            }
            else if (transform.position.x < -13.8f)
            {
                direction = 1;
                var transform1 = transform;
                var position = transform1.position;
                position.y -= 2;
                transform1.position = position;
            }
            timer = 50;
            var vector3 = Vector3.zero;
            vector3.x = 0.7f * direction;
            transform.position += vector3;
        }
        timer--;
    }
}
