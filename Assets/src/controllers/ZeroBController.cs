using UnityEngine;

public class ZeroBController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Dispatch.OnNext(B.Instance.ZeroB());
    }
}