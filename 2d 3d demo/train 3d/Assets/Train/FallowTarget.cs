using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Notes

// a variavel delayToStart é para quer WaypointProgressTracker ache a posicao mas perto do train como dar para ver pelos gizmos,
// sem isso os vagoes podem se desaliarem e se voce for adpitar esse system para o seu jogo talvez voce deva ajustar as variaves do WaypointProgressTracker
// elas definem com perfeita elas vai serguir a spline e se estiver comfigurada para não ter nenhu offset os vegoes vai se desaliar

//O script WaypointCircuit ta dando algums erros no meu projeto, não deve ser nada de mais ja que não esta atrapalhando o funcionamento,
//talves seja porque o script e do stand asset do unity 2017, talves do do stand asset do 2018 seja diferente

//By google translate

// the variable delay To Start is to either Waypoint Progress Tracker find the position but near the train as to give to see by the gizmos,
// without this the cars can be discouraged and if you go to this system for your game you may have to adjust the waypoints of the WaypointProgressTracker
// they define with perfect they will follow the spline and if it is configured to not have any offset the vegoes will desaliar

// The Waypoint Circuit script is giving some errors in my project, should not be anything more that is not disrupting the operation,
// maybe it's because the script and the stand-alone asset of unity 2017, maybe the 2018 stand asset is different
public class FallowTarget : MonoBehaviour {

	public Transform target;
	public float Speed = 5;
	public float delayToStart = 2;

	bool start;

	void Start(){
		if(delayToStart > 0){
			start = false;
			StartCoroutine(startFallow());
		}else{
			start = true;
		}

	}

	IEnumerator startFallow() {
	     yield return new WaitForSeconds(delayToStart);
	     start = true;
	}

	void Update () {
		if(start == false)
			return;


		if (target != null) {

			Vector3 dir = (target.position - transform.position).normalized * (Speed * Time.deltaTime);
			transform.position += dir;
			
			if(dir == Vector3.zero)
				dir = transform.forward;
				
			transform.rotation = Quaternion.LookRotation (dir);
			
		}
	}
}
