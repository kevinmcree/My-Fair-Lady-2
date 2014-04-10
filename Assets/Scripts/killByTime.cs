using UnityEngine;
using System.Collections;

public class killByTime : MonoBehaviour {
		public float lifetime;
		
		void Start ()
		{
			Destroy (gameObject, lifetime);
		}
	}