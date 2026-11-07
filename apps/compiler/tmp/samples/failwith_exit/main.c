#include <stdbool.h>
#include <stdint.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
int32_t main(){
    int32_t v0 = 1l;
    bool v1 = v0 == 1l;
    if (v1){
        fprintf(stderr, "%s\n", "bo$om");
        exit(EXIT_FAILURE);
    } else {
        return 0l;
    }
}
