using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBigBoi : MonoBehaviour
{

    public bool summonBigBoi;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (summonBigBoi)
        {
            GameObject.FindGameObjectWithTag("BigBoi").GetComponent<SpriteRenderer>().enabled = true;
            summonBigBoi = false;
        }
    }
}
