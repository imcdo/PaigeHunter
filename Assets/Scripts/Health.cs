using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
   public static implicit operator float(Health h) => h.Value;
   public static explicit operator Health(float v) => new Health{Value = v}; // AVOID USE AT ALL COSTS X(
   
   [SerializeField] private float _initHealth = 10;
   private float _health;

   public float Value
   {
      get { return _health; }
      set
      {
         _health = value;
         HealthListener();
      }
   }

   public Action HealthListener = () => { };

   void Awake()
   {
      _health = _initHealth;
   }
}
