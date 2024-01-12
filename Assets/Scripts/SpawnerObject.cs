using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerObject : MonoBehaviour
{
    [SerializeField]
    public class SaveSpawnerObjectData
	{
		public int objectID;
		public Vector3 worldPosition;

		public SaveSpawnerObjectData(int id, Vector3 worldPosition)
		{
			this.objectID = id;
			this.worldPosition = worldPosition;
		}
	}

	public int objId;

	public void SpawnedObjectDestroyed()
	{
		transform.parent.GetComponent<ObjectSpawner>().SpawnedObjectDesTroyed(this);
	}
}
