#pragma once
#include "main.corelib.hpp"
#ifdef __CUDACC__
#ifdef __CUDA_ARCH__
// Cuda device backend
#else
// Cuda host backend
#endif
#else
// Cpp host backend
int count_down_0(int v0, int v1);
int main();
#endif
