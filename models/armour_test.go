package models

import (
	"github.com/stretchr/testify/assert"
	"testing"
)

func TestHelperFunction(t *testing.T) {
	// Given
	expectedArmour := Armour{
		MaximumArmour: 100,
		Armour:        100,
	}

	// When
	armour := createArmour(100, 100)

	// Then
	assert.Equal(t, expectedArmour, armour);
}