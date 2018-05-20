using UnityEngine;

public class ZeroAController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Instance.storeDispatch.OnNext(A.Instance.ZeroA());
    }
}