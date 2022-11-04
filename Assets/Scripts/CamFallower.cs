using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFallower : MonoBehaviour
{

    
    private Transform playerT;

    private void Start()
    {
        playerT = PlayerMovement.mT;
    }
   



    [SerializeField]
    private float lerpSpeed;
    void LateUpdate()
    {
        float x = Mathf.Lerp(transform.position.x, playerT.position.x, lerpSpeed);
        //float y = Mathf.Lerp(transform.position.y, playerT.position.y + 1.2f, lerpSpeed);

        transform.position = Vector3.Lerp(transform.position, new Vector3(x, transform.position.y, transform.position.z),1);
    }
}
