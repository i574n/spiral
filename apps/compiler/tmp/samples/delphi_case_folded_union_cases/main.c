#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int tag;
    union {
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
US0 US0_Foo() { // Foo
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_FOO() { // FOO
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_Bar() { // Bar
    US0 x;
    x.tag = 2;
    return x;
}
int32_t main(){
    US0 v0 = US0_Foo();
    US0 v1 = US0_FOO();
    int32_t v4;
    switch (v0.tag) {
        case 2: { // Bar
            v4 = 100l;
            break;
        }
        case 1: { // FOO
            v4 = 10l;
            break;
        }
        default: { // Foo
            v4 = 1l;
            break;
        }
    }
    int32_t v7;
    switch (v1.tag) {
        case 2: { // Bar
            v7 = 100l;
            break;
        }
        case 1: { // FOO
            v7 = 10l;
            break;
        }
        default: { // Foo
            v7 = 1l;
            break;
        }
    }
    int32_t v8 = v4 + v7;
    return v8;
}
