#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
        struct {
            int32_t v0;
        } case0; // Circle
        struct {
            int32_t v0;
        } case1; // Square
        struct {
            int32_t v0;
        } case2; // Triangle
    };
} US0;
static inline void USIncrefBody0(US0 * x){
    switch (x->tag) {
    }
}
static inline void USDecrefBody0(US0 * x){
    switch (x->tag) {
    }
}
void USIncref0(US0 * x){ USIncrefBody0(x); }
void USDecref0(US0 * x){ USDecrefBody0(x); }
US0 US0_Circle(int32_t v0) { // Circle
    US0 x;
    x.tag = 0;
    x.case0.v0 = v0;
    return x;
}
US0 US0_Square(int32_t v0) { // Square
    US0 x;
    x.tag = 1;
    x.case1.v0 = v0;
    return x;
}
US0 US0_Triangle(int32_t v0) { // Triangle
    US0 x;
    x.tag = 2;
    x.case2.v0 = v0;
    return x;
}
US0 US0_Dot() { // Dot
    US0 x;
    x.tag = 3;
    return x;
}
static int32_t method1(int32_t v0){
    int32_t v1 = v0 * v0;
    int32_t v2 = 7l * v0;
    int32_t v3 = v1 + v2;
    int32_t v4 = v3 - 3l;
    return v4;
}
static int32_t area0(US0 v0){
    switch (v0.tag) {
        case 0: { // Circle
            int32_t v1 = v0.case0.v0;
            return method1(v1);
            break;
        }
        case 3: { // Dot
            return 0l;
            break;
        }
        case 1: { // Square
            int32_t v3 = v0.case1.v0;
            return method1(v3);
            break;
        }
        default: { // Triangle
            int32_t v5 = v0.case2.v0;
            return method1(v5);
            break;
        }
    }
}
int32_t main(){
    int32_t v0 = 4l;
    US0 v1 = US0_Square(v0);
    return area0(v1);
}
