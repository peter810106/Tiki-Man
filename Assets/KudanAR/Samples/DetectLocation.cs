using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Kudan.AR.Samples;

public class DetectLocation : MonoBehaviour {
	
	private Vector2 targetCoordinates;
	private Vector2 deviceCoordinates;
	private float distanceFromTarget = 0.004f;//0.00004f
	private float proximity;
	private float sLatitude, sLongitude;

	public float homeLatitude = 34.03221f, homeLongitude = -118.2799f;
	public float dLatitude = 34.03279f, dLongitude = -118.2818f;
	public float torjanLatitude = 34.02038f, torjanLongitude = -118.2852f;
	public float leavyLatitude = 34.02164f, leavyLongitude = -118.2830f;
	private bool detect = false;


	private bool enableByRequest = true;
	public int maxWaitLocationService = 10;
	private int maxWait;
	//public bool ready = false;
	public Text text;
	public SampleApp sa;

	void Start(){
		targetCoordinates = new Vector2 (dLatitude, dLongitude);
		StartCoroutine (getLocation ());
	}

	IEnumerator getLocation(){
		while(true){
			
			detect = false;
			maxWait = maxWaitLocationService;

			LocationService service = Input.location;
			if (!enableByRequest && !service.isEnabledByUser) {
				Debug.Log("Location Services not enabled by user");
				yield break;
			}
			service.Start();
			while (service.status == LocationServiceStatus.Initializing && maxWait > 0) {
				yield return new WaitForSeconds(1);
				maxWait--;
			}
			if (maxWait < 1){
				Debug.Log("Timed out");
				yield break;
			}
			if (service.status == LocationServiceStatus.Failed) {
				Debug.Log("Unable to determine device location");
				yield break;
			} else {
				text.text = "Target Location : "+dLatitude + ", "+dLongitude+"\nMy Location: " + service.lastData.latitude + ", " + service.lastData.longitude;
				sLatitude = service.lastData.latitude;
				sLongitude = service.lastData.longitude;
			}
			//service.Stop();
			//ready = true;
			startCalculate ();
			yield return new WaitForSeconds(5);

		}
	}


	void Update(){

	}


	public void startCalculate(){

		deviceCoordinates = new Vector2 (sLatitude, sLongitude);
		proximity = Vector2.Distance (targetCoordinates, deviceCoordinates);

		if(proximity <= distanceFromTarget){
			detect = true;
		}

		targetCoordinates = new Vector2 (homeLatitude, homeLongitude);
		proximity = Vector2.Distance (targetCoordinates, deviceCoordinates);

		if(!detect && proximity <= distanceFromTarget){
			detect = true;
			dLatitude = targetCoordinates[0];
			dLongitude = targetCoordinates[1];
		}
			
		targetCoordinates = new Vector2 (torjanLatitude, torjanLongitude);
		proximity = Vector2.Distance (targetCoordinates, deviceCoordinates);

		if(!detect && proximity <= distanceFromTarget){
			detect = true;
			dLatitude = targetCoordinates[0];
			dLongitude = targetCoordinates[1];
		}

		targetCoordinates = new Vector2 (leavyLatitude, leavyLongitude);
		proximity = Vector2.Distance (targetCoordinates, deviceCoordinates);

		if(!detect && proximity <= distanceFromTarget){
			detect = true;
			dLatitude = targetCoordinates[0];
			dLongitude = targetCoordinates[1];
		}

		if (detect) {
			text.text = text.text + "\nDistance : " + proximity.ToString ();
			text.text += "\nTarget Detected";
			sa.StartClicked ();
		} else {
			text.text = text.text + "\nDistance : " + proximity.ToString ();
			text.text += "\nTarget not detected, too far!";
			sa.stopArbiTrack();
		}


		/*if (proximity <= distanceFromTarget) {
			text.text = text.text + "\nDistance : " + proximity.ToString ();
			text.text += "\nTarget Detected";
			sa.StartClicked ();
		} else {
			text.text = text.text + "\nDistance : " + proximity.ToString ();
			text.text += "\nTarget not detected, too far!";
			sa.stopArbiTrack();
		}*/
	}
}
