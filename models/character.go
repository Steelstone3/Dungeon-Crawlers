type Character struct {
	Name string
	Class string
	Weapon Weapon
	Armour Armour
}

func createCharacter(name string, class string) Character {
	return Character {
		Name: name,
		Class: class,
	}
}