using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
   public GameObject player;
   private Vector3 offset3rdPersonView = new Vector3(0, 5, -7);

   private Vector3 offset1stPersonView = new Vector3(0, 3.22f, -0.03f);

    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = offset3rdPersonView;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //offset camera started in 3rd person view, when user presses 'c' key, switch to 1st person view
    
        if (Input.GetKeyDown("c"))
        {
            if (offset == offset3rdPersonView)
            {
                offset = offset1stPersonView;
            }
            else
            {
                offset = offset3rdPersonView;
            }
        }
        transform.position = player.transform.position + offset;
    }
}
