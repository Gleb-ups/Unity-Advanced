using UnityEngine;

public class MovingController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0F;

    private float defaultTrans = 0.0F;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (GameManager.GM.GetStateByKey("gameOver")) return;
        float translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        if (translation > defaultTrans)
        {
            anim.SetBool("moving", true);
            transform.Translate(0, 0, translation);
        }
        else
        {
            anim.SetBool("moving", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        anim.SetBool("inBound", false);
        GameManager.GM.SetStateByKey("gameOver", true);
    }
}
