using UnityEngine;

public class IncrementABController : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Store.Dispatch.OnNext(AB.Instance.IncrementAB());
    }
}
