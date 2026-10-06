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
struct Union0;
int score_0(Union0 v0);
int main();
struct Union0_0 { // Hit
    int v0;
    __host__ __device__ Union0_0(int t0) : v0(t0) {}
    __host__ __device__ Union0_0() = delete;
};
struct Union0_1 { // Miss
    int v0;
    __host__ __device__ Union0_1(int t0) : v0(t0) {}
    __host__ __device__ Union0_1() = delete;
};
struct Union0 {
    union {
        Union0_0 case0; // Hit
        Union0_1 case1; // Miss
    };
    unsigned char tag{255};
    __host__ __device__ Union0() {}
    __host__ __device__ Union0(Union0_0 t) : tag(0), case0(t) {} // Hit
    __host__ __device__ Union0(Union0_1 t) : tag(1), case1(t) {} // Miss
    __host__ __device__ Union0(const Union0 & x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union0_0(x.case0); break; // Hit
            case 1: new (&this->case1) Union0_1(x.case1); break; // Miss
        }
    }
    __host__ __device__ Union0(const Union0 && x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union0_0(std::move(x.case0)); break; // Hit
            case 1: new (&this->case1) Union0_1(std::move(x.case1)); break; // Miss
        }
    }
    __host__ __device__ Union0 & operator=(const Union0 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = x.case0; break; // Hit
                case 1: this->case1 = x.case1; break; // Miss
            }
        } else {
            this->~Union0();
            new (this) Union0{x};
        }
        return *this;
    }
    __host__ __device__ Union0 & operator=(const Union0 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = std::move(x.case0); break; // Hit
                case 1: this->case1 = std::move(x.case1); break; // Miss
            }
        } else {
            this->~Union0();
            new (this) Union0{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union0() {
        switch(this->tag){
            case 0: this->case0.~Union0_0(); break; // Hit
            case 1: this->case1.~Union0_1(); break; // Miss
        }
        this->tag = 255;
    }
};
#endif
