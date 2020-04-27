// Note Dealy Trigger was found https://docs.unity3d.com/ScriptReference/WaitForSeconds.html
using UnityEngine;
using System.Collections;

public class door : MonoBehaviour
{
	GameObject the_door;
    GameObject sparkles;
    void OnTriggerEnter( Collider obj  )
    {
	    the_door = GameObject.FindWithTag("SF_Door");
        sparkles = GameObject.FindWithTag("door_sparkles");
        sparkles.SetActive(true);
	    the_door.GetComponent<Animation>().Play("open");
    }

    void OnTriggerExit( Collider obj )
    {
        the_door = GameObject.FindWithTag("SF_Door");
        StartCoroutine(ExampleCoroutine());
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3);
        the_door.GetComponent<Animation>().Play("close");
    }
}