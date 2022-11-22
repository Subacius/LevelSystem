using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InToPlayerCM : MonoBehaviour
{

    public static InToPlayerCM CreateInToPlayer(Vector3 position) {
        Transform pfRutulysInToPlater = Resources.Load<Transform>("pfRutulysInToPlayer");
        Transform enemyTransform = Instantiate(pfRutulysInToPlater, position, Quaternion.identity);

        InToPlayerCM intoPlayerCM = enemyTransform.GetComponent<InToPlayerCM>();
        return intoPlayerCM;
    }

    public static InToPlayerCM CreateInToPlayer2(Vector3 position) {
        Transform pfRutulysInToPlater = Resources.Load<Transform>("pfRutulysInToPlayer2");
        Transform enemyTransform = Instantiate(pfRutulysInToPlater, position, Quaternion.identity);

        InToPlayerCM intoPlayerCM = enemyTransform.GetComponent<InToPlayerCM>();
        return intoPlayerCM;
    }
    private Transform targetTransformInToPlayer;

    private Transform targetTransformInToPlayer2;
    private Rigidbody2D rigidbody2d;

    private float lookForTargetTimer;
    private float lookForTargetTimerMax = 0.2f;

    private GameObject pfPlayer;
    private GameObject pfPlayerSecond;

    [SerializeField] private EnemyTypeSO enemy1;
   
   

    private void Start() {
        rigidbody2d = GetComponent<Rigidbody2D>();
        lookForTargetTimer = Random.Range(0f, lookForTargetTimerMax);

        if(targetTransformInToPlayer != null) {
        pfPlayer = GameObject.Find("pfPlayer(Clone)");

        targetTransformInToPlayer = pfPlayer.transform;
        }

        if(targetTransformInToPlayer != null) {
        pfPlayerSecond = GameObject.Find("pfPlayer2(Clone)");

        targetTransformInToPlayer2 = pfPlayerSecond.transform;
        }
    }

    private void Update() {
        if(targetTransformInToPlayer != null) {
            Vector3 moveDir = (targetTransformInToPlayer.position - transform.position).normalized;

            float moveSpeed = 10f;
            rigidbody2d.velocity = moveDir * moveSpeed;
        } else {
            rigidbody2d.velocity = Vector2.zero;
        }

        if(targetTransformInToPlayer2 != null) {
            Vector3 moveDir2 = (targetTransformInToPlayer2.position - transform.position).normalized;

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
        // Debug.Log("collisionOnPlayer");
        Player player = collider.gameObject.GetComponent<Player>();
        if(player != null) {
            HealthSystemPlayer healthSystem = player.GetComponent<HealthSystemPlayer>();
            
            healthSystem.Damage(enemy1.hitMax);

            Destroy(gameObject);
        }
    }

    private void LookForTargets() {
        float targetMaxRadius = 25f;
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray) {
            Player player = collider2D.GetComponent<Player>();
            if (player != null) {
                if (targetTransformInToPlayer == null) {
                    targetTransformInToPlayer = player.transform;
                } else {
                    if(Vector3.Distance(transform.position, player.transform.position) < Vector3.Distance(transform.position, targetTransformInToPlayer.position)) {
                        targetTransformInToPlayer = player.transform;
                    }
                }
            }
        }
        if (targetTransformInToPlayer == null) {
            Destroy(gameObject);
        }

    }

    private void LookForTargets2() {
        float targetMaxRadius = 25f;
        Collider2D[] collider2DArray2 = Physics2D.OverlapCircleAll(transform.position, targetMaxRadius);

        foreach (Collider2D collider2D in collider2DArray2) {
            Player player = collider2D.GetComponent<Player>();
            if (player != null) {
                if (targetTransformInToPlayer2 == null) {
                    targetTransformInToPlayer2 = player.transform;
                } else {
                    if(Vector3.Distance(transform.position, player.transform.position) < Vector3.Distance(transform.position, targetTransformInToPlayer2.position)) {
                        targetTransformInToPlayer2 = player.transform;
                    }
                }
            }
        }
        if (targetTransformInToPlayer2 == null) {
            Destroy(gameObject);
        }

    }
}
