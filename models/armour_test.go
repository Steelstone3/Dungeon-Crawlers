package models

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func CreateArmour(t *testing.T) {
	// Given
	const maximumArmour = 100
	const armour = 100
	expectedArmour := Armour{
		MaximumArmour: maximumArmour,
		Armour:        armour,
	}

	// When
	actualArmour := createArmour(maximumArmour, 100)

	// Then
	assert.Equal(t, expectedArmour, actualArmour);
}