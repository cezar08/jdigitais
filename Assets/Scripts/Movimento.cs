using UnityEngine;
using System.Collections;

public class Movimento : MonoBehaviour {
	private float velocidadeMov;
	private float velocidadeRotacao;

	private double fatorp = 0.5;
	private double fatorn = -0.5;
	
	void Start () {		
		velocidadeMov = 0.5f;
		velocidadeRotacao = 100f;
	}
	
	void Update () {		
			//Debug.Log(Input.GetAxis("6-axis"));
			if (Input.GetAxis("X-axis")>fatorn) {

				transform.Translate(velocidadeMov,0, 0);			
				//transform.Rotate(0,15*Time.deltaTime,0);
			}
			if (Input.GetAxis("X-axis")<fatorp) {
				transform.Translate (-velocidadeMov,0, 0);			
				//transform.Rotate(0,15*Time.deltaTime,0);
			}
			if (Input.GetAxis("Y-axis")>fatorn) {			
				transform.Translate (0, 0, -velocidadeMov);
				//transform.Rotate(0,15*Time.deltaTime,0);
			}
			if (Input.GetAxis("Y-axis")<fatorp) {
				transform.Translate (0, 0, velocidadeMov);
				//Debug.Log("b4");
				//transform.Rotate(0,15*Time.deltaTime,0);
			}
			//rotaçao do personagem
			if (Input.GetAxis("3-axis")>fatorp) {
				transform.Rotate (0, velocidadeRotacao*Time.deltaTime, 0);
			}
			if (Input.GetAxis("3-axis")<fatorn) {
				transform.Rotate (0, -velocidadeRotacao*Time.deltaTime, 0);
			}
			if (Input.GetAxis("6-axis")<fatorp) {
				transform.Rotate (0, velocidadeRotacao*Time.deltaTime, 0);
			}
			if (Input.GetAxis("6-axis")>fatorn) {
				transform.Rotate (0, -velocidadeRotacao*Time.deltaTime, 0);
			}		
		}
}
