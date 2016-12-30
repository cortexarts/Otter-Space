/*/
* Script by Devin Curry
* http://Devination.com
* https://youtube.com/user/curryboy001
* Please like and subscribe if you found my tutorials helpful :D
* Twitter: https://twitter.com/Devination3D
/*/
using UnityEngine;
using System.Collections;

public static class ExtensionMethods {
	public static Vector2 toVector2(this Vector3 vec3) {
		return new Vector2(vec3.x, vec3.y);
	}
}