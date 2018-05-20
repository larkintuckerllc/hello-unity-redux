using UnityEngine;

public class DecrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(AB.Instance.DecrementAB());
    }
}
