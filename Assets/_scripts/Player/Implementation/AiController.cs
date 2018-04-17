using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour, IShip
{
    public enum Type { None = 0, Type1 = 1, Type2 = 2, Type3 = 3, Type4 = 4}
    #region Public variables

    public float ShipHealth = 0.1f;

    public float MoveSpeed = 0.00000000000000000000000000000000000000000000000000000000000000000000000000000000001f;

    public float damage = 5f;

    public int score = 1;

    public float rezardTime = 2f;
    public bool isRezardNow = false;

    #endregion

    #region Private variables

    private Rigidbody2D rigidBody;

    private Transform target;

    #endregion

    #region Implementation of IShip

    private List<IPart> PartList = new List<IPart>();

    public List<IPart> GetPartList()
    {
        return PartList;
    }

    #endregion

    #region Unity Methods

    private void Start()
    {
        var parts = GetComponentsInChildren<ShipPart>();

        for (int i = 0; i < parts.Length; i++)
            PartList.Add(parts[i]);
        
        target = GameObject.FindGameObjectWithTag("Player").transform;        
    }
    private void Update()
    {
        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y), new Vector3(target.position.x, target.position.y)) > 2f) { transform.position = Vector3.Lerp(transform.position, target.position, Time.time * 0.0001f); }

        if (Vector3.Distance(new Vector3(transform.position.x, transform.position.y), new Vector3(target.position.x, target.position.y)) < 2.1f)
        {
            if (isRezardNow)
                return;
            else
                Attack();
        }

        if (ShipHealth <= 0) { GameObject.FindGameObjectWithTag("Player").GetComponent<ShipController>().score += score; Destroy(gameObject); }

        //transform.LookAt(target);
    }

    private void Attack()
    {
        if (!isRezardNow)
        {
            target.GetComponent<ShipController>().GetDamage(damage);
            isRezardNow = true;
            StartCoroutine(Rezard());
        }

        //foreach(var part in PartList)
        //{
        //    part.Shot(); тут надо было вот так делать и на пушке писать логику поведения каждому оружию своё но увы раз так то так...
        //}
    }

    IEnumerator Rezard()
    {
        yield return new WaitForSeconds(rezardTime);
        isRezardNow = false;
    }
}
    #endregion

