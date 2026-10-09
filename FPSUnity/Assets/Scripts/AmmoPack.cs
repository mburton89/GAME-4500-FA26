using UnityEngine;

public class AmmoPack : MonoBehaviour
{
    public Cannon cannon;
    public int ammoToGive = 10;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<FPSController>())
        {
            
        }

       
    }









    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
