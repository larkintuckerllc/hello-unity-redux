using UnityEngine;

public class SpeedCheckController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        float magnitude = other.GetComponent<Rigidbody>().velocity.magnitude;
        Provider.Dispatch(SpeedCheck.Instance.SetSpeedCheck((int)magnitude));
    }
}
