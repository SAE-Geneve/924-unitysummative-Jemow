using UnityEngine;

public class BoxCollector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Box box))
        {
            Destroy(box.gameObject);
            GameManager.Instance.AddBox();
        }
    }
}
