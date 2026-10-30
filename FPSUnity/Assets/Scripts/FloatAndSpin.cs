using UnityEngine;

public class FloatAndSpin : MonoBehaviour
{

    private Transform AmmoBox;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        AmmoBox = GetComponent<Transform>();
        Vector3 Pos = AmmoBox.position;
        AmmoBox.position = new Vector3(Pos.x, Pos.y + 0.5f, Pos.z);
    }
    // Update is called once per frame
    void Update()
    {
        AmmoBox.Rotate(0, 1, 0);
    }
}
