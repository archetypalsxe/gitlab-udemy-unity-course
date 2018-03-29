using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser : Projectile {

	protected override void checkDefaults() {
		if(this.projectileSpeed <= 0) {
			this.projectileSpeed = -8;
		}
		if(this.damage <= 0) {
			this.damage = 100f;
		}
	}
}
