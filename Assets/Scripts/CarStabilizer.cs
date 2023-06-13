using UnityEngine;

public class CarStabilizer : MonoBehaviour
{
    private void FixedUpdate()
    {
         transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.eulerAngles.y, 0);
    }
}
