package models

type Weapon struct {
	MaximumDamage uint32
	MinimumDamage uint32
}

func createWeapon(minimumDamage uint32, maximumDamage uint32) Weapon {
	return Weapon{
		MaximumDamage: maximumDamage,
		MinimumDamage: minimumDamage,
	}
}
