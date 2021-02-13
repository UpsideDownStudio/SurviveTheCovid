using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "ConfigEntity/New Item")]
public class Item : ScriptableObject
{
	new public string name = "New Item";
	public Sprite icon = null;
	public bool isDefaultItem = false;

	public virtual void Use()
	{
		//Использование предмета
		//Здесь прописывается поведения при использовании

		Debug.Log("Using " + name);
	}
}
