using UnityEngine;

public class WallCollision : MonoBehaviour
{
    [SerializeField]
    private Material wallMaterial;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Box")
        {
            wallMaterial.color = Random.ColorHSV();
        }
    }
}
