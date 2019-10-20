using UnityEditor;
using Assets.Scripts;
using UnityEngine;

public class EarthAtmosphere : MonoBehaviour
{
    public float speed;
    private static Renderer _rend;
    private static float transparency;
    public static float Radius = 1000;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
        transparency = _rend.material.color.a;
    }

    public static void SetRadius(float radius)
    {
        Radius = radius;
    }


    public static void ChangeTransparency(float trans)
    {
        transparency = trans;
    }

    public void Update()
    {
        float gs = Radius;
        _rend.transform.localScale = new Vector3(gs,gs,gs);
        _rend.material.color = _rend.material.color.Opacity(transparency);
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
