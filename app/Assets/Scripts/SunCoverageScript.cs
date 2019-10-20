using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class SunCoverageScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ObjectsStorage.Ints.StarCoverage = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.localScale = new Vector3(ObjectsStorage.Ints.Star.transform.localScale.x + 1, ObjectsStorage.Ints.Star.transform.localScale.y + 1, ObjectsStorage.Ints.Star.transform.localScale.z + 1);
    }
}
