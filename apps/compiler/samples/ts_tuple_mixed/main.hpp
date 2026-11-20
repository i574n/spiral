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
struct Tuple0;
Tuple0 method_0(float v0);
int method_1(bool v0, float v1, int v2);
int main();
struct Tuple0 {
    float v1;
    int v2;
    bool v0;
    __host__ __device__ Tuple0() = default;
    __host__ __device__ Tuple0(bool t0, float t1, int t2) : v0(t0), v1(t1), v2(t2) {}
};
#endif
