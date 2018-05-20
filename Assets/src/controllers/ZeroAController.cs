using UnityEngine;

public class ZeroAController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(A.Instance.ZeroA());
    }
}