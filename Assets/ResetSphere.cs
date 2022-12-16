using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetSphere : MonoBehaviour
{
    public GameObject sphere;
    
    public void Reset()
    {
        sphere.transform.localPosition = new Vector3(1.566f, -0.132f, 0.578f);
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
        sphere.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
