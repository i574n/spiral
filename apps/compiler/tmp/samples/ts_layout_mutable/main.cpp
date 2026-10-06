#include "main.hpp"
int main() {
    sptr<Mut0> v0;
    v0 = sptr<Mut0>{new Mut0{1, 2}};
    v0.base->v0 = 3; v0.base->v1 = 4;
    int v1 = v0.base->v0; int v2 = v0.base->v1;
    int v3;
    v3 = v1 + v2;
    return v3;
}
