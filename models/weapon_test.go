package models

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func CreateWeapon(t *testing.T) {
	// Given
	const maximumDamage = 10
	const minimumDamage = 5
	expectedWeapon := Weapon{
		MaximumDamage: maximumDamage,
		MinimumDamage: minimumDamage,
	}

	// When
	actualWeapon := createWeapon(minimumDamage, maximumDamage)

	// Then
	assert.Equal(t, expectedWeapon, actualWeapon);
}