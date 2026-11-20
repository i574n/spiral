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
int main();
struct Union0_First { // First
};
struct Union0_Second { // Second
};
struct Union0 {
    union {
        Union0_First case1; // First
        Union0_Second case2; // Second
    };
    unsigned char tag{255};
    __host__ __device__ Union0() {}
    __host__ __device__ Union0(Union0_First t) : tag(1), case1(t) {} // First
    __host__ __device__ Union0(Union0_Second t) : tag(2), case2(t) {} // Second
    __host__ __device__ Union0(const Union0 & x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union0_First(x.case1); break; // First
            case 2: new (&this->case2) Union0_Second(x.case2); break; // Second
        }
    }
    __host__ __device__ Union0(const Union0 && x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union0_First(std::move(x.case1)); break; // First
            case 2: new (&this->case2) Union0_Second(std::move(x.case2)); break; // Second
        }
    }
    __host__ __device__ Union0 & operator=(const Union0 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = x.case1; break; // First
                case 2: this->case2 = x.case2; break; // Second
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
                case 1: this->case1 = std::move(x.case1); break; // First
                case 2: this->case2 = std::move(x.case2); break; // Second
            }
        } else {
            this->~Union0();
            new (this) Union0{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union0() {
        switch(this->tag){
            case 1: this->case1.~Union0_First(); break; // First
            case 2: this->case2.~Union0_Second(); break; // Second
        }
        this->tag = 255;
    }
};
#endif
