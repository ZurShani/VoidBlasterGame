using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] GameObject deathFX;
   [SerializeField] GameObject hitVFX;
   [SerializeField] int scorePerHit = 15;
   [SerializeField] int hitPoints = 2;
   
   ScoreBoard scoreBoard;
   GameObject ParentGameObject;

   void Start()
   {
      scoreBoard = FindObjectOfType<ScoreBoard>();
      ParentGameObject = GameObject.FindGameObjectWithTag("SpawnAtRuntime");
      gameObject.AddComponent<Rigidbody>();
      GetComponent<Rigidbody>().useGravity = false;
   }
   void OnParticleCollision(GameObject other)
   {
      ProcessHit();
      if (hitPoints < 1)
      {
         KillEnemy();
      }
   }

   void ProcessHit()
   {
      GameObject vfx = Instantiate(hitVFX, transform.position, Quaternion.identity);
      vfx.transform.parent = ParentGameObject.transform;
      hitPoints--;
   }

   void KillEnemy()
   {
      scoreBoard.IncreaseScore(scorePerHit);
      GameObject fx = Instantiate(deathFX, transform.position, Quaternion.identity);
      fx.transform.parent = ParentGameObject.transform;
      Destroy(gameObject);
   }
}
