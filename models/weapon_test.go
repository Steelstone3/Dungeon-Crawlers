package models

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func CreateWeapon(t *testing.T) {
	// Given
	expectedWeapon := Weapon{
		MaximumDamage: 10,
		MinimumDamage: 5,
	}

	// When
	weapon := createWeapon(5, 10)

	// Then
	assert.Equal(t, expectedWeapon, weapon);
}