// Fill out your copyright notice in the Description page of Project Settings.

#pragma once

#include "CoreMinimal.h"
#include "Kismet/BlueprintFunctionLibrary.h"
#include "PSOTrackingBPLibrary.generated.h"

/**
 * 
 */
UCLASS()
class ANIMALVIOLENCE_API UPSOTrackingBPLibrary : public UBlueprintFunctionLibrary
{
	GENERATED_BODY()
	
public:
    // Raw number Epic points to for loading screen gating.
    UFUNCTION(BlueprintCallable, Category = "PSO Tracking")
    static int32 GetPSOPrecompilesRemaining();

    // Helper: capture a good "starting total" (handles 0 safely).
    UFUNCTION(BlueprintCallable, Category = "PSO Tracking")
    static int32 GetSafePSOInitialTotal(int32 MinimumTotal = 1);
};
