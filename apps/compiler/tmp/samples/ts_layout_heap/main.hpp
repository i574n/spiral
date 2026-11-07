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
struct Heap0;
int main();
struct Heap0 {
    int refc{0};
    int v0;
    int v1;
    __host__ __device__ Heap0() = default;
    __host__ __device__ Heap0(int t0, int t1) : v0(t0), v1(t1) {}
};
#endif
