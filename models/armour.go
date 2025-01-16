package models

type Armour struct {
	MaximumArmour uint32
	Armour        uint32
}

func createArmour(maximumArmour uint32, armour uint32) Armour {
	return Armour{
		MaximumArmour: maximumArmour,
		Armour:        armour,
	}
}
