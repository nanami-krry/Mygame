using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Removers : MonoBehaviour
{
	public GameObject splash;


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if (col.gameObject.tag == "Player")
		{
			GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			if (GameObject.Find("UI_HealthBar").activeSelf)
			{
				GameObject.Find("UI_HealthBar").SetActive(false);
			}
			Instantiate(splash, col.transform.position, transform.rotation);
			
			Destroy(col.gameObject);
			
			StartCoroutine("ReloadGame");
		}
		else
		{
			
			Instantiate(splash, col.transform.position, transform.rotation);

			
			Destroy(col.gameObject);
		}
	}

	IEnumerator ReloadGame()
	{
		
		yield return new WaitForSeconds(2);
	
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
	}
}
