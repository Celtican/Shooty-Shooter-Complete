using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class WinTracker : MonoBehaviour
{
	public UnityEvent onWin;

	private bool won = false;
	private List<HealthPool> enemyHealthPools;

	private void Start() {
		enemyHealthPools = new List<HealthPool>();
		foreach (EnemyController enemy in FindObjectsOfType<EnemyController>()) {
			HealthPool healthPool = enemy.GetComponent<HealthPool>();
			enemyHealthPools.Add(healthPool);
			healthPool.onDie.AddListener(() => enemyHealthPools.Remove(healthPool));
		}

		onWin.AddListener(() => GetComponent<Animator>().SetBool("Won", true));
	}

	public void ResetScene() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void Update() {
		if (!won && enemyHealthPools.Count == 0) {
			onWin.Invoke();
			won = true;
		}
	}
}
