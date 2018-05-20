using UnityEngine;

public class IncrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.storeDispatch.OnNext(AB.Instance.IncrementAB());
    }
}
