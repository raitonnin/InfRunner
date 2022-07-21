using UnityEngine;
public class FloorDestroy : MonoBehaviour
{
      void OnCollisionEnter (Collision other)
{
        if (other.collider.tag == "Ground")
    {
        
        Destroy (other.gameObject);
    }
}
}
