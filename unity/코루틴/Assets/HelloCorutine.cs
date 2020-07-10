using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelloCorutine : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("HelloUnity");
        StartCoroutine("HiCSharp");
        Debug.Log("End");
    }

    // Update is called once per frame
   IEnumerator HelloUnity()
    {
        Debug.Log("Unity");

        yield return new WaitForSeconds(3f);

        Debug.Log("Unity");

    }
    IEnumerator HiCSharp()
    {
        Debug.Log("CSharp");

        yield return new WaitForSeconds(5f);

        Debug.Log("CSharp");
    }
}
