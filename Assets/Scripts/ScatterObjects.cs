using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatterObjects : MonoBehaviour
{
	public GameObject[] prefabs;                 // Array of prefabs to scatter
	public GameObject targetObject;              // The object to scatter prefabs onto
	public int numberOfInstances;                // Number of prefab instances to scatter
	public Vector2 rotationRange;                // Range for random rotation
	public Vector3 scatterAreaSize = new Vector3(20, 20, 20); // Size of scatter area

	public Vector2 scaleRange = new Vector2(0.5f, 2.0f); // Range for random scaling

	void Start()
	{
		Scatter();
	}

	void Scatter()
	{
		for (int i = 0; i < numberOfInstances; i++)
		{
			GameObject prefab = prefabs[Random.Range(0, prefabs.Length)];
			Vector3 randomPosition = new Vector3(
				Random.Range(-scatterAreaSize.x / 2, scatterAreaSize.x / 2),
				Random.Range(-scatterAreaSize.y / 2, scatterAreaSize.y / 2),
				Random.Range(-scatterAreaSize.z / 2, scatterAreaSize.z / 2)
			);
			Vector3 worldPosition = targetObject.transform.TransformPoint(randomPosition);

			Quaternion randomRotation = Quaternion.Euler(
				Random.Range(-rotationRange.x, rotationRange.x),
				Random.Range(-rotationRange.y, rotationRange.y),
				0
			);

			GameObject instance = Instantiate(prefab, worldPosition, randomRotation);
			instance.transform.SetParent(targetObject.transform);

			// Random scale
			float randomScale = Random.Range(scaleRange.x, scaleRange.y);
			instance.transform.localScale = new Vector3(randomScale, randomScale, randomScale);
		}
	}
}
