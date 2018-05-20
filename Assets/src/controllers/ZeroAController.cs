using UnityEngine;

public class ZeroAController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Dispatch.OnNext(A.Instance.ZeroA());
    }
}