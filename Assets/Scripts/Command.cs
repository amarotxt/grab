using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command {

	public virtual void Move (Transform player){ }
	public virtual void Jump (Rigidbody player){ }
//	public virtual void Hook(){ }
}
