using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random=UnityEngine.Random;

public class InToEnemyCM : MonoBehaviour
{

    public static InToEnemyCM Create(Vector3 position) {
        Transform pfRutulys = Resources.Load<Transform>("pfRutulysInToEnemy");
        Transform enemyTransform = Instantiate(pfRutulys, position, Quaternion.identity);

        InToEnemyCM enemyCM = enemyTransform.GetComponent<InToEnemyCM>();
        return enemyCM;
    }

    public static InToEnemyCM Create2(Vector3 position) {
        Transform pfRutulys = Resources.Load<Transform>("pfRutulysInToEnemy2");
        Transform enemyTransform = Instantiate(pfRutulys, position, Quaternion.identity);
        InToEnemyCM enemyCM = enemyTransform.GetComponent<InToEnemyCM>();
        return enemyCM;
    }
    private Transform targetTransform;
    private Transform targetTransform2;
    private Rigidbody2D rigidbody2d;

    private float lookForTargetTimer;
    private float lookForTargetTimerMax = 0.2f;

    private GameObject pfEnemy;
    private GameObject pfEnemy2;
    [SerializeField] private PlayerTypeSO player1;

    public event EventHandler OnExperienceChangedInToEnemy;

    // public event EventHandler OnExperienceChangedNaujas;

    private void Start() {

        // weaponPlayer.OnExperienceChangedNaujas += WeaponPlayer_OnExpierenceChangedNaujas;


        rigidbody2d = GetComponent<Rigidbody2D>();
        lookForTargetTimer = Random.Range(0f, lookForTargetTimerMax);

        if(targetTransform != null) {
            pfEnemy = GameObject.Find("pfEnemy(Clone)");

            targetTransform = pfEnemy.transform;
        } 
        // else {
        //     pfEnemy2 = GameObject.Find("pfEnemy2(Clone)");

        //     targetTransform2 = pfEnemy2.transform;
        // }
        if(targetTransform2 != null) {
            pfEnemy2 = GameObject.Find("pfEnemy2(Clone)");

            targetTransform2 = pfEnemy2.transform;
        } 







        // playerTypeHolder = GetComponent<PlayerTypeHolder>();

    }



    private void Update() {
        if((targetTransform != null)) {
            Vector3 moveDir = (targetTransform.position - transform.position).normalized;
            
            float moveSpeed = 10f;
            rigidbody2d.velocity = moveDir * moveSpeed;

        } else {

            rigidbody2d.velocity = Vector2.zero;
        }

        if((targetTransform2 != null)) {
            Vector3 moveDir2 = (targetTransform2.position - transform.position).normalized;

            float moveSpeed = 10f;
            rigidbody2d.velocity = moveDir2 * moveSpeed;

        } else {

            rigidbody2d.velocity = Vector2.zero;
        }



        lookForTargetTimer -= Time.deltaTime;
        if(lookForTargetTimer < 0f) {
            lookForTargetTimer += lookForTargetTimerMax;
            LookForTargets();
            LookForTargets2();
        }
      
    }

    private void OnTriggerEnter2D (Collider2D collider){
        // Debug.Log("collisionOnEnemyyyyyy");
        Enemy enemy = collider.gameObject.GetComponent<Enemy>();
        if(enemy != null) {


            HealthSystem healthSystem = enemy.GetComponent<HealthSystem>();
         
            healthSystem.Damage(player1.hitMax);

            OnExperienceChangedInToEnemy?.Invoke(this, EventArgs.Empty);

            // OnExperienceChangedNaujas?.Invoke(this, EventArgs.Empty);



            // OnExperienceChangedNaujas?.Invoke(this, EventArgs.Empty);
            // Debug.Log(playerTypeHolder.playerType.hit);
            Destroy(gameObject);
        }
    }

    private void LookForTargets() {
        float targetMaxRadius = 25f;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray) {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            if (enemy != null) {
                if (targetTransform == null) {
                    targetTransform = enemy.transform;
                } else {
                    if(Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, targetTransform.position)) {
                        targetTransform = enemy.transform;
                    }
                }
            }
        }
        if (targetTransform == null) {
            Destroy(gameObject);
        }

    }

    private void LookForTargets2() {
        float targetMaxRadius = 25f;
        Collider2D[] collider2DArray2 = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray2) {
            Enemy enemy = collider2D.GetComponent<Enemy>();
            if (enemy != null) {
                if (targetTransform2 == null) {
                    targetTransform2 = enemy.transform;
                } else {
                    if(Vector3.Distance(transform.position, enemy.transform.position) < Vector3.Distance(transform.position, targetTransform2.position)) {
                        targetTransform2 = enemy.transform;
                    }
                }
            }
        }
        if (targetTransform2 == null) {
            Destroy(gameObject);
        }

    }



}
