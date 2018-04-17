using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    public enum Type { None = 0, Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4}
    #region Public variables

    public float ShipHealth = 0.1f;

    public float MoveSpeed = 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000001f;

    public float damage = 5f;

    public int score = 1;

    #endregion

    #region Private variables

    private Rigidbody2D rigidBody;

    private Transform target;

    #endregion

    #region Implementation of IPart

    

    #endregion

    #region Unity Methods

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;        
    }
    private void Update()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y), new Vector3(target.position.x, target.position.y)) < 5f) { transform.position = Vector3.Lerp(transform.position, target.position, Time.time * 0.0001f); }
        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y), new Vector3(target.position.x, target.position.y)) < 2f) { StartCoroutine(AttackDelay()); }
        if (ShipHealth <= 0) { GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().score += score; Destroy(gameObject); }
    }

    IEnumerator AttackDelay()
    {
        yield return new WaitForSeconds(1f);
        target.GetComponent<ShipController>().GetDamage(damage);

    }
}
    #endregion

