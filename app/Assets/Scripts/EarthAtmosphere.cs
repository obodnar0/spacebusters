using Assets.Scripts;
using UnityEngine;

public class EarthAtmosphere : MonoBehaviour
{
    public float speed;
    private static Renderer _rend;
    private static float transparency;

    void Start()
    {
        _rend = GetComponent<Renderer>();
        _rend.enabled = true;
        transparency = _rend.material.color.a;
    }

    public static void ChangeTransparency(float trans)
    {
        transparency = trans;
    }

    public void Update()
    {
        _rend.material.color = _rend.material.color.Opacity(transparency);
        transform.Rotate(0, speed * Time.deltaTime, 0);
    }
}
