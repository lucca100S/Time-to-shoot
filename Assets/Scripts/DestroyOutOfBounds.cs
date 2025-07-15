using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    public float upperBoundary;
    public float lowerBoundary;
    
    
    private void Update()
    {
        if (transform.position.z < lowerBoundary || transform.position.z > upperBoundary)
        {
            Destroy(gameObject);
        }
    }
}
