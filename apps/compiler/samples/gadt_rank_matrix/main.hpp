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
struct Union1;
struct Union2;
struct Union3;
struct Union4;
struct Union5;
struct Union6;
Union1 decide_a_0(Union0 v0);
Union3 decide_b_1(Union2 v0);
Union5 decide_c_2(Union4 v0);
Union6 finalize_c_3(Union5 v0);
int main();
struct Union0_RawA { // RawA
    int v0;
    __host__ __device__ Union0_RawA(int t0) : v0(t0) {}
    __host__ __device__ Union0_RawA() = delete;
};
struct Union0 {
    union {
        Union0_RawA case0; // RawA
    };
    unsigned char tag{255};
    __host__ __device__ Union0() {}
    __host__ __device__ Union0(Union0_RawA t) : tag(0), case0(t) {} // RawA
    __host__ __device__ Union0(const Union0 & x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union0_RawA(x.case0); break; // RawA
        }
    }
    __host__ __device__ Union0(const Union0 && x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union0_RawA(std::move(x.case0)); break; // RawA
        }
    }
    __host__ __device__ Union0 & operator=(const Union0 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = x.case0; break; // RawA
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
                case 0: this->case0 = std::move(x.case0); break; // RawA
            }
        } else {
            this->~Union0();
            new (this) Union0{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union0() {
        switch(this->tag){
            case 0: this->case0.~Union0_RawA(); break; // RawA
        }
        this->tag = 255;
    }
};
struct Union1_DecidedA { // DecidedA
    int v0;
    bool v1;
    __host__ __device__ Union1_DecidedA(int t0, bool t1) : v0(t0), v1(t1) {}
    __host__ __device__ Union1_DecidedA() = delete;
};
struct Union1 {
    union {
        Union1_DecidedA case1; // DecidedA
    };
    unsigned char tag{255};
    __host__ __device__ Union1() {}
    __host__ __device__ Union1(Union1_DecidedA t) : tag(1), case1(t) {} // DecidedA
    __host__ __device__ Union1(const Union1 & x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union1_DecidedA(x.case1); break; // DecidedA
        }
    }
    __host__ __device__ Union1(const Union1 && x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union1_DecidedA(std::move(x.case1)); break; // DecidedA
        }
    }
    __host__ __device__ Union1 & operator=(const Union1 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = x.case1; break; // DecidedA
            }
        } else {
            this->~Union1();
            new (this) Union1{x};
        }
        return *this;
    }
    __host__ __device__ Union1 & operator=(const Union1 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = std::move(x.case1); break; // DecidedA
            }
        } else {
            this->~Union1();
            new (this) Union1{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union1() {
        switch(this->tag){
            case 1: this->case1.~Union1_DecidedA(); break; // DecidedA
        }
        this->tag = 255;
    }
};
struct Union2_RawB { // RawB
    int v0;
    __host__ __device__ Union2_RawB(int t0) : v0(t0) {}
    __host__ __device__ Union2_RawB() = delete;
};
struct Union2 {
    union {
        Union2_RawB case1; // RawB
    };
    unsigned char tag{255};
    __host__ __device__ Union2() {}
    __host__ __device__ Union2(Union2_RawB t) : tag(1), case1(t) {} // RawB
    __host__ __device__ Union2(const Union2 & x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union2_RawB(x.case1); break; // RawB
        }
    }
    __host__ __device__ Union2(const Union2 && x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union2_RawB(std::move(x.case1)); break; // RawB
        }
    }
    __host__ __device__ Union2 & operator=(const Union2 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = x.case1; break; // RawB
            }
        } else {
            this->~Union2();
            new (this) Union2{x};
        }
        return *this;
    }
    __host__ __device__ Union2 & operator=(const Union2 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = std::move(x.case1); break; // RawB
            }
        } else {
            this->~Union2();
            new (this) Union2{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union2() {
        switch(this->tag){
            case 1: this->case1.~Union2_RawB(); break; // RawB
        }
        this->tag = 255;
    }
};
struct Union3_DecidedB { // DecidedB
    int v1;
    bool v0;
    __host__ __device__ Union3_DecidedB(bool t0, int t1) : v0(t0), v1(t1) {}
    __host__ __device__ Union3_DecidedB() = delete;
};
struct Union3 {
    union {
        Union3_DecidedB case0; // DecidedB
    };
    unsigned char tag{255};
    __host__ __device__ Union3() {}
    __host__ __device__ Union3(Union3_DecidedB t) : tag(0), case0(t) {} // DecidedB
    __host__ __device__ Union3(const Union3 & x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union3_DecidedB(x.case0); break; // DecidedB
        }
    }
    __host__ __device__ Union3(const Union3 && x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union3_DecidedB(std::move(x.case0)); break; // DecidedB
        }
    }
    __host__ __device__ Union3 & operator=(const Union3 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = x.case0; break; // DecidedB
            }
        } else {
            this->~Union3();
            new (this) Union3{x};
        }
        return *this;
    }
    __host__ __device__ Union3 & operator=(const Union3 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = std::move(x.case0); break; // DecidedB
            }
        } else {
            this->~Union3();
            new (this) Union3{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union3() {
        switch(this->tag){
            case 0: this->case0.~Union3_DecidedB(); break; // DecidedB
        }
        this->tag = 255;
    }
};
struct Union4_RawC { // RawC
    int v0;
    __host__ __device__ Union4_RawC(int t0) : v0(t0) {}
    __host__ __device__ Union4_RawC() = delete;
};
struct Union4 {
    union {
        Union4_RawC case0; // RawC
    };
    unsigned char tag{255};
    __host__ __device__ Union4() {}
    __host__ __device__ Union4(Union4_RawC t) : tag(0), case0(t) {} // RawC
    __host__ __device__ Union4(const Union4 & x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union4_RawC(x.case0); break; // RawC
        }
    }
    __host__ __device__ Union4(const Union4 && x) : tag(x.tag) {
        switch(x.tag){
            case 0: new (&this->case0) Union4_RawC(std::move(x.case0)); break; // RawC
        }
    }
    __host__ __device__ Union4 & operator=(const Union4 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = x.case0; break; // RawC
            }
        } else {
            this->~Union4();
            new (this) Union4{x};
        }
        return *this;
    }
    __host__ __device__ Union4 & operator=(const Union4 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 0: this->case0 = std::move(x.case0); break; // RawC
            }
        } else {
            this->~Union4();
            new (this) Union4{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union4() {
        switch(this->tag){
            case 0: this->case0.~Union4_RawC(); break; // RawC
        }
        this->tag = 255;
    }
};
struct Union5_DecidedC { // DecidedC
    int v0;
    bool v1;
    __host__ __device__ Union5_DecidedC(int t0, bool t1) : v0(t0), v1(t1) {}
    __host__ __device__ Union5_DecidedC() = delete;
};
struct Union5 {
    union {
        Union5_DecidedC case1; // DecidedC
    };
    unsigned char tag{255};
    __host__ __device__ Union5() {}
    __host__ __device__ Union5(Union5_DecidedC t) : tag(1), case1(t) {} // DecidedC
    __host__ __device__ Union5(const Union5 & x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union5_DecidedC(x.case1); break; // DecidedC
        }
    }
    __host__ __device__ Union5(const Union5 && x) : tag(x.tag) {
        switch(x.tag){
            case 1: new (&this->case1) Union5_DecidedC(std::move(x.case1)); break; // DecidedC
        }
    }
    __host__ __device__ Union5 & operator=(const Union5 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = x.case1; break; // DecidedC
            }
        } else {
            this->~Union5();
            new (this) Union5{x};
        }
        return *this;
    }
    __host__ __device__ Union5 & operator=(const Union5 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 1: this->case1 = std::move(x.case1); break; // DecidedC
            }
        } else {
            this->~Union5();
            new (this) Union5{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union5() {
        switch(this->tag){
            case 1: this->case1.~Union5_DecidedC(); break; // DecidedC
        }
        this->tag = 255;
    }
};
struct Union6_FinalC { // FinalC
    bool v0;
    __host__ __device__ Union6_FinalC(bool t0) : v0(t0) {}
    __host__ __device__ Union6_FinalC() = delete;
};
struct Union6 {
    union {
        Union6_FinalC case2; // FinalC
    };
    unsigned char tag{255};
    __host__ __device__ Union6() {}
    __host__ __device__ Union6(Union6_FinalC t) : tag(2), case2(t) {} // FinalC
    __host__ __device__ Union6(const Union6 & x) : tag(x.tag) {
        switch(x.tag){
            case 2: new (&this->case2) Union6_FinalC(x.case2); break; // FinalC
        }
    }
    __host__ __device__ Union6(const Union6 && x) : tag(x.tag) {
        switch(x.tag){
            case 2: new (&this->case2) Union6_FinalC(std::move(x.case2)); break; // FinalC
        }
    }
    __host__ __device__ Union6 & operator=(const Union6 & x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 2: this->case2 = x.case2; break; // FinalC
            }
        } else {
            this->~Union6();
            new (this) Union6{x};
        }
        return *this;
    }
    __host__ __device__ Union6 & operator=(const Union6 && x) {
        if (this->tag == x.tag) {
            switch(x.tag){
                case 2: this->case2 = std::move(x.case2); break; // FinalC
            }
        } else {
            this->~Union6();
            new (this) Union6{std::move(x)};
        }
        return *this;
    }
    __host__ __device__ ~Union6() {
        switch(this->tag){
            case 2: this->case2.~Union6_FinalC(); break; // FinalC
        }
        this->tag = 255;
    }
};
#endif
