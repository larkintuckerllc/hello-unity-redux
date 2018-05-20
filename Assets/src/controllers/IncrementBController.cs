using UnityEngine;

public class IncrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Instance.storeDispatch.OnNext(B.IncrementB());
	}
}
