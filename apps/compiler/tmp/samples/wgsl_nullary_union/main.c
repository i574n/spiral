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
US0 US0_North() { // North
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_East() { // East
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_South() { // South
    US0 x;
    x.tag = 2;
    return x;
}
US0 US0_West() { // West
    US0 x;
    x.tag = 3;
    return x;
}
int32_t main(){
    US0 v0 = US0_North();
    US0 v8;
    switch (v0.tag) {
        case 1: { // East
            v8 = US0_South();
            break;
        }
        case 0: { // North
            v8 = US0_East();
            break;
        }
        case 2: { // South
            v8 = US0_West();
            break;
        }
        default: { // West
            v8 = US0_North();
            break;
        }
    }
    US0 v16;
    switch (v8.tag) {
        case 1: { // East
            v16 = US0_South();
            break;
        }
        case 0: { // North
            v16 = US0_East();
            break;
        }
        case 2: { // South
            v16 = US0_West();
            break;
        }
        default: { // West
            v16 = US0_North();
            break;
        }
    }
    US0 v17 = US0_South();
    bool v18;
    switch (v16.tag == v17.tag ? v16.tag : -1) {
        case 1: { // East
            v18 = true;
            break;
        }
        case 0: { // North
            v18 = true;
            break;
        }
        case 2: { // South
            v18 = true;
            break;
        }
        case 3: { // West
            v18 = true;
            break;
        }
        default: {
            v18 = false;
        }
    }
    int32_t v19;
    if (v18){
        v19 = 100l;
    } else {
        v19 = 0l;
    }
    int32_t v21;
    switch (v0.tag) {
        case 1: { // East
            v21 = 2l;
            break;
        }
        case 0: { // North
            v21 = 1l;
            break;
        }
        default: {
            v21 = 7l;
        }
    }
    int32_t v23;
    switch (v8.tag) {
        case 1: { // East
            v23 = 2l;
            break;
        }
        case 0: { // North
            v23 = 1l;
            break;
        }
        default: {
            v23 = 7l;
        }
    }
    int32_t v24 = v23 * 3l;
    int32_t v25 = v21 + v24;
    int32_t v27;
    switch (v16.tag) {
        case 1: { // East
            v27 = 2l;
            break;
        }
        case 0: { // North
            v27 = 1l;
            break;
        }
        default: {
            v27 = 7l;
        }
    }
    int32_t v28 = v27 * 9l;
    int32_t v29 = v25 + v28;
    int32_t v30 = v29 + v19;
    return v30;
}
