using UnityEngine;
using System.Collections;

public class HpScript : MonoBehaviour {
	
	public float hp;
	
	public void SetHp(float setHp){
		hp = setHp;
	}
	
	public void ReceiveDamage(float damage) {
		hp -= damage;
		if (hp <= 0) {
			gameObject.GetComponent<SampleAnimal>().Kill();		
		}

	}
}
