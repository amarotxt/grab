using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {
	protected float movimentSpeed = 5;
	protected float movimentScaleSpeed = 2;
	protected float forceJump = 10f;
	protected float forceHighJump = 15f;


	public abstract void Execute (GameObject player);
	public virtual void Move (Transform player){ }
	public virtual void Jump (Rigidbody player){ }

//	public virtual void Hook(){ }
}
public class MoveLeft : Command{
	public override void Execute(GameObject player){
		Move (player.transform);
	}
	public override void Move (Transform player){
		player.transform.Translate (new Vector3(-(Time.deltaTime*movimentSpeed), 0,0));
	}
}
public class MoveRight : Command{
	public override void Execute(GameObject player){
		Move (player.transform);
	}
	public override void Move (Transform player){
		player.transform.Translate (new Vector3(Time.deltaTime*movimentSpeed, 0,0));
	}
}
public class MoveUp : Command{
	public override void Execute(GameObject player){
		Move (player.transform);
	}
	public override void Move (Transform player){
		player.transform.Translate (new Vector3(0,(Time.deltaTime*movimentScaleSpeed),0));
	}
}
public class MoveDown : Command{
	public override void Execute(GameObject player){
		Move (player.transform);
	}
	public override void Move (Transform player){
		player.transform.Translate (new Vector3(0,-(Time.deltaTime*movimentScaleSpeed),0));
	}
}
//public class JumpLeft : Command{
//	public override void Execute(GameObject player){
//		Jump (player.GetComponent<Rigidbody>());
//	}
//	public override void Jump (Rigidbody player){
//		player.AddForce (new Vector3 (-(forceJump),forceJump, 0));
//	}
//}
//public class JumpRight : Command{
//	public override void Execute(GameObject player){
//		Jump (player.GetComponent<Rigidbody>());
//	}
//	public override void Jump (Rigidbody player){
//		player.AddForce (new Vector3 ( forceJump,forceJump, 0));
//	}
//}
public class JumpUp : Command{
	public override void Execute(GameObject player){
		Jump (player.GetComponent<Rigidbody>());
	}
	public override void Jump (Rigidbody player){
		Debug.Log ("Teste1");

		player.AddForce ((Vector3.up*forceJump),ForceMode.Impulse);
	}
}

public class JumpUpHigh : Command{
	public override void Execute(GameObject player){
		Jump (player.GetComponent<Rigidbody>());
	}
	public override void Jump (Rigidbody player){
		Debug.Log ("Teste");
		player.AddForce ((Vector3.up*forceHighJump), ForceMode.Impulse);
	}
}