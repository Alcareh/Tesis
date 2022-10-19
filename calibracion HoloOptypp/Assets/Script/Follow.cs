using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform toFollow;
    private Vector3 offset;
    private Vector3 OffsetR;
    private Quaternion R;

    private bool ifYouWantToFollowSinceNow = false;

    void Start()
    {
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)==true)
        {
            ifYouWantToFollowSinceNow = true;
            offset = toFollow.position - transform.position;
            OffsetR = toFollow.rotation.eulerAngles-transform.rotation.eulerAngles; 
       }
        if(ifYouWantToFollowSinceNow)
        {
            transform.position = toFollow.position - offset;
            transform.rotation = R;
            R.eulerAngles = toFollow.eulerAngles - OffsetR;
        }

        if (Input.GetKeyDown(KeyCode.J) == true)
        {
            //Debug.Log(OffsetR);
        //    Debug.Log(toFollow.rotation.eulerAngles);
        //    Debug.Log(transform.rotation.eulerAngles);
        //    Debug.Log(R.eulerAngles);
        }
    }
}