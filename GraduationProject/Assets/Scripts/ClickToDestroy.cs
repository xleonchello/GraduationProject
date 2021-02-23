using UnityEngine;
public class ClickToDestroy : MonoBehaviour
{
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}