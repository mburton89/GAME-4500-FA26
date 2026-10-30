using UnityEngine;

public class CircularFloating : MonoBehaviour
{
    private float floatHight;
    private float rotation;

    void Update()
    {
        transform.localPosition = new Vector3(0, Mathf.Sin(floatHight) * 0.2f, 0);
        floatHight += 0.001f;

        transform.localRotation = Quaternion.Euler(0f, rotation, 0f);
        rotation += 0.1f;
        
        if (rotation >= 360f)
            rotation = 0f;
        
    }
}