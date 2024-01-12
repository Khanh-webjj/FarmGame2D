using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] float spawnArea_height = 5f;
    [SerializeField] float spawnArea_width = 5f;
    [SerializeField] GameObject[] spawn;
	int length;
	[SerializeField] float probability = 0.1f;
	[SerializeField] int spawnCount = 1;
	[SerializeField] bool oneTime = false;

	List<SpawnerObject> spawnerObjects;
	[SerializeField] JSonStringList targetSaveJSONList;
	[SerializeField] int idInlist = -1;
	[SerializeField] int objectSpawnLimit =-1;

	private void Start()
	{
		length = spawn.Length;
		if (oneTime == false)
		{
			TimeAgent timeAgent = GetComponent<TimeAgent>();
			timeAgent.onTimeTick += Spawn;
			spawnerObjects = new List<SpawnerObject>();

			LoadData();
		}
		else
		{
			Spawn();
			//Destroy(gameObject);
		}
		
	}

	

	public void SpawnedObjectDesTroyed(SpawnerObject spawnerObject)
	{
		spawnerObjects.Remove(spawnerObject);
	}

	void Spawn()
	{
		if (Random.value > probability)
		{
			return;
		}
		if(spawnerObjects != null)
		{
			if (objectSpawnLimit <= spawnerObjects.Count && objectSpawnLimit != -1)
			{
				return;
			}
		}
		
		for (int i = 0; i< spawnCount; i++)
		{
			int id = Random.Range(0, length);
			GameObject go = Instantiate(spawn[i]) ;
			Transform t = go.transform;
			t.SetParent(transform);
			if (oneTime == false)
			{
				
				SpawnerObject spawnerObject = go.AddComponent<SpawnerObject>();
				spawnerObjects.Add(spawnerObject);
				spawnerObject.objId = id;
			}

			Vector3 position = transform.position;
			position.x += UnityEngine.Random.Range(-spawnArea_width, spawnArea_width);
			position.y += UnityEngine.Random.Range(-spawnArea_height, spawnArea_height);

			t.position = position;
		}
		
	}
	public class ToSave
	{
		public List<SpawnerObject.SaveSpawnerObjectData> spawnedObjectDatas;
		public ToSave()
		{
			spawnedObjectDatas = new List<SpawnerObject.SaveSpawnerObjectData>();
		}
	}
	string Read()
	{
		ToSave toSave = new ToSave();
		for(int i = 0;i < spawnerObjects.Count; i++)
		{
			toSave.spawnedObjectDatas.Add(new SpawnerObject.SaveSpawnerObjectData(spawnerObjects[i].objId, spawnerObjects[i].transform.position));
		}
		return JsonUtility.ToJson(toSave);
	}
	public void Load(string json)
	{
		if(json == "" || json =="{}" || json == null)
		{
			return;
		}

		ToSave toLoad = JsonUtility.FromJson<ToSave>(json);

		for (int i =0; i< toLoad.spawnedObjectDatas.Count; i ++)
		{
			SpawnerObject.SaveSpawnerObjectData data = toLoad.spawnedObjectDatas[i];
			GameObject go = Instantiate(spawn[data.objectID]);
			go.transform.position = data.worldPosition;
			go.transform.SetParent(transform);
			SpawnerObject so = go.AddComponent<SpawnerObject>();
			so.objId = data.objectID;
			spawnerObjects.Add(so);
		}
	}
	private void OnDestroy()
	{
		if(oneTime == true)
		{
			return;
		}
		SaveData();
	}

	private void SaveData()
	{
		if (CheckJSON() == false)
		{
			return;
		}
		string jsonString = Read();
		targetSaveJSONList.SetString(jsonString, idInlist);
	}
	private void LoadData()
	{
		if(CheckJSON() == false)
		{
			return;
		}

		Load(targetSaveJSONList.GetString(idInlist));
	}

	private bool CheckJSON()
	{
		if (oneTime == true)
		{
			return false;
		}
		if (targetSaveJSONList == null)
		{
			Debug.LogError("Target json is null");
			return false;
		}
		if (idInlist == -1)
		{
			Debug.LogError("id in list not assigned");
			return false;
		}
		return true;
	}

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, new Vector3(spawnArea_width * 2, spawnArea_height * 2));
	}
}
