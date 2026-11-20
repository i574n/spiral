#include "main.hpp"
int main() {
    Union0 v0;
    v0 = Union0{Union0_Second{}};
    int v1;
    v1 = v0.tag;
    int v2;
    v2 = v1 * 10;
    int v3;
    v3 = v2 + 2;
    return v3;
}
