#include "main.hpp"
int main() {
    sptr<Heap0> v0;
    v0 = sptr<Heap0>{new Heap0{9, 10}};
    int v1 = v0.base->v0;
    int v2 = v0.base->v1;
    int v3;
    v3 = v1 + v2;
    return v3;
}
