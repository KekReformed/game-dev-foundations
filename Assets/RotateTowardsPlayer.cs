using UnityEngine;

public class RotateTowardsPlayer : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        transform.localRotation = Quaternion.Euler(new Vector3(0, Vector3.RotateTowards(transform.right, player.transform.position, 100, 100).y, 0));
    }
}
