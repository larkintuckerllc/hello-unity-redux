using UnityEngine;

public class DecrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Instance.storeDispatch.OnNext(AB.DecrementAB());
    }
}
