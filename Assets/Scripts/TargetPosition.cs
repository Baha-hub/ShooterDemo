using UnityEngine;

public class TargetPosition : MonoBehaviour
{
    public static TargetPosition Instance;
    public Ray ray;
    private Vector2 screenCenterPoint;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        screenCenterPoint = new Vector2(Screen.width / 2f, Screen.height / 2f);
        ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        transform.position = ray.GetPoint(10);
    }
}
