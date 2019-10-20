using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class StarDistanceScript : MonoBehaviour
{
    private Slider DistanceSlider;

    void Start()
    {
        DistanceSlider = GameObject.Find("DSlider").GetComponent<Slider>();
    }

    void Update()
    {
        ObjectsStorage.Ints.Star.transform.position = new Vector3(ObjectsStorage.Ints.Star.transform.position.x,
            ObjectsStorage.Ints.Star.transform.position.y, -DistanceSlider.value / 100);
        ObjectsStorage.Ints.StarCoverage.transform.position = ObjectsStorage.Ints.Star.transform.position;
    }
}
