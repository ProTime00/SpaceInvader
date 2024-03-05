using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject EnemyLine1;
    public GameObject EnemyLine2;
    public GameObject EnemyLine3;
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(EnemyLine3, transform.position, transform.rotation);
            Vector3 pos = Vector3.zero;
            pos.y -= 1.5f;
            Instantiate(EnemyLine2, transform.position + pos, transform.rotation);
            pos.y -= 1.5f;
            Instantiate(EnemyLine1, transform.position + pos, transform.rotation);
        }
    }
}
