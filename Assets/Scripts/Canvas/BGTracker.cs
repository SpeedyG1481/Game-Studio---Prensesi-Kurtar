using UnityEngine;

public class BGTracker : MonoBehaviour
{
    public GameObject follow;

    void Update()
    {
        transform.position = follow.transform.position;
    }
}