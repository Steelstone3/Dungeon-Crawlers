package models

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func CreateCharacter(t *testing.T) {
	// Given
	const name = "Jeff"
	const class = "Mage"
	const maximumDamage = 10
	const minimumDamage = 5
	const maximumArmour = 100
	const armour = 100
	expectedCharacter := Character{
		Name:  name,
		Class: class,
		Weapon: Weapon{
			MaximumDamage: maximumDamage,
			MinimumDamage: minimumDamage,
		},
		Armour: Armour{
			MaximumArmour: maximumArmour,
			Armour:        armour,
		},
	}

	// When
	actualCharacter := createCharacter(name, class)

	// Then
	assert.Equal(t, expectedCharacter, actualCharacter)
}
