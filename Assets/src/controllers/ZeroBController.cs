using UnityEngine;

public class ZeroBController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Provider.Dispatch(B.Instance.ZeroB());
    }
}