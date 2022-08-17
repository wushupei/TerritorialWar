using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Test1 : MonoBehaviour
{
    PlayerSystem ps;
    void Start()
    {
        ps = GetComponent<PlayerSystem>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
            ps.SetMultiple(true);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ps.Fire();
            ps.SetMultiple(false);
        }
    }
}
