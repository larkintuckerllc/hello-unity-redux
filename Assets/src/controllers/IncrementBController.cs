using UnityEngine;

public class IncrementBController : MonoBehaviour
{
	private void OnTriggerEnter(Collider other)
	{
		Store.Dispatch.OnNext(B.Instance.IncrementB());
	}
}
