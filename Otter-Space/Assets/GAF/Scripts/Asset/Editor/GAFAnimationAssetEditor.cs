/*
 * File:			GAFAnimationAssetEditor.cs
 * Version:			2.0
 * Last changed:	2015/2/2 14:34
 * Author:			Niktin.Nikolay
 * Copyright:		© GAFMedia
 * Project:			GAF Unity plugin
 */

using UnityEditor;

using GAF.Assets;
using GAF.Core;

using GAFEditorInternal.Assets;
using UnityEngine;

using System.Linq;

#if UNITY_5
using UnityEditor.Animations;
#else
using UnityEditorInternal;
#endif

namespace GAFEditor.Assets
{
	[CanEditMultipleObjects]
	[CustomEditor(typeof(GAFAnimationAsset))]
	public class GAFAnimationAssetEditor : GAFAnimationAssetInternalEditor<GAFTexturesResource>
	{
		#region Implementation

		protected override void drawCreationMenu(int _TimelineID, ClipCreationOptions _Option)
		{
			switch(_Option)
			{
				case ClipCreationOptions.NotBakedMovieClip:
					drawCreateClip<GAFMovieClip>(_TimelineID, false, false);
					break;

				case ClipCreationOptions.BakedMovieClip:
					drawCreateClip<GAFBakedMovieClip>(_TimelineID, true, false);
					break;
			}
		}
		#endregion // Implementation
	}
}