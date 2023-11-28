using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statuseffect : MonoBehaviour
{
    public GameObject myPrefab;
    public GameObject canvasObject;

    void Start()
    {
        GameObject newSmoke = Instantiate(myPrefab, new Vector3(827.4f, 552, 0), Quaternion.Euler(0, 0, 0)) as GameObject;
        newSmoke.transform.SetParent(canvasObject.transform, false);
        newSmoke.transform.localScale = new Vector3(1, 1, 1);
    }
}
