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
US0 US0_Red() { // Red
    US0 x;
    x.tag = 0;
    return x;
}
US0 US0_Amber() { // Amber
    US0 x;
    x.tag = 1;
    return x;
}
US0 US0_Green() { // Green
    US0 x;
    x.tag = 2;
    return x;
}
int32_t main(){
    US0 v0 = US0_Amber();
    int32_t v1 = v0.tag;
    return v1;
}
