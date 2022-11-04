using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundFollower : MonoBehaviour
{

    private Camera cam;
    private Transform camT;

    private void Awake()
    {
        cam = Camera.main;
        camT = cam.transform;
    }


    [SerializeField]
    private float lerpSpeed;
    void LateUpdate()
    {
        float x = Mathf.Lerp(transform.position.x, camT.position.x, lerpSpeed);
        float y = Mathf.Lerp(transform.position.y, camT.position.y + 1.2f, lerpSpeed);

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, y, transform.position.z), lerpSpeed);
    }
}
