using UnityEngine;
public class WallDestroy : MonoBehaviour
{
    void OnCollisionEnter (Collision other)
{
    if (other.collider.tag == "Wall")
    {
        Destroy (other.gameObject);
    }
}
}
