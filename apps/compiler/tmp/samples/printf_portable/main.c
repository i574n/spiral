#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
typedef struct {
    int refc;
    uint32_t len;
    char ptr[];
} Array0;
typedef Array0 String;
static inline void ArrayDecrefBody0(Array0 * x){
    (void)x;
}
void ArrayDecref0(Array0 * x){
    if (x != NULL && --(x->refc) == 0) { ArrayDecrefBody0(x); free(x); }
}
Array0 * ArrayCreate0(uint32_t len, bool init_at_zero){
    uint32_t size = sizeof(Array0) + sizeof(char) * len;
    Array0 * x = malloc(size);
    if (init_at_zero) { memset(x,0,size); }
    x->refc = 1;
    x->len = len;
    return x;
}
Array0 * ArrayLit0(uint32_t len, char * ptr){
    Array0 * x = ArrayCreate0(len, false);
    memcpy(x->ptr, ptr, sizeof(char) * len);
    return x;
}
static inline void StringDecref(String * x){
    return ArrayDecref0(x);
}
static inline String * StringLit(uint32_t len, char * ptr){
    return ArrayLit0(len, ptr);
}
int32_t main(){
    
    
    int32_t v0;
    v0 = 60l;
    
    
    int64_t v1;
    v1 = -9000000000ll;
    
    
    uint8_t v2;
    v2 = 200u;
    
    
    String * v3;
    v3 = StringLit(5, "cube");
    
    
    
    printf("%s: %d frames, checksum %d\n", v3->ptr, (int)v0, (int)970392l);
    
    
    
    printf("big %lld, small %d, byte %u\n", (long long)v1, (int)-5l, (unsigned)v2);
    
    
    
    printf("100%% {braces} \"quoted\" \\ tab\tend\n");
    
    
    
    printf("%s\n", "literal");
    
    
    
    printf("%s", v3->ptr);
    
    StringDecref(v3);
    
    printf("\n");
    
    
    return 0l;
}
