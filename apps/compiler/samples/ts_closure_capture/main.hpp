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
int main();
struct Closure0 {
    int v0;
    int v1;
    int operator()(int tup0){
        int & v0 = this->v0; int & v1 = this->v1;
        int v2 = tup0;
        int v3;
        v3 = v0 + v1;
        int v4;
        v4 = v3 + v2;
        return v4;
    }
    Closure0(int _v0, int _v1) : v0(_v0), v1(_v1) { }
};
#endif
