using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsHolder : MonoBehaviour
{
    public delegate void TriggerEnter2DDelegate(Collider2D collider);
    public delegate void TriggerStay2DDelegate(Collider2D collider);
    public delegate void TriggerExit2DDelegate(Collider2D collider);

    public event TriggerEnter2DDelegate CustomOnTriggerEnter2D;
    public event TriggerStay2DDelegate CustomOnTriggerStay2D;
    public event TriggerExit2DDelegate CustomOnTriggerExit2D;

    void OnTriggerEnter2D(Collider2D collision) => CustomOnTriggerEnter2D?.Invoke(collision);
    void OnTriggerStay2D(Collider2D collision) => CustomOnTriggerStay2D?.Invoke(collision);
    void OnTriggerExit2D(Collider2D collision) => CustomOnTriggerExit2D?.Invoke(collision);
}
