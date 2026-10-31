#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
    // one copy of this multi-line global, whatever the call count
    // the closing quote sits left of the content on purpose
int32_t main(){
    int32_t v0 = 1l;
    int32_t v1 = v0 + 1l;
    int32_t v2 = v1 + v1;
    int32_t v3 = v2 + v1;
    int32_t v4 = v3 - 6l;
    return v4;
}
