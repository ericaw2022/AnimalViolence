// Fill out your copyright notice in the Description page of Project Settings.


#include "PSOTrackingBPLibrary.h"
#include "ShaderPipelineCache.h"

int32 UPSOTrackingBPLibrary::GetPSOPrecompilesRemaining()
{
    return (int32)FShaderPipelineCache::NumPrecompilesRemaining();
}

int32 UPSOTrackingBPLibrary::GetSafePSOInitialTotal(int32 MinimumTotal)
{
    const int32 Total = (int32)FShaderPipelineCache::NumPrecompilesRemaining();
    return (Total < MinimumTotal) ? MinimumTotal : Total;
}
