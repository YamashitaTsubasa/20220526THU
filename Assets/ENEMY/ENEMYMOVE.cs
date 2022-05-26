using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMYMOVE : MonoBehaviour
{
    private Animator anim = null;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(-0.0009f, 0, 0);
        //anim.SetBool("RUN", true);
    }
}
