using UnityEngine;

public class DecrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Dispatch.OnNext(B.Instance.DecrementB());
	}
}
