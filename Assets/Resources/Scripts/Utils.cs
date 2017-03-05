using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils
{

	public static T loadResource<T> (string path) where T : Object
	{
		T resource =  Resources.Load (path, typeof(T)) as T;
		if (null == resource) {
			Debug.LogErrorFormat ("Could not find {0} at {1}", typeof(T), path);
		}
		return resource;
	}
}
