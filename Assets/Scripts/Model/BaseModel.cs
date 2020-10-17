using UnityEngine;


public abstract class BaseModel : MonoBehaviour
{
    protected GameObject prefabBase;
    protected Rigidbody rigidbodyBase;
    protected Transform transformBase;

    protected BotBase bot;
    protected BallBase ball;

    protected virtual void Awake()
    {
        prefabBase = GetComponent<GameObject>();
        rigidbodyBase = GetComponent<Rigidbody>();
        transformBase = GetComponent<Transform>();
    }
}