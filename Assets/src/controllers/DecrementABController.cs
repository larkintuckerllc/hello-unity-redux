using UnityEngine;

public class DecrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Dispatch.OnNext(AB.Instance.DecrementAB());
    }
}
