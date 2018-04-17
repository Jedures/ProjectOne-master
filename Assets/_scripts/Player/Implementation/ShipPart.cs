using UnityEngine;
using System.Collections.Generic;

public class ShipPart : MonoBehaviour, IPart
{
    #region Public Variables

    public float Health = 100;

    [Space(10)]
    [Header("DamageRange")]
    public float MinDamage = 5;
    public float MaxDamage = 20;

    #endregion

    #region Private Variables

    private List<ICanon> CanonList = new List<ICanon>();

    #endregion

    #region Unity Methods

    private void Start()
    {
        var canons = GetComponentsInChildren<Canon>();

        for (int i = 0; i < canons.Length; i++)
            CanonList.Add(canons[i]);
    }

    private void Update()
    {
        if (Health <= 0)
            Death();
    }

    #endregion

    #region Implementation of IPart

    public List<ICanon> GetCanonList()
    {
        return CanonList;
    }

    public void Shot()
    {
        if (CanonList.Count <= 0)
            return;

        foreach (var canon in CanonList)
        {
            canon.SendShot(Random.Range(MinDamage, MaxDamage));
        }
    }

    #endregion

    #region Public Methods

    public void GetShot(float damage)
    {
        Health -= damage;

        // play all animation and auido
    }

    #endregion

    #region Private Methods

    private void Death()
    {
        // do death this part
    }

    #endregion
}
