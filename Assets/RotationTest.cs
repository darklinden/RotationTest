using UnityEngine;
using System.Collections;

public class RotationTest : MonoBehaviour {

	public float QuaternionX, QuaternionY, QuaternionZ, QuaternionW;
	private string animationKey = "animationKey";
	private float rx = 0, ry = 0, rz = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (animation.GetClip (animationKey)) {
			if (!animation.IsPlaying (animationKey)) {
				animation.RemoveClip (animationKey);
			}
		}

		if (rx > 0) {
			rx--;
			transform.Rotate(1, 0, 0, Space.World);
		}
		else {
			rx = 0;
		}

		if (ry > 0) {
			ry--;
			transform.Rotate(0, 1, 0, Space.World);
		}
		else {
			ry = 0;
		}

		if (rz > 0) {
			rz--;
			transform.Rotate(0, 0, 1, Space.World);
		}
		else {
			rz = 0;
		}

		QuaternionX = transform.localRotation.x;
		QuaternionY = transform.localRotation.y;
		QuaternionZ = transform.localRotation.z;
		QuaternionW = transform.localRotation.w;
	}

	void OnGUI () {
		if (GUI.Button (new Rect (10, 10, 100, 30), "Reset")) {
			AnimationClip clip = new AnimationClip();
			clip.name = animationKey;

			Quaternion nr = Quaternion.identity;
			clip.SetCurve("", typeof(Transform), "localRotation.x", AnimationCurve.Linear(0f, transform.localRotation.x, 2f, nr.x));
			clip.SetCurve("", typeof(Transform), "localRotation.y", AnimationCurve.Linear(0f, transform.localRotation.y, 2f, nr.y));
			clip.SetCurve("", typeof(Transform), "localRotation.z", AnimationCurve.Linear(0f, transform.localRotation.z, 2f, nr.z));
			clip.SetCurve("", typeof(Transform), "localRotation.w", AnimationCurve.Linear(0f, transform.localRotation.w, 2f, nr.w));
			animation.AddClip(clip, animationKey);
			animation.Play(animationKey);
		}

		if (GUI.Button (new Rect (10, 110, 100, 30), "Rotate X")) {
			if (rx == 0) rx = 90;
		}

		if (GUI.Button (new Rect (10, 210, 100, 30), "Rotate Y")) {
			if (ry == 0) ry = 90;
		}

		if (GUI.Button (new Rect (10, 310, 100, 30), "Rotate Z")) {
			if (rz == 0) rz = 90;
		}
	}
}
