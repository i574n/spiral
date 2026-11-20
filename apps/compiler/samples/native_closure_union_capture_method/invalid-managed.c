#include <stdbool.h>
#include <stdint.h>

typedef struct Heap0 Heap0;
typedef struct {
    int tag;
    union {
        struct { Heap0 * v0; } case1;
    };
} US0;

typedef struct Fun0 Fun0;
struct Fun0 {
    int refc;
    void (*decref_fptr)(Fun0 *);
    int32_t (*fptr)(Fun0 *, int32_t);
};
typedef struct Closure0 Closure0;
struct Closure0 {
    int refc;
    void (*decref_fptr)(Closure0 *);
    int32_t (*fptr)(Closure0 *, int32_t);
    US0 v0;
};
