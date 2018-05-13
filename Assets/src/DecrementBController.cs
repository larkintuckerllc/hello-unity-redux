using UnityEngine;

public class DecrementBController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(B.DecrementB());
    }
}
